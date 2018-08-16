﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Surrender_20.Forms.Views.Utils
{

    public class ExtendedLabel : Label
    {
        public static readonly BindableProperty MaxLinesProperty =
            BindableProperty.Create("MaxLines", typeof(int), typeof(ExtendedLabel), 1, BindingMode.OneWay,
                validateValue: IsValidValue,
                propertyChanged: OnPropertyChanged);

        private static bool IsValidValue(BindableObject bindable, object value)
        {
            bool isInt = int.TryParse(value.ToString(), out int result);
            return isInt && result >= 1;
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            ((ExtendedLabel)bindable).MaxLines = (int)newValue;
        }

        public int MaxLines
        {
            get { return (int)GetValue(MaxLinesProperty); }
            set { SetValue(MaxLinesProperty, value); }
        }
    }

}