using SAPR.Classes;
using SAPR.Structures;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Text;
using SAPR.Resources;

namespace SAPR.Forms
{
    public partial class MainForm : Form
    {
        public string AlgorithmsFolder
        {
            get { return m_algorithmsFolder; }
            private set
            {
                m_algorithmsFolder = value;
                m_LoadAlgorithms();
            }
        }
        public string CurrentFile
        {
            get { return m_currentFile; }
            private set
            {
                m_currentFile = value;
                Text = m_currentFile + " - " + AppResources.ProgramName;
            }
        }

        public EventHandler<MouseEventArgs> ActionOnClick { get; set; }
        public EventHandler<MouseEventArgs> ActionOnMouseMove { get; set; }
        public Point OffsetClientRectangle { get; private set; }

        public MainForm()
        {
            InitializeComponent();
            m_LoadToolStripItems();

            m_vertices = new List<Vertex>();
            m_edges = new List<Edge>();
            m_vertForEdge = new List<Vertex>(2);
            m_keyboard = new Keyboard();
            //m_adjMatrix = new AdjMatrix(m_vertices, m_edges);
            m_adjMatrixGrid = new AdjMatrixGrid(new AdjMatrix(m_vertices, m_edges), this);
            m_matrixForm = new MatrixForm(m_adjMatrixGrid);
            AllowTransparency = false;
            CurrentFile = AppResources.defaultFileName;

            m_matrixForm.Location = new Point(
                SystemInformation.PrimaryMonitorSize.Width - m_matrixForm.Width,
                SystemInformation.PrimaryMonitorSize.Height - m_matrixForm.Height - 40);
            m_matrixForm.FormClosing += (sender, e) =>
            {
                if (e.CloseReason != CloseReason.UserClosing)
                    return;

                e.Cancel = true;
                m_matrixForm.Hide();
            };
            m_matrixForm.VisibleChanged += (sender, e) =>
                toolStripAdjMatrix.Checked = m_matrixForm.Visible;

            ActionOnClick = (sender, e) => { };
            ActionOnMouseMove = (sender, e) => { };

            OffsetClientRectangle = new Point(toolStripLeft.Width,
                mainMenu.Height + toolStripTop.Height);

            m_LoadSettings();
            m_matrixForm.Show(this);
        }

        static MainForm()
        {
            defaultSettings = new SettingsObject(AppResources.settingsFileName);
            defaultSettings.AddSetting("edges_width", 2);
            defaultSettings.AddSetting("vertices_radius", 10);
            defaultSettings.AddSetting("algorithms_folder",
                Environment.CurrentDirectory + "\\Algorithms\\");
            defaultSettings.AddSetting("vertices_color", Color.Black);
            defaultSettings.AddSetting("edges_color", Color.Black);
            defaultSettings.AddSetting("background_color", SystemColors.Control);
            defaultSettings.AddSetting("vertices_text_color", Color.Black);
        }

        /// <summary>
        /// Добавление новой вершины в список вершин
        /// </summary>
        /// <param name="name">Имя вершины</param>
        /// <param name="position">Позиция вершины</param>
        public void AddVertex(Point position)
        {
            string name = m_GetNameForVertex();

            Vertex vert = new Vertex(name, position,
                ((ToolStripButtonColor)m_vertexToolStripItems[1]).Color);
            vert.TextColor = ((ToolStripButtonColor)m_vertexToolStripItems[3]).Color;

            Element.RemoveAllSelected();

            m_vertices.Add(vert);
            m_adjMatrixGrid.AddVertex();
        }
        /// <summary>
        /// Добавление нового ребра в список
        /// </summary>
        /// <param name="vert1">1-я вершина</param>
        /// <param name="vert2">2-я вершина</param>
        public void AddEdge(Vertex vert1, Vertex vert2, bool isUpdate)
        {
            Edge edge = new Edge(vert1, vert2,
                ((ToolStripButtonColor)m_edgeToolStripItems[1]).Color);
            m_edges.Add(edge);
            m_adjMatrixGrid.AddEdge(m_vertices.IndexOf(vert1), m_vertices.IndexOf(vert2), isUpdate);
        }
        public void RemoveEdgeAt(int index, bool isUpdate)
        {
            RemoveEdge(m_edges[index], isUpdate);
        }
        /// <summary>
        /// Удаление ребра из списка
        /// </summary>
        /// <param name="edge">Удаляемое ребро</param>
        public void RemoveEdge(Edge edge, bool isUpdate)
        {
            m_edges.Remove(edge);
            m_adjMatrixGrid.RemoveEdge(m_vertices.IndexOf(edge.StartVertex), m_vertices.IndexOf(edge.EndVertex), isUpdate);

            if (!edge.IsDisposed)
                edge.Dispose();
            edge = null;
        }
        /// <summary>
        /// Удаление вершины из списка
        /// </summary>
        /// <param name="vertex">Удаляемая вершина</param>
        public void RemoveVertex(Vertex vertex, bool isUpdate)
        {
            RemoveVertexAt(m_vertices.IndexOf(vertex), isUpdate);
        }
        public void RemoveVertexAt(int index, bool isUpdate)
        {
            for (int i = 0; i < m_vertices[index].Edges.Count;)
                RemoveEdge(m_vertices[index].Edges[i], isUpdate);

            m_vertices[index].Dispose();
            m_vertices[index] = null;

            m_vertices.RemoveAt(index);
            m_adjMatrixGrid.DeleteVertex(index, isUpdate);
        }

