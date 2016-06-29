using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System;

namespace SAPR.Classes
{
    public class SettingsObject
    {
        public event Action<object, KeyValuePair<string, object>> ValueChanged;
        public event EventHandler SettingsSaved;

        public string FileName { get; private set; }

        public object this[string key]
        {
            get
            {
                if (key == null)
                    return null;

                object temp;
                if (m_settingsValues.TryGetValue(key, out temp))
                    return temp;
                else
                    return null;

            }
            set
            {
                object temp;
                bool isOk = m_settingsValues.TryGetValue(key, out temp);
                if (isOk && !temp.Equals(value))
                {
                    m_settingsValues[key] = value;

                    if (ValueChanged != null)
                        ValueChanged(this, new KeyValuePair<string, object>(
                            key, value));
                }
            }
        }

        public SettingsObject(string fileName)
        {
            FileName = fileName;
        }

        public void AddSetting(string key, object value)
        {
            m_settingsValues.Add(key, value);
        }
        public void RemoveSetting(string key)
        {
            m_settingsValues.Remove(key);
        }
        public void Save()
        {
            FileStream fileSave = null;
            try
            {
                fileSave = File.Create(FileName);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fileSave, m_settingsValues);
            }
            catch (Exception)
            {
                throw new CantSaveSettingsException();
            }
            finally
            {
                if (fileSave != null)
                    fileSave.Close();
            }

            if (SettingsSaved != null)
                SettingsSaved(this, new EventArgs());   
        }
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            foreach (var pair in m_settingsValues)
                yield return pair;
        }
        
        public static SettingsObject LoadFromFile(string fileName)
        {
            FileStream file = null;
            try
            {
                file = File.Open(fileName, FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                Dictionary<string, object> values 
                    = (Dictionary<string, object>)formatter.Deserialize(file);
                return new SettingsObject(values, fileName);
            }
            catch (IOException)
            {
                throw new NotFoundSettingFileException();
            }
            catch (SerializationException)
            {
                throw new BadSettingFileException();
            }
            catch (InvalidCastException)
            {
                throw new BadSettingFileException();
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }

        private Dictionary<string, object> m_settingsValues = new Dictionary<string, object>();

        private SettingsObject(Dictionary<string, object> values, string fileName)
        {
            m_settingsValues = values;
            FileName = fileName;
        }
    }

    public class NotFoundSettingFileException : ApplicationException
    { }

    public class BadSettingFileException : ApplicationException
    { }

    public class CantSaveSettingsException : ApplicationException
    { }
}
