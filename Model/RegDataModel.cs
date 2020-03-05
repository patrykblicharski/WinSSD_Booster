using Microsoft.Win32;

namespace WinSSD_Booster.Model
{
    public class RegDataModel
    {
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Name { get; set; }
        public object ModValue { get; set; }
        public object DefaultValue { get; set; }
        public RegistryKey BaseRegistryKey { get; set; }
        public string SubKey { get; set; }
        public bool GetRegValue { get; set; }

        public RegDataModel(string title, string desc, string name, object modvalue, object defaultvalue, RegistryKey baseRegistryKey, string subkey)
        {
            Title = title;
            Name = name;
            Desc = desc;
            ModValue = modvalue;
            DefaultValue = defaultvalue;
            BaseRegistryKey = baseRegistryKey;
            SubKey = subkey;
        }
    }
}