﻿using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using Surrender_20.Core.Interface;
using Surrender_20.Core.ViewModels;
using Surrender_20.Model;
using System;
using System.Threading.Tasks;

namespace Surrender_20.Forms.ViewModels
{
    public class NewsfeedListViewModel : NewsfeedListCoreViewModel, IMvxViewModel<Pages>
    {
        public NewsfeedListViewModel(INewsfeedService newsfeedService, ISettingsService settingsService, IMvxNavigationService navigationService)
            : base(newsfeedService, settingsService, navigationService)
        {
        }

        public void Prepare(Pages parameter)
        {
            Title = _settingsService[parameter].Title;

            Task.Run(() => LoadNewsfeeds(parameter, _settingsService[parameter].URL));
        }

        protected override Task NavigateToAsync(Newsfeed newsfeed)
        {
            throw new NotImplementedException();
        }
    }
}