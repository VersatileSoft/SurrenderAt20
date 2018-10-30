﻿using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using Surrender_20.Core.ViewModels;
using Surrender_20.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Surrender_20.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Detail, NoHistory = true)]
    public partial class NewsfeedListView : MvxContentPage<NewsfeedListViewModel>
    {
		public NewsfeedListView()
		{
			InitializeComponent();
		}

        // ItemClicked
        private void MvxListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
            ViewModel.ItemSelected.Execute((Newsfeed)e.SelectedItem);
        }
    }
}