using System;
using System.Collections.Generic;
using Microsoft.Win32;
using WinSSD_Booster.Model;

namespace WinSSD_Booster.Controler
{
    public class RegistryModify
    {
        public List<string> errOut = new List<string>();

        private string subKey = "SOFTWARE\\";
        public string SubKey
        {
            get { return subKey; }
            set { subKey = value; }
        }


        private RegistryKey baseRegistryKey = Registry.LocalMachine;
        public RegistryKey BaseRegistryKey
        {
            get { return baseRegistryKey; }
            set { baseRegistryKey = value; }
        }

 
        //public ModifyRegistry()
        //{
        //    CheckRegValueState();
        //}
        /* **************************************************************************
		 * **************************************************************************/

        protected void CheckRegValueState()
        {
           
            foreach (RegDataModel item in RegPackDb.RegData)
            {
                subKey = item.SubKey;
                string temp = Read(item.Name);
                if (temp == item.DefaultValue)
                    item.GetRegValue = false;
                else
                    item.GetRegValue = true;

            }
        }
        /* **************************************************************************
		 * **************************************************************************/


        public string Read(string KeyName)
        {
            RegistryKey rk = baseRegistryKey;
           
            RegistryKey sk1 = rk.OpenSubKey(subKey);
            if (sk1 == null)
            {
                ShowErrorMsg(null, "Blad otwarcia SubKey, zwrocono null");
                return null;
            }
            else
            {
                try
                {
                    
                   var value = sk1.GetValue(KeyName.ToUpper());
                    if ((value.GetType() == typeof(int)) || (value.GetType() == typeof(string)))
                    {
                        return (string.Join("\n", value));
                    }
                    else if  (value.GetType() == typeof(string[]))
                    {
                        return  string.Join(" ", (string[])sk1.GetValue(KeyName.ToUpper()));
                        
                    }
                    ShowErrorMsg(null, "Blad otwarcia SubKey, zwrocono null");
                    return null;
                    
                    //return string.Join(" ",(string[])sk1.GetValue(KeyName.ToUpper()));
                    // string.Join(" ", aaa);
                    //  return aaa;
                    //return (string[])sk1.GetValue(KeyName.ToUpper());
                }
                catch (Exception e)
                {
                    //ShowErrorMessage(e, "Reading registry " + KeyName.ToUpper());
                    Console.WriteLine(e.Message + "\n" + "Reading registry " + KeyName.ToUpper());
                    return null;
                }
            }
        }


        /* **************************************************************************
		 * **************************************************************************/

        public bool Write(string KeyName, object Value)
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(subKey);
                
                sk1.SetValue(KeyName.ToUpper(), Value);

                return true;
            }
            catch (Exception e)
            {
                //ShowErrorMessage(e, "Writing registry " + KeyName.ToUpper());
                Console.WriteLine(e.Message + "\n" + "Writing registry " + KeyName.ToUpper());
                return false;
            }
        }

        /* **************************************************************************
		 * **************************************************************************/

        
        public bool DeleteKey(string KeyName)
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.CreateSubKey(subKey);
                
                if (sk1 == null)
                    return true;
                else
                    sk1.DeleteValue(KeyName);

                return true;
            }
            catch (Exception e)
            {
                // AAAAAAAAAAARGH, an error!
                ShowErrorMsg(e, "Deleting SubKey " + subKey);
               
                return false;
            }
        }

        /* **************************************************************************
		 * **************************************************************************/

        
        public bool DeleteSubKeyTree()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                
                if (sk1 != null)
                    rk.DeleteSubKeyTree(subKey);

                return true;
            }
            catch (Exception e)
            {

                ShowErrorMsg(e, "Deleting SubKeyTree " + subKey);
                return false;
            }
        }

        /* **************************************************************************
		 * **************************************************************************/

    
        public int SubKeyCount()
        {
            try
            {
                // Setting
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                // If the RegistryKey exists...
                if (sk1 != null)
                    return sk1.SubKeyCount;
                else
                    return 0;
            }
            catch (Exception e)
            {
               
                ShowErrorMsg(e, "Retriving subkeys of " + subKey);
                return 0;
            }
        }

        /* **************************************************************************
		 * **************************************************************************/

      
        public int ValueCount()
        {
            try
            {
                RegistryKey rk = baseRegistryKey;
                RegistryKey sk1 = rk.OpenSubKey(subKey);
                
                if (sk1 != null)
                    return sk1.ValueCount;
                else
                    return 0;
            }
            catch (Exception e)
            {
                
                
                ShowErrorMsg(e, "Retriving keys of " + subKey);
                return 0;
            }
        }

        /* **************************************************************************
		 * **************************************************************************/

        private void ShowErrorMsg(Exception e = null, string userMsg = "")
        {
            if (e == null)
               errOut.Add(userMsg);
            else
           // Console.WriteLine("E: /n Message: " + e.Message + "\n Zrodlo: " + e.Source + "\n Info: " + userMsg);
            errOut.Add("E: /n Message: " + e.Message + "\n Zrodlo: " + e.Source + "\n Info: " + userMsg);
        }
    }
}