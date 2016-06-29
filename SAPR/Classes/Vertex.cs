using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace SAPR.Classes
{
    [Serializable()]
    public class Vertex : Element
    {
        public Color TextColor { get; set; } = Color.Black;
        public List<Edge> Edges { get { return m_edges; } }
        public Point Position
        {
            get { return m_position; }
            set
            {
                m_position = value;

                foreach (Edge edge in m_edges)
                    if (AreaElement.Contains(edge.StartPos))
                        edge.StartPos = m_position;
                    else
                        edge.EndPos = m_position;

                areaElement.Location = new Point(value.X - Radius, value.Y - Radius);
            }
        }
        public override Rectangle AreaElement
        {
            get
            {
                if (areaElement.Height / 2 == m_radius)
                    return base.AreaElement;

                areaElement.X = m_position.X - m_radius;
                areaElement.Y = m_position.Y - m_radius;
                areaElement.Width = m_radius * 2;
                areaElement.Height = m_radius * 2;

                return base.AreaElement;
            }
        }

        public static int Radius
        {
            get { return m_radius; }
            set
            {
                if (value == m_radius)
                    return;

                m_radius = value;
            }
        }

        public Vertex(string text, Point position, Color colorSolid)
        {
            color = colorSolid;
            ColorSolid = colorSolid;
            Name = text;

            m_text = text;
            m_position = position;
            m_edges = new List<Edge>();

            Size size = new Size(Radius * 2, Radius * 2);
            areaElement = new Rectangle(new Point(position.X - Radius, position.Y - Radius), size);
        }
        public Vertex(string text, Point position) : this(text, position, Color.Black)
        { }
        public Vertex(string text) : this(text, new Point(0, 0))
        { }
        public Vertex() : this("")
        { }

        public void AddEdge(Edge edge)
        {
            m_edges.Add(edge);
        }
        public override void Dispose()
        {
            m_edges.Clear();

            m_text = null;        
            m_edges = null;

            base.Dispose();
        }

        private string      m_text;
        private Point       m_position;
        private List<Edge>  m_edges;

        private static int  m_radius = 10;
    }
}
