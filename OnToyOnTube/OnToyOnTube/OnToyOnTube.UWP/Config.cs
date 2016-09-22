﻿using SQLite.Net.Interop;
using Windows.Storage;
using Xamarin.Forms;
using OnToyOnTube.Controllers;

[assembly: Dependency(typeof(OnToyOnTube.UWP.Config))]

namespace OnToyOnTube.UWP
{
    public class Config : iConfig
    {
        private string directorioDB;
        private ISQLitePlatform plataforma;

        public string DirectorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(directorioDB))
                {
                    directorioDB = ApplicationData.Current.LocalFolder.Path;
                }
                return directorioDB;
            }
        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
                    //plataforma = new SQLite.Net.Platform.WindowsPhone8.SQLitePlatformW8();
                    //plataforma = new SQLite.Net.Platform.WindowsPhone8.SQLi
                    //plataforma = new Net.Platform.WindowsPhone8.SQLitePlatformWP8();
                    //plataforma = new Net.Platform.WinRT.SQLitePlatformWinRT();
                    //plataforma = new SQLitePlatformWinRT();
                }
                return plataforma;
            }
        }
    }
}