        private List<Vertex> m_vertices;
        private List<Edge> m_edges;
        private List<Vertex> m_vertForEdge;
        //private AdjMatrix m_adjMatrix;
        private AdjMatrixGrid m_adjMatrixGrid;
        private MatrixForm m_matrixForm;
        private bool m_isMove;
        private Keyboard m_keyboard;
        private AlgorithmInvoker m_algorithmInvoker;
        private SettingsObject m_settingsObject;
        private string m_algorithmsFolder;
        private string m_currentFile;

        private ToolStripItem[] m_vertexToolStripItems;
        private ToolStripItem[] m_edgeToolStripItems;

        private static bool m_isCheck = true;
        private static Point m_oldMousePos;
        private static SettingsObject defaultSettings;

        private void m_LoadSettings()
        {
            try
            {
                m_settingsObject = SettingsObject.LoadFromFile(AppResources.settingsFileName);
            }
            catch (NotFoundSettingFileException)
            {
                MessageBox.Show(AppResources.fileSettingsNotFound,
                    AppResources.errorText, MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
                m_settingsObject = defaultSettings;
            }
            catch (BadSettingFileException)
            {
                MessageBox.Show(AppResources.badFileSettings,
                    AppResources.errorText, 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_settingsObject = defaultSettings;
            }
            
            m_settingsObject.SettingsSaved += m_ApplySettings;
            m_ApplySettings(m_settingsObject, new EventArgs());
        }
        private void m_ApplySettings(object sender, EventArgs e)
        {
            SettingsObject settingsObject = sender as SettingsObject;
            if (settingsObject == null)
                return;

            foreach (var pair in settingsObject)
            {
                switch (pair.Key)
                {
                    case "edges_width":
                        if (pair.Value is int)
                            Edge.EdgeWidth = (int)pair.Value;
                        break;
                    case "vertices_radius":
                        if (pair.Value is int)
                            Vertex.Radius = (int)pair.Value;
                        break;
                    case "algorithms_folder":
                        if (pair.Value is string)
                            AlgorithmsFolder = (string)pair.Value;
                        break;
                    case "vertices_color":
                        if (pair.Value is Color)
                            ((ToolStripButtonColor)m_vertexToolStripItems[1]).Color = 
                                (Color)pair.Value;
                        break;
                    case "edges_color":
                        if (pair.Value is Color)
                            ((ToolStripButtonColor)m_edgeToolStripItems[1]).Color = 
                                (Color)pair.Value;
                        break;
                    case "background_color":
                        if (pair.Value is Color)
                            GLDraw.BGColor = (Color)pair.Value;
                        break;
                    case "vertices_text_color":
                        if (pair.Value is Color)
                            ((ToolStripButtonColor)m_vertexToolStripItems[3]).Color =
                                (Color)pair.Value;
                        break;
                }
            }
        }
        private void m_LoadAlgorithms()
        {
            m_algorithmInvoker = new AlgorithmInvoker(m_algorithmsFolder);

            toolStripAlgorithms.DropDownItems.Clear();

            ToolStripMenuItem[] menuItemAlgorithms = new ToolStripMenuItem[
                m_algorithmInvoker.Algorithms.Count];

            for (int i = 0; i < menuItemAlgorithms.Length; i++)
            {
                menuItemAlgorithms[i] = new ToolStripMenuItem();
                menuItemAlgorithms[i].Text = m_algorithmInvoker.Algorithms[i].Name;
                menuItemAlgorithms[i].Tag = i;
                menuItemAlgorithms[i].Click += m_ClickAlgorithmMenuItem;
            }

            toolStripAlgorithms.DropDownItems.AddRange(menuItemAlgorithms);
        }
        private void m_LoadToolStripItems()
        {
            m_vertexToolStripItems = new ToolStripItem[6];
            m_vertexToolStripItems[0] = new ToolStripLabel("Цвет вершины:");
            m_vertexToolStripItems[1] = new ToolStripButtonColor();
            m_vertexToolStripItems[2] = new ToolStripLabel("Цвет текста:");
            Padding pad = m_vertexToolStripItems[2].Margin;
            pad.Left = 10;
            m_vertexToolStripItems[2].Margin = pad;
            m_vertexToolStripItems[3] = new ToolStripButtonColor();
            m_vertexToolStripItems[4] = new ToolStripLabel("Префикс:");
            m_vertexToolStripItems[4].Margin = pad;
            ToolStripTextBox prefixTextBox = new ToolStripTextBox();
            prefixTextBox.Text = "R";
            prefixTextBox.BorderStyle = BorderStyle.FixedSingle;
            m_vertexToolStripItems[5] = prefixTextBox;

            m_edgeToolStripItems = new ToolStripItem[2];
            m_edgeToolStripItems[0] = new ToolStripLabel("Цвет ребра:");
            m_edgeToolStripItems[1] = new ToolStripButtonColor();
        }
        /// <summary>
        /// Переотрисовка формы.
        /// </summary>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            GLDraw.DrawElement(m_vertices, m_edges);
        }
        /// <summary>
        /// Обработка нажатия кнопки выделения.
        /// </summary>
        private void buttonSelection_Click(object sender2, EventArgs e2)
        {
            ActionOnClick = (sender, e) =>
            {
                foreach (Element element in Element.SelectedElement)
                {
                    Edge edge = element as Edge;
                    if (edge != null && edge.RectAvgPos.Contains(e.Location))
                    {
                        m_isMove = true;
                        return;
                    }
                }

                for (int i = m_vertices.Count - 1; i >= 0; i--)
                {
                    Vertex vertex = m_vertices[i];

                    if (vertex.AreaElement.Contains(e.Location))
                    {
                        if (!m_keyboard.CtrlKeyDown)
                            Element.RemoveAllSelected();
                        vertex.OnClick(e);
                        GLDraw.DrawElement(m_vertices, m_edges);
                        m_isMove = true;
                        return;
                    }
                }

                for (int i = m_edges.Count - 1; i >= 0; i--)
                {
                    Edge edge = m_edges[i];

                    if (edge.IsIntersect(e.Location))
                    {
                        if (!m_keyboard.CtrlKeyDown)
                            Element.RemoveAllSelected();
                        edge.OnClick(e);
                        GLDraw.DrawElement(m_vertices, m_edges);
                        m_isMove = true;
                        return;
                    }
                }



                Element.RemoveAllSelected();
                GLDraw.DrawElement(m_vertices, m_edges);
            };

            ActionOnMouseMove = (sender, e) =>
            {
                if (m_oldMousePos == null)
                    m_oldMousePos = e.Location;

                if (m_isMove)
                {
                    if (m_isCheck)
                    {
                        for (int i = 0; i < Element.SelectedElement.Count;)
                        {
                            Vertex selectedVertex = Element.SelectedElement[i] as Vertex;
                            Edge selectedEdge = Element.SelectedElement[i] as Edge;
                            if (selectedVertex != null)
                            {
                                if (!selectedVertex.AreaElement.Contains(e.Location))
                                {
                                    Element.RemoveSelectedAt(i);
                                    continue;
                                }
                            }
                            else
                            {
                                if (!selectedEdge.RectAvgPos.Contains(e.Location))
                                {
                                    Element.RemoveSelectedAt(i);
                                    continue;
                                }
                            }

                            i++;
                        }

                        m_isCheck = false;
                    }

                    if (Element.SelectedElement.Count < 1)
                        return;
                    Vertex selVertex = Element.SelectedElement[0] as Vertex;
                    Edge selEdge = Element.SelectedElement[0] as Edge;
                    if (selVertex != null)
                    {
                        if (m_CheckPositionForVertex(e.Location, selVertex) &&
                        GLControl.ClientRectangle.Contains(e.Location))
                            selVertex.Position = e.Location;
                    }
                    else
                    {
                        if (m_CheckPositionForVertex(e.Location, selVertex) &&
                        GLControl.ClientRectangle.Contains(e.Location))
                            selEdge.AvgPos = e.Location;
                    }

                    GLDraw.DrawElement(m_vertices, m_edges);
                }

                m_oldMousePos = e.Location;
            };

            toolStripTop.Items.Clear();
        }
        /// <summary>
        /// Обработка нажатия кнопки создания вершины
        /// </summary>
        private void buttonVertex_Click(object sender2, EventArgs e2)
        {
            ActionOnClick = (sender, e) =>
            {
                if (m_CheckPositionForVertex(e.Location))
                {
                    AddVertex(e.Location);
                    //for (int i = 0; i < m_vertices.Count - 1; i++)
                    //    m_edges.Add(new Edge(m_vertices[i], m_vertices[m_vertices.Count - 1]));
                    GLDraw.DrawElement(m_vertices, m_edges);
                }
            };

            toolStripTop.Items.Clear();
            toolStripTop.Items.AddRange(m_vertexToolStripItems);
        }
        /// <summary>
        /// Обработка нажатия кнопки создания ребра
        /// </summary>
        private void buttonEdge_Click(object sender2, EventArgs e2)
        {
            Element.RemoveAllSelected();
            ActionOnClick = (sender, e) =>
            {
                Element.RemoveAllSelected();
                if (m_vertForEdge.Count < 2)
                {
                    foreach (Vertex vertex in m_vertices)
                        if (vertex.AreaElement.Contains(e.Location))
                        {
                            m_vertForEdge.Add(vertex);
                            vertex.OnClick(e);
                            GLDraw.DrawElement(m_vertices, m_edges);
                            break;
                        }
                    if (m_vertForEdge.Count < 2)
                        return;
                }

                AddEdge(m_vertForEdge[0], m_vertForEdge[1], true);
                m_vertForEdge.Clear();
                Element.RemoveAllSelected();

                GLDraw.DrawElement(m_vertices, m_edges);
            };

            toolStripTop.Items.Clear();
            toolStripTop.Items.AddRange(m_edgeToolStripItems);
        }
        /// <summary>
        /// Обработка нажатия любой кнопки на левой панели
        /// </summary>
        private void toolStripLeft_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripButton chbtn = e.ClickedItem as ToolStripButton;
            chbtn.Checked = true;
            foreach (ToolStripButton btn in toolStripLeft.Items)
                if (chbtn != btn)
                    btn.Checked = false;

            ActionOnMouseMove = (sender2, e2) => { };
            ActionOnClick = (sender2, e2) => { };
        }
        /// <summary>
        /// Обработка изменения состояния кнопки создания ребра
        /// </summary>
        private void buttonEdge_CheckedChanged(object sender, EventArgs e)
        {
            m_vertForEdge.Clear();
        }
        /// <summary>
        /// Обработка изменения размера формы
        /// </summary>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            GLDraw.ResizeGL(ClientSize.Width - OffsetClientRectangle.X, 
                ClientSize.Height - OffsetClientRectangle.Y);
        }
        /// <summary>
        /// Обработка открытия формы, инициализация OpenGL
        /// </summary>
        private void MainForm_Shown(object sender, EventArgs e)
        {
            GLControl.Location = OffsetClientRectangle;
            Size size = ClientRectangle.Size;
            size.Width -= OffsetClientRectangle.X;
            size.Height -= OffsetClientRectangle.Y;
            GLControl.Size = size;
            GLDraw.InitGL(GLControl);
        }
        /// <summary>
        /// Обработка клика по контролу
        /// </summary>
        private void GLControl_MouseDown(object sender, MouseEventArgs e)
        {
            ActionOnClick(sender, e);
        }
        /// <summary>
        /// Обработка перемещения мыши по контролу
        /// </summary>
        private void GLControl_MouseMove(object sender, MouseEventArgs e)
        {
            ActionOnMouseMove(sender, e);
        }
        /// <summary>
        /// Обработка нажатия клавиши на контроле
        /// </summary>
        private void GLControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && buttonSelection.Checked)
            {
                for (int i = 0; i < Element.SelectedElement.Count;)
                {
                    Element elem = Element.SelectedElement[i];
                    if (elem is Edge)
                    {
                        Element.RemoveSelectedAt(i);
                        RemoveEdge((Edge)elem, false);                     
                        continue;
                    }
                    i++;
                }
                foreach (Element elem in Element.SelectedElement)
                    RemoveVertex((Vertex)elem, false);

                m_adjMatrixGrid.UpdateMatrix();

                Element.RemoveAllSelected();
                GLDraw.DrawElement(m_vertices, m_edges);

                GC.Collect();
            }
        }        
        private string m_GetNameForVertex()
        {
            StringBuilder temp = new StringBuilder(m_vertexToolStripItems[5].Text);
            string prefix = m_vertexToolStripItems[5].Text;
            int maxIndex = 0;

            foreach (Vertex vertex in m_vertices)
                if (vertex.Name.Contains(prefix))
                {
                    int index = int.Parse(vertex.Name.Substring(temp.Length));
                    if (index > maxIndex)
                        maxIndex = index;
                }

            maxIndex++;
            temp.Append(maxIndex);

            return temp.ToString();
        }
        private void m_ClickAlgorithmMenuItem(object sender, EventArgs e)
        {
            if (m_vertices.Count == 0 || m_edges.Count == 0)
            {
                MessageBox.Show(AppResources.emptyGraph, AppResources.errorText,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            ToolStripMenuItem menuItem = sender as ToolStripMenuItem;

            CountPartForm countPartForm = new CountPartForm(m_algorithmInvoker.Algorithms[(int)menuItem.Tag],
                m_adjMatrixGrid, m_vertices);
            countPartForm.ShowDialog();
            //m_CutGraph(result);       
        }
        private void toolStripNewFile_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(AppResources.needSaveFile,
                AppResources.attentionText, MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
                toolStripSaveFile_Click(sender, e);
            else if (result == DialogResult.Cancel)
                return;

            CurrentFile = AppResources.defaultFileName;

            m_edges.ForEach(edge => edge.Dispose());
            m_vertices.ForEach(vertex => vertex.Dispose());
            m_edges.Clear();
            m_vertices.Clear();

            m_adjMatrixGrid.Dispose();
            m_adjMatrixGrid = new AdjMatrixGrid(new AdjMatrix(m_vertices, m_edges), this);
            m_matrixForm.AdjMatrix = m_adjMatrixGrid;

            GC.Collect();

            Refresh();
        }
        private void toolStripOpenFile_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(AppResources.needSaveFile,
                AppResources.attentionText, MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
                toolStripSaveFile_Click(this, new EventArgs());
            else if (result == DialogResult.Cancel)
                return;

            openFileDialog.FileName = string.Empty;
            if (openFileDialog.ShowDialog() != DialogResult.OK)
                return;

            Graph graph;
            try
            {
                graph = m_OpenFile(openFileDialog.FileName);
            }
            catch (BadFileFormatException)
            {
                MessageBox.Show(AppResources.badFormatFile, AppResources.errorText, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CurrentFile = openFileDialog.FileName;

            m_edges.ForEach(edge => edge.Dispose());
            m_edges.Clear();
            m_vertices.ForEach(vertex => vertex.Dispose());
            m_vertices.Clear();
            GC.Collect();

            m_vertices = graph.vertices;
            m_edges = graph.edges;

            m_vertices.ForEach(vertex =>
            {
                if (vertex.IsSelected)
                    vertex.IsSelected = false;
            });
            m_edges.ForEach(edge =>
            {
                if (edge.IsSelected)
                    edge.IsSelected = false;
            });

            m_adjMatrixGrid.Dispose();
            m_adjMatrixGrid = new AdjMatrixGrid(new AdjMatrix(m_vertices, m_edges), this);
            m_matrixForm.AdjMatrix = m_adjMatrixGrid;
            GLDraw.DrawElement(m_vertices, m_edges);      
        }
        private void toolStripSaveFile_Click(object sender, EventArgs e)
        {
            string path;
            if (CurrentFile == AppResources.defaultFileName)
            {
                saveFileDialog.FileName = string.Empty;
                if (saveFileDialog.ShowDialog() != DialogResult.OK)
                    return;
                path = saveFileDialog.FileName;
            }
            else
                path = CurrentFile;

            m_SaveFile(path);
            CurrentFile = path;
        }
        private void toolStripSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog.FileName = string.Empty;
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
                return;

            m_SaveFile(saveFileDialog.FileName);
            CurrentFile = saveFileDialog.FileName;
        }
        private void toolStripExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(Resources.AppResources.needSaveFile,
                AppResources.attentionText, MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
                toolStripSaveFile_Click(sender, e);
            else if (result == DialogResult.Cancel)
                return;

            Environment.Exit(0);
        }
        private void m_SaveFile(string path)
        {
            Graph graph = new Graph(m_vertices, m_edges);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream fs = File.Create(path);
            formatter.Serialize(fs, graph);
            fs.Close();
        }
        private Graph m_OpenFile(string path)
        {
            FileStream fs = null;
            Graph graph;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                fs = File.Open(path, FileMode.Open);
                graph = (Graph)formatter.Deserialize(fs);
            }
            catch (SerializationException)
            {
                throw new BadFileFormatException();
            }
            catch (InvalidCastException)
            {
                throw new BadFileFormatException();
            }
            finally
            {
                if (fs != null)
                    fs.Close();                
            }

            return graph;
        }
        /// <summary>
        /// Разрез графа на куски.
        /// </summary>
        private void m_CutGraph(int[][] graph)
        {
            Rectangle clientRect = new Rectangle(toolStripLeft.Width, mainMenu.Height, ClientRectangle.Width - toolStripLeft.Width, ClientRectangle.Height - mainMenu.Height);
            Point pointRect = new Point(clientRect.X, clientRect.Y);
            Size sizeRect = new Size(clientRect.Width / ((graph.Length + 1) / 2), clientRect.Height / 2);

            List<Rectangle> rectsCut = new List<Rectangle>();

            for (int i = 0; i < graph.Length; i++)
            {
                Point[] vertexPoints;
                rectsCut.Add(new Rectangle(pointRect, sizeRect));
                vertexPoints = m_RandomPoint(rectsCut.Last(), graph[i].Length);

                for (int j = 0; j < graph[i].Length; j++)
                    m_vertices[graph[i][j]].Position = vertexPoints[j];

                pointRect.X += sizeRect.Width;
                if (i >= graph.Length / 2)
                {
                    pointRect.X = 0;
                    pointRect.Y += sizeRect.Height;
                }
            }

            GLDraw.DrawElement(m_vertices, m_edges);
        }
        private Point[] m_RandomPoint(Rectangle rect, int countPoint)
        {
            Random rnd = new Random();
            Point[] temp = new Point[countPoint];
            for (int i = 0; i < countPoint; i++)
                temp[i] = new Point(rnd.Next(rect.Location.X + 20, rect.Location.X + rect.Width - 20), rnd.Next(rect.Location.Y + 20, rect.Location.Y + rect.Height - 20));

            return temp;
        }
        private void GLControl_MouseUp(object sender, MouseEventArgs e)
        {
            m_isMove = false;
            m_isCheck = true;
        }
        private bool m_CheckPositionForVertex(Point position, params Vertex[] skipVertices)
        {
            if (skipVertices.Length == 0)
                foreach (Vertex vertex in m_vertices)
                {
                    float distance = position.SubByPoint(vertex.Position).GetLength();
                    if (distance <= Vertex.Radius * 2)
                        return false;
                }
            else
                foreach (Vertex vertex in m_vertices)
                {
                    float distance = position.SubByPoint(vertex.Position).GetLength();
                    if (distance <= Vertex.Radius * 2 && !skipVertices.Contains(vertex))
                        return false;
                }

            return true;
        }
        private void toolStripSettings_Click(object sender, EventArgs e)
        {
            SettingsForm settingForm = new SettingsForm(m_settingsObject, this);
            settingForm.ShowDialog();
        }
        private void toolStripAdjMatrix_Click(object sender, EventArgs e)
        {
            if (m_matrixForm.Visible)
                m_matrixForm.Hide();
            else
                m_matrixForm.Show(this);
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_settingsObject.Save();
        }
    }
}
