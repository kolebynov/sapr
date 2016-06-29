using System;
using System.Drawing;
using System.Windows.Forms;
using Tao.Platform.Windows;
using System.Collections.Generic;

namespace SAPR.Classes
{
    /// <summary>
    /// Базовый класс для элементов графа.
    /// </summary>
    [Serializable()]
    public abstract class Element : IDisposable
    {
        public string Name { get; protected set; }
        public bool IsDisposed { get; private set; } = false;
        public bool IsSelected
        {
            get { return m_isSelected; }
            set
            {
                color = value ? ColorSelected : ColorSolid;
                m_isSelected = value;
            }
        }    
        public Color ColorSolid { get; set; }
        public Color CurrentColor { get { return color; } }

        public event EventHandler<MouseEventArgs> Click;

        public virtual Rectangle AreaElement
        {
            get { return areaElement; }
        }

        public static Color ColorSelected { get; set; } = Color.Red;
        public static List<Element> SelectedElement { get; private set; } = new List<Element>();

        public Element()
        {
            Click += (sender, e) =>
            {
                AddSelected(this);
            };
        }

        public void OnClick(MouseEventArgs e)
        {
            if (Click != null)
                Click(this, e);
        }
        public virtual void Dispose()
        {
            Name = null;
            Click = null;

            IsDisposed = true;
        }

        public static void AddSelected(Element element)
        {
            element.IsSelected = true;
            SelectedElement.Add(element);
        }
        public static void RemoveSelected(Element element)
        {
            element.IsSelected = false;
            SelectedElement.Remove(element);
        }
        public static void RemoveSelectedAt(int index)
        {
            SelectedElement[index].IsSelected = false;
            SelectedElement.RemoveAt(index);
        }
        public static void RemoveAllSelected()
        {
            foreach (Element elem in SelectedElement)
                elem.IsSelected = false;

            SelectedElement.Clear();
        }

        protected Color color;
        protected Rectangle areaElement;

        private bool m_isSelected = false;
    }
}
