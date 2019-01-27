﻿using MvvmCross.ViewModels;
using PropertyChanged;
using Surrender_20.Core.Interface;
using System.Text.RegularExpressions;

namespace Surrender_20.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class SettingsCoreViewModel : MvxViewModel
    {
        public bool IsNotificationsEnabled {
            get
            {
                return _saveDataService.GetIsNotificationsEnabled();
            }
            set
            {
                _saveDataService.SaveIsNotificationsEnabled(value);
                _notificationService.RefreshNotificationJobService();
            }
        }

        public bool DarkTheme
        {
            get
            {
                return _saveDataService.GetIsDarkTheme();
            }
            set
            { 
                _saveDataService.SaveIsDarkTheme(value);
                if (value)
                    _themeService.SetAppTheme(AppTheme.Dark);
                else
                    _themeService.SetAppTheme(AppTheme.Ligt);
            }
        }

        public string Delay
        {
            get
            {
                return _saveDataService.GetCheckNewPostsFrequency() + " Hours";
            }
            set
            { 
                _saveDataService.SaveCheckNewPostsFrequency(int.Parse(Regex.Match(value, @"\d+").Value));
                _notificationService.RefreshNotificationJobService();
            }
        }
        
        public MvxObservableCollection<string> DelayList { get; set; }

        private ISaveDataService _saveDataService;
        private INotificationService _notificationService;
        private IThemeService _themeService;

        public SettingsCoreViewModel(ISaveDataService saveDataService, INotificationService notificationService, IThemeService themeService)
        {
            _saveDataService = saveDataService;
            _notificationService = notificationService;
            _themeService = themeService;
            DelayList = new MvxObservableCollection<string>
            {
                "2 Hours",
                "6 Hours",
                "12 Hours",
                "24 Hours"
            };
        }
    }
}