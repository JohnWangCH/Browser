using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Browser
{
    class ConfigManager
    {
        private static ConfigManager configManager = null;
        public static ConfigManager Instance 
        {
            get 
            {
                if (configManager == null) 
                {
                    configManager = new ConfigManager();
                }

                return configManager;
            }
        }

        private Dictionary<String, String> configProperties = new Dictionary<string,string>();
        private StringBuilder configTxt = new StringBuilder("");

        private string configPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase) + @"\browser.conf";

        public ConfigManager() 
        {
            try
            {
                loadConfigFile();
            }
            catch (Exception e) 
            {
                System.Windows.Forms.MessageBox.Show("Can't find valid configuration file!");
                Log.WriteLog(e.ToString());
            }

        }

        private void loadConfigFile()
        {
            StreamReader sr = new StreamReader(configPath);
            while (!sr.EndOfStream)
            {
                String result = sr.ReadLine();
                configTxt.Append(result + "\n");
                if (!result.StartsWith("#"))
                {
                    configProperties.Add(result.Substring(0, result.IndexOf("=")), result.Substring(result.IndexOf("=") + 1));
                }
            }
        }

        public string GetProperty(string propName) 
        {
            return configProperties[propName];
        }

        public void SetProperty(string propName, string value) 
        {
            if (configProperties.ContainsKey(propName))
            {
                configTxt.Replace(String.Format("%s=%s", propName, GetProperty(propName)), String.Format("%s=%s", propName, value));
                configProperties[propName] = value;
            }
            else 
            {
                configTxt.Append(String.Format("%s=%s/n", propName, value));
                configProperties.Add(propName, value);
            }
            StreamWriter sw = new StreamWriter(configPath);
            sw.Write(configTxt);
        }

        public void Dump() 
        {
            Log.WriteLog("config properties:");
            foreach (var kv in configProperties) 
            {
                Log.WriteLog("Key: " + kv.Key + ", Value: " + kv.Value);
            }
        }
    }
}
