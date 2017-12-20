using System;
using System.Collections.Generic;
using System.Text;

namespace GitServerModels.GitModel
{
    public class ServerSettings
    {
        private static Dictionary<String, SettingModel> settings;

        private const long serialVersionUID = 1L;

        public List<String> pushScripts;

        public ServerSettings()
        {
            settings = new Dictionary<String, SettingModel>();
        }

        public List<String> getKeys()
        {
            return new List<String>(settings.Keys);
        }

        public void add(SettingModel setting)
        {
            if (setting != null)
            {
                settings.Add(setting.name, setting);
            }
        }

        public SettingModel get(String key)
        {
            return settings[key];
        }

        public bool hasKey(String key)
        {
            return settings.ContainsKey(key);
        }

        public bool remove(String key)
        {
            return settings.Remove(key);
        }
    }

}
