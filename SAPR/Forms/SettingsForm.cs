using System;
using System.Windows.Forms;
using System.Drawing;
using SAPR.Classes;

namespace SAPR.Forms
{
    public partial class SettingsForm : Form
    {
        public SettingsForm(SettingsObject settingsObject, Form mainForm)
        {
            InitializeComponent();
            m_verticesColorButton.ColorChanged += m_ChangeValueHandler;
            m_edgesColorButton.ColorChanged += m_ChangeValueHandler;
            m_bgColorButton.ColorChanged += m_ChangeValueHandler;
            m_textColorButton.ColorChanged += m_ChangeValueHandler;

            m_settingsObject = settingsObject;
            m_mainForm = mainForm;

            m_LoadSettingsInComponents();             
        }

        private SettingsObject m_settingsObject;
        private bool m_isUserChanged = true;
        private Form m_mainForm;

        private void m_LoadSettingsInComponents()
        {
            m_isUserChanged = false;

            foreach (TabPage tab in tabControl.TabPages)
                foreach (object obj in tab.Controls)
                {
                    Control element = obj as Control;
                    object value = m_settingsObject[(string)element.Tag];
                    if (value == null)
                        continue;
                    switch (element.GetType().Name)
                    {
                        case "TextBox":    
                            if (value is string)              
                                ((TextBox)element).Text = (string)value;
                            break;
                        case "NumericUpDown":
                            if (value is int)
                                ((NumericUpDown)element).Value = (int)value;
                            break;
                        case "ButtonColor":
                            if (value is Color)
                                ((ButtonColor)element).Color = (Color)value;
                            break;
                    }
                }

            m_isUserChanged = true;
        }
        private void m_buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                m_settingsObject.Save();
                m_mainForm.Refresh();
            }
            catch (CantSaveSettingsException)
            {
                MessageBox.Show(Resources.AppResources.cantSaveSettings, 
                    Resources.AppResources.errorText, MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }

            Close();
        }
        private void m_buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void m_ChangeValueHandler(object sender, EventArgs e)
        {
            if (!m_isUserChanged)
                return;

            Control element = sender as Control;
            string key = (string)element.Tag;
            switch (element.GetType().Name)
            {
                case "TextBox":
                    m_settingsObject[key] = ((TextBox)element).Text;
                    break;
                case "NumericUpDown":
                    m_settingsObject[key] = (int)((NumericUpDown)element).Value;
                    break;
                case "ButtonColor":
                    m_settingsObject[key] = ((ButtonColor)element).Color;
                    break;
            }
        }
        private void m_ChangeAlgFolderClickHandler(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowse = new FolderBrowserDialog();
            folderBrowse.SelectedPath = m_algorithmsFolderText.Text;
            if (folderBrowse.ShowDialog() != DialogResult.OK)
                return;

            m_algorithmsFolderText.Text = folderBrowse.SelectedPath;
        }
    }
}
