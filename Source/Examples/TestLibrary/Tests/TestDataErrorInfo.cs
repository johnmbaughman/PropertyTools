﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TestDataErrorInfo.cs" company="PropertyTools">
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
// --------------------------------------------------------------------------------------------------------------------
namespace TestLibrary
{
    using System.ComponentModel;
    using System.Windows.Markup;

    using PropertyTools.DataAnnotations;

    public class TestDataErrorInfo : TestBase, IDataErrorInfo
    {
        [AutoUpdateText]
        [Description("Should not be empty.")]
        public string Name { get; set; }

        [AutoUpdateText]
        [Description("Should be larger or equal to zero.")]
        public int Age { get; set; }

        [DependsOn("Honey")]
        public bool CondensedMilk { get; set; }

        [DependsOn("CondensedMilk")]
        public bool Honey { get; set; }

        [Browsable(false)]
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "Name": return string.IsNullOrEmpty(Name) ? "Name is empty." : null;
                    case "Age": return Age < 0 ? "Age less than 0." : null;
                    case "CondensedMilk":
                    case "Honey":
                        return CondensedMilk && Honey ? "You cannot have both condensed milk and honey!" : null;
                }
                return null;
            }
        }

        [Browsable(false)]
        string IDataErrorInfo.Error
        {
            get
            {
                if (Name == "") return "Name is empty!";
                if (Age < 0) return "Age is less than 0!";
                if (CondensedMilk && Honey) return "You cannot have both condensed milk and honey!";
                return null;
            }
        }

        public TestDataErrorInfo()
        {
            Name = "Mike";
            Age = 3;
        }

        public override string ToString()
        {
            return "IDataErrorInfo";
        }
    }
}