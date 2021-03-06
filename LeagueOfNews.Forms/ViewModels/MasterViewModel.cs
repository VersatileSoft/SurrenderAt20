﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using LeagueOfNews.Core.Interface;
using LeagueOfNews.Forms.Interfaces;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using PropertyChanged;

namespace LeagueOfNews.Forms.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MasterViewModel : MvxViewModel
    {
        public string Title { get; set; } = "Menu";

        public ICommand NavigateCommand { get; set; }

        public ObservableCollection<MenuListElement> MenuElements { get; set; }

        public MasterViewModel(IMasterDetailService masterDetailService)
        {
            MenuElements = new ObservableCollection<MenuListElement>
            {
                new MenuListElement { Name = "League of Legends Official", MenuImage = "LolOfficialIcon.png", Page = NewsWebsite.LoL },
                new MenuListElement { Name = "Surrender@20", MenuImage = "SurrenderAt20Icon.png", Page = NewsWebsite.Surrender },
                new MenuListElement { Name = "Dev Corner", MenuImage = "DevBlogIcon.png", Page = NewsWebsite.DevCorner },
                new MenuListElement { Name = "Settings", MenuImage = "SettingsIcon.png", Page = NewsWebsite.None }
            };

            NavigateCommand = new MvxCommand<MenuListElement>((Parameter) =>
            {
                masterDetailService.MasterPageSelect(Parameter.Page);
            });
        }
    }
    public class MenuListElement
    {
        public NewsWebsite Page { get; set; }
        public string Name { get; set; }
        public string MenuImage { get; set; }
    }
}