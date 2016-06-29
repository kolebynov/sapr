using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAPR.Forms
{
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }
        public ReportForm(ReportData data) : this()
        {
            int max = data.parts[0].Length;
            for (int i = 1; i < data.parts.Length; i++)
                if (data.parts[i].Length > max)
                    max = data.parts[i].Length;

            m_gridPart.ColumnCount = max + 1;
            m_gridPart.RowCount = data.parts.Length;

            for (int i = 0; i < data.parts.Length; i++)
            {
                m_gridPart[0, i].Value = (i + 1).ToString() + "-й кусок";
                for (int j = 0; j < data.parts[i].Length; j++)
                    m_gridPart[j + 1, i].Value = data.vertexNames[data.parts[i][j]];
            }

            int[] innerEdges = m_CalculateInnerEdges(data.parts, data.adjMatrix);
            m_innerEdgesGrid.ColumnCount = innerEdges.Length;
            m_innerEdgesGrid.RowCount = 1;
            for (int i = 0; i < innerEdges.Length; i++)
            {
                m_innerEdgesGrid.Columns[i].Name = "L" + (i + 1).ToString();
                m_innerEdgesGrid[i, 0].Value = innerEdges[i];
            }

            int[][] outerEdges = m_CalculateOuterEdges(data.parts, data.adjMatrix);
            int countPart = data.parts.Length;
            m_outerEdgesGrid.ColumnCount = (countPart * countPart - countPart) / 2;
            m_outerEdgesGrid.RowCount = 1;
            int columnNo = 0;
            for (int i = 0; i < outerEdges.Length; i++)
                for (int j = 0; j < outerEdges[i].Length; j++, columnNo++)
                {
                    m_outerEdgesGrid.Columns[columnNo].Name = "K" + (i + 1).ToString() +
                        "-" + (i + j + 2).ToString();
                    m_outerEdgesGrid[columnNo, 0].Value = outerEdges[i][j];
                }

            m_labelCutRate.Text += m_CalculateCatRate(innerEdges, outerEdges).ToString(
                "F3") + ".";

            m_labelPerformTime.Text = string.Format("Время выполнения алгоритма: {0:F5} сек.",
                data.performTime);
        }

        private int[] m_CalculateInnerEdges(int[][] parts, int[,] adjMatrix)
        {
            int[] temp = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                int inner = 0;
                for (int j = 0; j < parts[i].Length; j++)
                    for (int k = j; k < parts[i].Length; k++)
                        inner += adjMatrix[parts[i][j], parts[i][k]];

                temp[i] = inner;
            }

            return temp;
        }
        private int[][] m_CalculateOuterEdges(int[][] parts, int[,] adjMatrix)
        {
            int[][] temp = new int[parts.Length - 1][];
            for (int i = 0; i < temp.Length; i++)
                temp[i] = new int[parts.Length - i - 1];

            for (int i = 0; i < parts.Length - 1; i++)
                for (int j = i + 1; j < parts.Length; j++)
                {
                    int outer = 0;
                    for (int k = 0; k < parts[i].Length; k++)
                        for (int l = 0; l < parts[j].Length; l++)
                            outer += adjMatrix[parts[i][k], parts[j][l]];

                    temp[i][j - i - 1] = outer;
                }

            return temp;
        }
        private double m_CalculateCatRate(int[] innerEdges, int[][] outerEdges)
        {
            int innerSum = innerEdges.Sum();
            int outerSum = 0;

            foreach (int[] outer in outerEdges)
                outerSum += outer.Sum();

            return (double)innerSum / outerSum;
        }

        private void ReportForm_Resize(object sender, EventArgs e)
        {
            int newSize = Size.Width - 35;
            Size gridSize;

            gridSize = m_gridPart.Size;
            gridSize.Width = newSize;
            m_gridPart.Size = gridSize;

            gridSize = m_innerEdgesGrid.Size;
            gridSize.Width = newSize;
            m_innerEdgesGrid.Size = gridSize;

            gridSize = m_outerEdgesGrid.Size;
            gridSize.Width = newSize;
            m_outerEdgesGrid.Size = gridSize;
        }
    }

    public struct ReportData
    {
        public string[] vertexNames;
        public int[][] parts;
        public double performTime;
        public int[,] adjMatrix;

        public ReportData(string[] vertexNames, int[][] parts, double performTime,
            int[,] adjMatrix)
        {
            this.vertexNames = vertexNames;
            this.parts = parts;
            this.performTime = performTime;
            this.adjMatrix = adjMatrix;
        }
    }
}
