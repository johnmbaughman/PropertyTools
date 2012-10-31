﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RadioButtonListPage.xaml.cs" company="PropertyTools">
//   The MIT License (MIT)
//
//   Copyright (c) 2012 Oystein Bjorke
//
//   Permission is hereby granted, free of charge, to any person obtaining a
//   copy of this software and associated documentation files (the
//   "Software"), to deal in the Software without restriction, including
//   without limitation the rights to use, copy, modify, merge, publish,
//   distribute, sublicense, and/or sell copies of the Software, and to
//   permit persons to whom the Software is furnished to do so, subject to
//   the following conditions:
//
//   The above copyright notice and this permission notice shall be included
//   in all copies or substantial portions of the Software.
//
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS
//   OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//   MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//   IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//   CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//   TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//   SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary>
//   Interaction logic for RadioButtonListPage.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace ControlsDemo
{
    /// <summary>
    /// Interaction logic for RadioButtonListPage.xaml
    /// </summary>
    public partial class RadioButtonListPage : Page
    {
        private readonly RadioButtonListViewModel vm = new RadioButtonListViewModel();

        public RadioButtonListPage()
        {
            InitializeComponent();
            vm.SelectedFruit = Fruits.Orange;
            DataContext = vm;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            vm.SelectedFruit = Fruits.Pear;
        }
    }

    public class RadioButtonListViewModel : INotifyPropertyChanged
    {
        private Fruits selectedFruit;

        public Fruits SelectedFruit
        {
            get { return selectedFruit; }
            set
            {
                selectedFruit = value;
                RaisePropertyChanged("SelectedFruit");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string property)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }
    }

    public enum Fruits
    {
        Apple,
        Pear,
        Orange
    } ;
}