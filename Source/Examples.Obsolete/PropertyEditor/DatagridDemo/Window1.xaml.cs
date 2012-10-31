﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Window1.xaml.cs" company="PropertyTools">
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
//   Interaction logic for Window1.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using PropertyTools.Wpf;

namespace DatagridDemo
{
    using PropertyTools;
    using PropertyTools.DataAnnotations;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            MyCollection = new CarCollection();
            DataContext = this;
        }

        public CarCollection MyCollection { get; set; }
    }

    public class CarCollection
    {
        public CarCollection()
        {
            Cars = new ObservableCollection<Car>();

            // http://gadgetophilia.com/10-best-environment-friendly-cars-green-cars-in-2010/

            Cars.Add(new Car
                         {
                             Make = "Chevrolet",
                             Model = "Volt 230",
                             Fuel = FuelTypes.Hybrid,
                             Price = 40000,
                             Image = "http://gadgetophilia.com/wp-content/uploads/2010/02/2010-chevy-volt.jpg"
                         });
            Cars.Add(new Car
                         {
                             Make = "Toyota",
                             Model = "Prius",
                             Fuel = FuelTypes.Hybrid,
                             Price = 22000,
                             Image = "http://gadgetophilia.com/wp-content/uploads/2010/02/prius-toyota-2010.jpg"
                         });
            Cars.Add(new Car
                         {
                             Make = "Honda",
                             Model = "Insight",
                             Fuel = FuelTypes.Hybrid,
                             Price = 20000,
                             Image = "http://gadgetophilia.com/wp-content/uploads/2010/02/2010_honda_insight.jpg"
                         });
            Cars.Add(new Car
                         {
                             Make = "Ford",
                             Model = "Fusion",
                             Fuel = FuelTypes.Hybrid,
                             Price = 31500,
                             Image = "http://gadgetophilia.com/wp-content/uploads/2010/02/ford-fusion-hybrid.jpg"
                         });
        }

        [WideProperty]
        public ObservableCollection<Car> Cars { get; private set; }
    }

    public enum FuelTypes
    {
        Electric,
        Hybrid,
        Diesel,
        Petrol, // or Gasoline
        BioDiesel,
        NaturalGas,
        Hydrogen
    }

    public class Car : INotifyPropertyChanged
    {
        private FuelTypes fuel;
        private string image;
        private bool isAvailable;
        private string make;

        private string model;
        private double price;

        public string Make
        {
            get { return make; }
            set
            {
                make = value;
                RaisePropertyChanged("Make");
                RaisePropertyChanged(null);
            }
        }

        public string Model
        {
            get { return model; }
            set
            {
                model = value;
                RaisePropertyChanged("Model");
                RaisePropertyChanged(null);
            }
        }

        public FuelTypes Fuel
        {
            get { return fuel; }
            set
            {
                fuel = value;
                RaisePropertyChanged("Fuel");
            }
        }

        public bool IsAvailable
        {
            get { return isAvailable; }
            set
            {
                isAvailable = value;
                RaisePropertyChanged("IsAvailable");
            }
        }

        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                RaisePropertyChanged("Price");
            }
        }

        public string Image
        {
            get { return image; }
            set
            {
                image = value;
                RaisePropertyChanged("Image");
            }
        }

        public override string ToString()
        {
            return Make + " " + Model;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string property)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(property));
            }
        }

    }
}