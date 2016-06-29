using System.Collections.Generic;
using System.Windows.Forms;

namespace SAPR.Classes
{
    public class AdjMatrix
    {
        public int[,] Values { get { return m_values; } }
        public int[] LocalPower { get { return m_localPower; } }

        public AdjMatrix(List<Vertex> vertices, List<Edge> edges)
        {
            m_vertices = vertices;
            m_edges = edges;
            m_values = new int[0, 0];

            UpdateMatrix();
        }

        public Vertex this[int index]
        {
            get { return m_vertices[index]; }
        }

        public void UpdateMatrix()
        {
            int vertCount = m_vertices.Count;

            m_values = new int[vertCount, vertCount];
            m_localPower = new int[vertCount];
            foreach (Edge edge in m_edges)
            {
                int i = m_vertices.IndexOf(edge.StartVertex);
                int j = m_vertices.IndexOf(edge.EndVertex);
                m_values[i, j]++;
                m_localPower[i]++;
                if (i != j)
                {
                    m_values[j, i]++;
                    m_localPower[j]++;
                }
            }
        }
        public void ChangeElements(List<Vertex> vertices, List<Edge> edges)
        {
            m_edges = edges;
            m_vertices = vertices;

            UpdateMatrix();
        }

        private int[,] m_values;
        private int[] m_localPower;
        private List<Vertex> m_vertices;
        private List<Edge> m_edges;
    }
}