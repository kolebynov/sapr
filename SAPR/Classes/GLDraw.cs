using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.Platform.Windows;
using System.Drawing;
using System.Collections.Generic;
using System;

namespace SAPR.Classes
{
    /// <summary>
    /// Класс для отрисовки элементов.
    /// </summary>
    public static class GLDraw
    {
        public static Color BGColor
        {
            get { return m_bgColor; }
            set
            {
                m_bgColor = value;
                m_GetColorfFromColor(ref m_bgColorf, m_bgColor);
            }
        }

        public static void InitGL(SimpleOpenGlControl glControl)
        {
            glControl.InitializeContexts();
            Glut.glutInit();
            Gl.glViewport(0, 0, glControl.Width, glControl.Height);
            Glu.gluOrtho2D(0, glControl.Width, glControl.Height, 0);

            Gl.glEnable(Gl.GL_BLEND);
            Gl.glBlendFunc(Gl.GL_SRC_ALPHA, Gl.GL_ONE_MINUS_SRC_ALPHA);
            Gl.glEnable(Gl.GL_LINE_SMOOTH);
            Gl.glHint(Gl.GL_LINE_SMOOTH_HINT, Gl.GL_NICEST);
            Gl.glEnable(Gl.GL_POINT_SMOOTH);
            Gl.glHint(Gl.GL_POINT_SMOOTH_HINT, Gl.GL_NICEST);

            m_glControl = glControl;
        }
        public static void ResizeGL(int newWidth, int newHeight)
        {
            m_glControl.Size = new Size(newWidth, newHeight);
            //glMatrixMode(Gl.GL_2D);
            Gl.glLoadIdentity();
            Gl.glViewport(0, 0, m_glControl.Width, m_glControl.Height);
            Glu.gluOrtho2D(0, m_glControl.Width, m_glControl.Height, 0);
        }
        public static void DrawElement(List<Vertex> vertices, List<Edge> edges)
        {
            m_BeginFrame();
            m_DrawEdges(edges);
            m_DrawVertex(vertices);
            m_EndFrame();
        }

        private static SimpleOpenGlControl m_glControl;
        private static Color m_bgColor;
        private static float[] m_bgColorf = new float[3];
        private static float[] m_colorf = new float[3];
        private static PointF[] m_cicrlePos = m_GenerateCirclePos(0.01);

