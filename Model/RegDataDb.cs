using System.Collections.Generic;
using Microsoft.Win32;

namespace WinSSD_Booster.Model
{
   
        static class RegPackDb
        {
            public static List<RegDataModel> RegData = new List<RegDataModel>(){


                new RegDataModel("Ntfs Last Access Update",
                    "NtfsDisableLastAccessUpdate",
                    "NtfsDisableLastAccessUpdate",
                    1,
                    0,
                    Registry.LocalMachine,
                    "SYSTEM\\CurrentControlSet\\Control\\FileSystem"),

                new RegDataModel("Prefetcher",
                    "Prefetcher",
                    "EnablePrefetcher",
                    0,
                    1,
                    Registry.LocalMachine,
                    "SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters"),

                new RegDataModel("SuperPrefetcher",
                    "SuperPrefetcher",
                    "EnableSuperFetch",
                    0,
                    1,
                    Registry.LocalMachine,
                    "SYSTEM\\CurrentControlSet\\Control\\Session Manager\\Memory Management\\PrefetchParameters"),



            };
            public static List<RegDataModel> AdditionalReg = new List<RegDataModel>()
            {
                new RegDataModel("WSearch",
                    "Windows Search Start",
                    "Start",
                    4,
                    2,
                    Registry.LocalMachine,
                    "SYSTEM\\ContrsolSet001\\Services\\WSearch")
            };




        }
    }
