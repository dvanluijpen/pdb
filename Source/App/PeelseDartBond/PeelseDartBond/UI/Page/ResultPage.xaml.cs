using System;
using System.Collections.Generic;
using PeelseDartBond.ViewModel;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Page
{
    public partial class ResultPage : ContentPage
    {
        ResultVM _vm;

        public ResultPage(string url)
        {
            InitializeComponent();

            _vm = new ResultVM(url);
            BindingContext = _vm;
        }

        public ResultVM ViewModel { get { return _vm; } }
    }
}
