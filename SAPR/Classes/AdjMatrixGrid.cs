using System.Windows.Forms;
using System.Drawing;
using SAPR.Forms;
using System;
using SAPR.Resources;

namespace SAPR.Classes
{
    public partial class AdjMatrixGrid : DataGridView
    {
        public AdjMatrix Matrix { get; private set; }

        public AdjMatrixGrid(AdjMatrix adjMatrix, MainForm mainForm)
        {
            Matrix = adjMatrix;
            m_mainForm = mainForm;
            m_isUserCellChanged = true;

            m_SetGrid();
            m_SetValues();
            m_InitEvents();
        }

        public void DeleteVertex(int index, bool isUpdate = true)
        {
            m_isUserCellChanged = false;

            Columns.RemoveAt(index + 1);
            Rows.RemoveAt(index + 1);
            if (isUpdate)
                UpdateMatrix();

            m_isUserCellChanged = true;
        }
        public void AddVertex(bool isUpdate = true)
        {
            m_isUserCellChanged = false;

            ColumnCount++;
            Columns[ColumnCount - 1].Width = 40;
            RowCount++;
            if (isUpdate)
                UpdateMatrix();

            m_isUserCellChanged = true;
        }
        public void AddEdge(int vert1Index, int vert2Index, bool isUpdate = true)
        {
            m_isUserCellChanged = false;

            this[vert1Index + 1, vert2Index + 1].Value = (int)this[vert1Index + 1, vert2Index + 1].Value + 1;
            if (vert1Index != vert2Index)
                this[vert2Index + 1, vert1Index + 1].Value = (int)this[vert2Index + 1, vert1Index + 1].Value + 1;
            if (isUpdate)
                Matrix.UpdateMatrix();

            m_isUserCellChanged = true;
        }
        public void RemoveEdge(int vert1Index, int vert2Index, bool isUpdate = true)
        {
            m_isUserCellChanged = false;

            this[vert1Index + 1, vert2Index + 1].Value = (int)this[vert1Index + 1, vert2Index + 1].Value - 1;
            if (vert1Index != vert2Index)
                this[vert2Index + 1, vert1Index + 1].Value = (int)this[vert2Index + 1, vert1Index + 1].Value - 1;
            if (isUpdate)
                Matrix.UpdateMatrix();

            m_isUserCellChanged = true;
        }
        public void UpdateMatrix()
        {
            Matrix.UpdateMatrix();
            m_SetValues();
        }

        private MainForm m_mainForm;
        private bool m_isUserCellChanged;

        private void m_SetValues()
        {
            for (int i = 0; i < Matrix.LocalPower.Length; i++)
            {
                this[0, i + 1].Value = Matrix[i].Name;
                this[i + 1, 0].Value = Matrix[i].Name;
            }
            for (int i = 0; i < Matrix.LocalPower.Length; i++)
                for (int j = 0; j < Matrix.LocalPower.Length; j++)
                    this[i + 1, j + 1].Value = Matrix.Values[i, j];
        }
        private void m_SetGrid()
        {
            Location = new Point(100, 100);
            Size = new Size(200, 200);
            RowHeadersVisible = false;
            ColumnHeadersVisible = false;
            ColumnCount = Matrix.LocalPower.Length + 1;
            RowCount = Matrix.LocalPower.Length + 2;
            DefaultCellStyle.ForeColor = Color.Black;
            MultiSelect = false;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToOrderColumns = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            Columns[0].Width = 40;
        }
        private void m_InitEvents()
        {
            CellClick += (sender, e) =>
            {
                if (e.ColumnIndex == 0 || e.RowIndex == 0)
                    EditMode = DataGridViewEditMode.EditProgrammatically;
                else
                    EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            };
            CellValidating += (sender, e) =>
            {
                if (e.ColumnIndex == 0 && e.RowIndex == 0)
                    return;

                int a;
                if (!int.TryParse((string)e.FormattedValue, out a))
                {
                    MessageBox.Show(AppResources.badNumber, AppResources.errorText, 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true;
                }
            };
            CellValueChanged += (sender, e) =>
            {
                if (m_isUserCellChanged)
                {
                    if (this[e.ColumnIndex, e.RowIndex].Value.GetType().Name == "String")
                        this[e.ColumnIndex, e.RowIndex].Value = int.Parse(
                            (string)this[e.ColumnIndex, e.RowIndex].Value);
                    else
                        return;

                    int difference = (int)this[e.ColumnIndex, e.RowIndex].Value -
                        Matrix.Values[e.ColumnIndex - 1, e.RowIndex - 1];
                    Vertex vertex1 = Matrix[e.ColumnIndex - 1];
                    Vertex vertex2 = Matrix[e.RowIndex - 1];

                    for (int i = 0; i < Math.Abs(difference); i++)
                        if (difference > 0)
                            m_mainForm.AddEdge(vertex1, vertex2, false);
                        else
                            m_mainForm.RemoveEdge(vertex1.Edges[0], false);

                    UpdateMatrix();
                    m_mainForm.Refresh();
                }
            };
        }
    }
}
