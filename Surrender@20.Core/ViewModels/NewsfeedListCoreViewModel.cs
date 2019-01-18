﻿using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using PropertyChanged;
using Surrender_20.Core.Interface;
using Surrender_20.Model;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Surrender_20.Core.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public abstract class NewsfeedListCoreViewModel : MvxViewModel
    {

        protected INewsfeedService _newsfeedService;
        protected ISettingsService _settingsService;
        protected IMvxNavigationService _navigationService;
        protected Pages _page;

        public ObservableCollection<Newsfeed> Newsfeeds { get; set; }
        public string Title { get; set; }
        public bool IsLoading { get; set; }
        public bool IsRefreshing { get; set; }
        public bool IsLoadingMore { get; set; }
        public ICommand ItemTapped { get; set; }
        public ICommand LoadMore { get; set; }
        public ICommand RefreshItems { get; set; }



        public NewsfeedListCoreViewModel(INewsfeedService newsfeedService, ISettingsService settingsService,
            IMvxNavigationService navigationService)
        {
            _newsfeedService = newsfeedService;
            _settingsService = settingsService;
            _navigationService = navigationService;


            ItemTapped = new MvxAsyncCommand<Newsfeed>((Newsfeed) =>
            {
                return NavigateToAsync(Newsfeed);
            });

            RefreshItems = new MvxAsyncCommand(async () =>
            {
                Newsfeeds.Clear();
                await RefreshNewsfeeds(_page);
            });


            LoadMore = new MvxAsyncCommand(async () =>
            {
                IsLoadingMore = true;
                foreach (var item in await _newsfeedService.LoadMoreNewsfeeds())
                {
                    Newsfeeds.Add(item);
                }
                IsLoadingMore = false;
            });
        }

        protected abstract Task NavigateToAsync(Newsfeed newsfeed);

        protected async Task LoadNewsfeeds(Pages page)
        {
            IsLoading = true;
            Newsfeeds = new ObservableCollection<Newsfeed>(await _newsfeedService.LoadNewsfeedsAsync(page));
            IsLoading = false;
        }

        protected async Task RefreshNewsfeeds(Pages page)
        {
            IsRefreshing = true;
            Newsfeeds = new ObservableCollection<Newsfeed>(await _newsfeedService.LoadNewsfeedsAsync(page));
            IsRefreshing = false;
        }
    }
}
