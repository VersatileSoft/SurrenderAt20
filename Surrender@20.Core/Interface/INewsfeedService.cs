﻿using Surrender_20.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surrender_20.Core.Interface
{
    public interface INewsfeedService
    {
        Task<ObservableCollection<Newsfeed>> LoadNewsfeedsAsync(string url);
        Task<ObservableCollection<Newsfeed>> LoadMoreNewsfeeds();
    }
}