        private static void m_BeginFrame()
        {
            Gl.glClearColor(m_bgColorf[0], m_bgColorf[1], m_bgColorf[2], 1f);
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT);
        }
        private static void m_EndFrame()
        {
            m_glControl.SwapBuffers();
        }
        private static void m_GetColorfFromColor(ref float[] colorf, Color color)
        {
            colorf[0] = color.R / 255f;
            colorf[1] = color.G / 255f;
            colorf[2] = color.B / 255f;
        }
        private static void m_DrawVertex(List<Vertex> vertices)
        {
            Gl.glPointSize(Vertex.Radius * 2);
            Gl.glBegin(Gl.GL_POINTS);

            foreach (Vertex vertex in vertices)
            {
                m_GetColorfFromColor(ref m_colorf, vertex.CurrentColor);
                Gl.glColor3f(m_colorf[0], m_colorf[1], m_colorf[2]);
                Gl.glVertex2i(vertex.Position.X, vertex.Position.Y);
            }

            Gl.glEnd();

            foreach (Vertex vertex in vertices)
            {
                m_GetColorfFromColor(ref m_colorf, vertex.TextColor);
                Gl.glColor3f(m_colorf[0], m_colorf[1], m_colorf[2]);
                Gl.glRasterPos3d(vertex.Position.X, vertex.Position.Y - Vertex.Radius - 3, 0);
                Glut.glutBitmapString(Glut.GLUT_BITMAP_9_BY_15, vertex.Name);
            }
               
        }
        private static void m_DrawEdges(List<Edge> edges)
        {
            foreach (Edge edge in edges)
            {
                Gl.glLineWidth(Edge.EdgeWidth);
                Gl.glBegin(Gl.GL_LINE_STRIP);
      
                m_GetColorfFromColor(ref m_colorf, edge.CurrentColor);
                Gl.glColor3f(m_colorf[0], m_colorf[1], m_colorf[2]);
                if (edge.IsLoop)
                    m_DrawLoop(edge);
                else
                    m_DrawBezier(edge);

                Gl.glEnd();

                if (edge.IsSelected && !edge.IsLoop)
                {
                    Gl.glLineWidth(1f);
                    Gl.glColor3f(0.1f, 0.1f, 0.1f);
                    Gl.glBegin(Gl.GL_LINE_STRIP);
                    Gl.glVertex2i(edge.StartPos.X, edge.StartPos.Y);
                    Gl.glVertex2i(edge.AvgPos.X, edge.AvgPos.Y);
                    Gl.glVertex2i(edge.EndPos.X, edge.EndPos.Y);
                    Gl.glEnd();

                    Gl.glColor3f(0.7f, 0.7f, 0.7f);
                    Gl.glPointSize(Edge.avgPosRadius * 2);
                    Gl.glBegin(Gl.GL_POINTS);
                    Gl.glVertex2i(edge.AvgPos.X, edge.AvgPos.Y);
                    Gl.glEnd();

                    //m_DrawAreaElement(edge);
                }
            }   
        }
        private static void m_DrawBezier(Edge edge)
        {
            if (edge.AvgPos.X == (edge.StartPos.X + edge.EndPos.X) / 2 && edge.AvgPos.Y == (edge.StartPos.Y + edge.EndPos.Y) / 2)
            {
                Gl.glVertex2i(edge.StartPos.X, edge.StartPos.Y);
                Gl.glVertex2i(edge.EndPos.X, edge.EndPos.Y);
            }
            else
                for (float t = 0f; t <= 1f; t += 0.01f)
                {
                    float x = (float)(Math.Pow(1 - t, 2) * edge.StartPos.X + 2 * (1 - t) * t * edge.AvgPos.X + t * t * edge.EndPos.X);
                    float y = (float)(Math.Pow(1 - t, 2) * edge.StartPos.Y + 2 * (1 - t) * t * edge.AvgPos.Y + t * t * edge.EndPos.Y);
                    Gl.glVertex2f(x, y);
                }
        }
        private static void m_DrawLoop(Edge edge)
        {
            float radius = Vertex.Radius * Edge.loopRadiusRatio;
            PointF center = new PointF();
            float heightUp = (Vertex.Radius - radius) * 2;
            center.X = edge.StartVertex.AreaElement.X + radius;
            center.Y = edge.StartVertex.AreaElement.Bottom + radius - heightUp;
            m_DrawCircle(center, radius);
        }
        private static void m_DrawAreaElement(Element element)
        {
            Gl.glLineWidth(1f);
            Gl.glBegin(Gl.GL_LINE_STRIP);

            Gl.glVertex2i(element.AreaElement.X, element.AreaElement.Y);
            Gl.glVertex2i(element.AreaElement.X + element.AreaElement.Width, element.AreaElement.Y);
            Gl.glVertex2i(element.AreaElement.X + element.AreaElement.Width, element.AreaElement.Y + element.AreaElement.Height);
            Gl.glVertex2i(element.AreaElement.X, element.AreaElement.Y + element.AreaElement.Height);
            Gl.glVertex2i(element.AreaElement.X, element.AreaElement.Y);

            Gl.glEnd();
        }
        private static void m_DrawCircle(PointF center, float radius)
        {
            foreach (PointF point in m_cicrlePos)
                Gl.glVertex2f(point.X * radius + center.X, 
                    point.Y * radius + center.Y);

            Gl.glVertex2f(m_cicrlePos[0].X * radius + center.X,
                m_cicrlePos[0].Y * radius + center.Y);
        }
        private static PointF[] m_GenerateCirclePos(double step)
        {
            PointF[] temp = new PointF[(int)Math.Ceiling(1 / step)];
            int index = 0;
            for (double i = 0; i < 1.0 - 0.000001; i += step, index++)
            {
                double angle = Math.PI * 2 * i;
                temp[index] = new PointF((float)Math.Cos(angle),
                    (float)Math.Sin(angle));
            }

            return temp;
        }
    }
}
