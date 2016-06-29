using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace SAPR.Classes
{
    [Serializable()]
    public class Edge : Element
    {
        public Point StartPos
        {
            get { return m_startPos; }
            set
            {
                Point oldCenter = m_endPos.SubByPoint(m_startPos).DivByNumber(2);
                Point newCenter = m_endPos.SubByPoint(value).DivByNumber(2);
                Point offset = newCenter.SubByPoint(oldCenter);
                m_avgPos = m_avgPos.SubByPoint(offset);
                m_startPos = value;
                if (IsLoop)
                    m_endPos = value;
                m_UpdateArea();
            }
        }
        public Point EndPos
        {
            get { return m_endPos; }
            set
            {
                Point oldCenter = m_endPos.SubByPoint(m_startPos).DivByNumber(2);
                Point newCenter = value.SubByPoint(m_startPos).DivByNumber(2);
                Point offset = newCenter.SubByPoint(oldCenter);
                m_avgPos = m_avgPos.AddByPoint(offset);
                m_endPos = value;
                if (IsLoop)
                    m_startPos = value;
                m_UpdateArea();
            }
        }
        public Point AvgPos
        {
            get { return m_avgPos; }
            set
            {
                m_avgPos = value;
                m_UpdateArea();
            }
        }
        public Rectangle RectAvgPos { get; private set; }
        public Vertex StartVertex { get; private set; }
        public Vertex EndVertex { get; private set; }
        public bool IsLoop { get; private set; } = false;

        public static int EdgeWidth { get; set; } = 2;
        public static readonly int avgPosRadius = 7;
        public static readonly float loopRadiusRatio = 0.7f;

        public Edge(Vertex vert1, Vertex vert2, Color colorSolid)
        {
            vert1.AddEdge(this);
            vert2.AddEdge(this);

            if (vert1 == vert2)
                IsLoop = true;

            color = colorSolid;
            ColorSolid = colorSolid;

            StartVertex = vert1;
            EndVertex = vert2;

            m_startPos = StartVertex.Position;
            m_endPos = EndVertex.Position;
            m_avgPos = new Point();
            ResetAvgPos();
            Name = StartVertex.Name + "-" + EndVertex.Name;

            m_UpdateArea();
        }
        public Edge(Vertex vert1, Vertex vert2) : this(vert1, vert2, Color.Blue)
        { }
        public Edge() : this(null, null)
        { }

        public bool IsIntersect(Point point)
        {
            if (IsLoop)
                return m_LoopIntersect(point);
            else
                return m_NormalIntersect(point);
        }
        public override void Dispose()
        {
            StartVertex.Edges.Remove(this);
            EndVertex.Edges.Remove(this);

            StartVertex = null;
            EndVertex = null;

            base.Dispose();
        }
        public void ResetAvgPos()
        {
            m_avgPos.X = (StartPos.X + EndPos.X) / 2;
            m_avgPos.Y = (StartPos.Y + EndPos.Y) / 2;
        }

        private Point       m_startPos;
        private Point       m_endPos;
        private Point       m_avgPos;

        private void m_UpdateArea()
        {
            Point minAvgPoint = new Point(int.MaxValue, int.MaxValue);
            Point maxAvgPoint = new Point(int.MinValue, int.MinValue);

            Point temp = new Point();
            for (float t = 0f; t <= 1f; t += 0.02f)
            {            
                temp.X = (int)((Math.Pow(1 - t, 2) * m_startPos.X + 2 * (1 - t) * t * m_avgPos.X + t * t * m_endPos.X) + 0.5f);
                temp.Y = (int)((Math.Pow(1 - t, 2) * m_startPos.Y + 2 * (1 - t) * t * m_avgPos.Y + t * t * m_endPos.Y) + 0.5f);

                minAvgPoint = ExtensionMethods.MinPoint(minAvgPoint, temp);
                maxAvgPoint = ExtensionMethods.MaxPoint(maxAvgPoint, temp);
            }

            Point min = new Point(int.MaxValue, int.MaxValue);
            Point max = new Point(int.MinValue, int.MinValue);
            Point[] masPoints = new Point[]
            {
                minAvgPoint,
                maxAvgPoint,
                m_startPos,
                m_endPos
            };

            min = ExtensionMethods.MinPoint(masPoints);
            max = ExtensionMethods.MaxPoint(masPoints);
            int widthDiv2 = EdgeWidth / 2;
            min = min.SubByPoint(new Point(widthDiv2, widthDiv2));
            max = max.AddByPoint(new Point(widthDiv2, widthDiv2));

            areaElement = new Rectangle(min, new Size(max.X - min.X, max.Y - min.Y));
            RectAvgPos = new Rectangle(AvgPos.X - avgPosRadius, AvgPos.Y - avgPosRadius, 
                avgPosRadius * 2, avgPosRadius * 2);
        }
        private bool m_NormalIntersect(Point point)
        {
            if (!areaElement.Contains(point))
                return false;

            int diff = (int)(EdgeWidth / 2 + 5f);

            for (float t = 0f; t <= 1f; t += 0.02f)
            {
                float x = (float)(Math.Pow(1 - t, 2) * m_startPos.X + 2 * (1 - t) * t * m_avgPos.X + t * t * m_endPos.X);
                float y = (float)(Math.Pow(1 - t, 2) * m_startPos.Y + 2 * (1 - t) * t * m_avgPos.Y + t * t * m_endPos.Y);

                if (point.X == (int)x && point.Y == (int)y)
                    return true;
                else
                {
                    if (point.X < x && point.X >= x - diff)
                    {
                        if (point.Y < y && point.Y >= y - diff)
                            return true;
                        if (point.Y > y && point.Y <= y + diff)
                            return true;
                    }
                    if (point.X > x && point.X <= x + diff)
                    {
                        if (point.Y < y && point.Y >= y - diff)
                            return true;
                        if (point.Y > y && point.Y <= y + diff)
                            return true;
                    }
                }
            }

            return false;
        }
        private bool m_LoopIntersect(Point point)
        {
            int sizeRect = (int)(Vertex.Radius * 2 * loopRadiusRatio + 
                EdgeWidth / 2f + 0.5f);
            int heightUp = Vertex.Radius * 2 - sizeRect;
            Rectangle intersectRect = new Rectangle(StartVertex.AreaElement.Left,
                StartVertex.AreaElement.Bottom - heightUp, sizeRect, sizeRect);

            return intersectRect.Contains(point);
        }
    }
}
