using System;
using System.Windows.Forms;
using SAPR.Classes;
using System.Diagnostics;
using SAPR.Resources;
using System.Collections.Generic;
using System.Linq;

namespace SAPR.Forms
{
    public partial class CountPartForm : Form
    {
        public CountPartForm(AlgorithmInvoker.Algorithm alg, AdjMatrixGrid adjMatrixGrid,
            List<Vertex> vertices)
        {
            InitializeComponent();

            m_alg = alg;
            m_adjMatrixGrid = adjMatrixGrid;
            m_vertices = vertices;

            m_gridVertexCount.RowCount = 1;
            numericUpDown1.Maximum = m_vertices.Count < 30 ? m_vertices.Count : 30L;
            numericUpDown1_ValueChanged(this, new EventArgs());
            m_FreeVertex = vertices.Count;
        }

        private AlgorithmInvoker.Algorithm m_alg;
        private AdjMatrixGrid m_adjMatrixGrid;
        private List<Vertex> m_vertices;
        private int m_freeVertex = -1;
        private bool m_isFilling = false;

        private int m_FreeVertex
        {
            get { return m_freeVertex; }
            set
            {
                if (value == m_freeVertex)
                    return;

                if (value == 0)
                    m_buttonOk.Enabled = true;
                else
                    m_buttonOk.Enabled = false;

                m_labelFreeVertex.Text = value.ToString();
                m_freeVertex = value;
            }
        }

        private void m_buttonOk_Click(object sender, EventArgs e)
        {
            Close();

            Stopwatch timer = new Stopwatch();
            int countPart = (int)numericUpDown1.Value;
            int[] countVertexInParts = new int[countPart];
            for (int i = 0; i < countPart; i++)
                countVertexInParts[i] = int.Parse(
                    (string)m_gridVertexCount[i, 0].Value);

            timer.Start();
            int[][] result = m_alg.Calculate(m_adjMatrixGrid.Matrix.Values, countPart,
                countVertexInParts);
            timer.Stop();

            string[] vertexNames = m_vertices.Select(vertex => vertex.Name).ToArray();
            ReportData data = new ReportData(vertexNames, result,
                timer.Elapsed.TotalSeconds, m_adjMatrixGrid.Matrix.Values);
            ReportForm reportForm = new ReportForm(data);
            reportForm.Show();
        }
        private void m_buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            m_gridVertexCount.ColumnCount = (int)numericUpDown1.Value;
            for (int i = 0; i < m_gridVertexCount.ColumnCount; i++)
                if (m_gridVertexCount.Columns[i].Name == string.Empty)
                {
                    m_isFilling = true;
                    m_gridVertexCount.Columns[i].Name = "Кусок №" + (i + 1).ToString();
                    m_gridVertexCount[i, 0].Value = "0";
                    m_isFilling = false;
                }
        }
        private void m_gridVertexCount_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            string oldValue = (string)m_gridVertexCount[e.ColumnIndex, e.RowIndex].Value;
            if ((string)e.FormattedValue == oldValue)
                return;

            int newNumber;
            if (!int.TryParse((string)e.FormattedValue, out newNumber) ||
                newNumber < 0)
            {
                e.Cancel = true;
                MessageBox.Show(AppResources.badNumber, AppResources.errorText,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void m_gridVertexCount_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (m_isFilling)
                return;

            m_CalculateFreeVertex();
        }
        private void m_gridVertexCount_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            m_CalculateFreeVertex();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            m_isFilling = true;

            int countPart = (int)numericUpDown1.Value;
            int count = m_vertices.Count / countPart;
            int remain = m_vertices.Count % countPart;

            for (int i = 0; i < countPart; i++)
                m_gridVertexCount[i, 0].Value = (count + 
                    (countPart - i <= remain ? 1 : 0)).ToString();

            m_isFilling = false;
            m_FreeVertex = 0;
        }

        private void m_CalculateFreeVertex()
        {
            int sum = 0;
            for (int i = 0; i < m_gridVertexCount.ColumnCount; i++)
                sum += int.Parse((string)m_gridVertexCount[i, 0].Value);

            m_FreeVertex = m_vertices.Count - sum;
        }
    }
}
