﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PopupBox.cs" company="PropertyTools">
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
//   Represents a popup control that provides a data template for the popup.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace PropertyTools.Wpf
{
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Represents a popup control that provides a data template for the popup.
    /// </summary>
    public class PopupBox : ComboBox
    {
        /// <summary>
        /// The popup template property.
        /// </summary>
        public static readonly DependencyProperty PopupTemplateProperty = DependencyProperty.Register(
            "PopupTemplate", typeof(DataTemplate), typeof(PopupBox), new UIPropertyMetadata(null));

        /// <summary>
        /// Initializes static members of the <see cref = "PopupBox" /> class.
        /// </summary>
        static PopupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PopupBox), new FrameworkPropertyMetadata(typeof(PopupBox)));
        }

        /// <summary>
        /// Gets or sets the popup template.
        /// </summary>
        /// <value>The popup template.</value>
        public DataTemplate PopupTemplate
        {
            get
            {
                return (DataTemplate)this.GetValue(PopupTemplateProperty);
            }

            set
            {
                this.SetValue(PopupTemplateProperty, value);
            }
        }

    }
}