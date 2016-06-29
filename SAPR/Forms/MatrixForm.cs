using SAPR.Classes;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace SAPR.Forms
{
    public partial class MatrixForm : Form
    {
        public AdjMatrixGrid AdjMatrix
        {
            get { return m_adjMatrixGrid; }
            set
            {
                Controls.Remove(m_adjMatrixGrid);

                m_adjMatrixGrid = value;
                m_ResetAdjMatrix(m_adjMatrixGrid);

                Controls.Add(m_adjMatrixGrid);
            }
        }

        public MatrixForm(AdjMatrixGrid adjMatrixGrid)
        {
            InitializeComponent();

            m_adjMatrixGrid = adjMatrixGrid;
            m_ResetAdjMatrix(m_adjMatrixGrid);

            Controls.Add(m_adjMatrixGrid);
        }

        private AdjMatrixGrid m_adjMatrixGrid;

        private static readonly int COLUMN_WIDTH = 40;

        private void MatrixForm_Resize(object sender, EventArgs e)
        {
            m_adjMatrixGrid.Height = ClientSize.Height;
            m_adjMatrixGrid.Width = ClientSize.Width;
        }
        private void m_ResetAdjMatrix(AdjMatrixGrid adjMatrix)
        {
            adjMatrix.Location = new Point(0, 0);
            adjMatrix.Size = new Size(ClientSize.Width, ClientSize.Height);

            foreach (DataGridViewColumn column in adjMatrix.Columns)
                column.Width = COLUMN_WIDTH;
        }
    }
}
