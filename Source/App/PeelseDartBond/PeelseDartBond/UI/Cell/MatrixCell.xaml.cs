using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using PeelseDartBond.Constants;
using PeelseDartBond.Model.Entities;
using Xamarin.Forms;

namespace PeelseDartBond.UI.Cell
{
    public partial class MatrixCell : ViewCell
    {
        public MatrixCell()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty MatrixRowProperty = BindableProperty.Create(nameof(MatrixRow), typeof(MatrixRow), typeof(MatrixCell), default(MatrixRow), propertyChanged: UpdateProperty);

        public MatrixRow MatrixRow
        {
            get { return (MatrixRow)GetValue(MatrixRowProperty); }
            set { SetValue(MatrixRowProperty, value); }
        }

        private static void UpdateProperty(BindableObject bindable, object oldValue, object newValue)
        {
            UpdateCell((MatrixCell)bindable, (MatrixRow)newValue);
        }

        //private static void UpdateCell(MatrixCell cell, MatrixRow matrixRow)
        //{
        //    var grid = new Grid();

        //    if (matrixRow == default(MatrixRow))
        //        return;

        //    double firstColumnWidth = 18;
        //    double remainingWidth = 100-firstColumnWidth;
        //    int columnCount = matrixRow.Columns.Count;
        //    double columnWidthPercentage = remainingWidth / (double)columnCount / 100;

        //    // define first row
        //    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(firstColumnWidth, GridUnitType.Star) });

        //    // define other rows, skip first
        //    for (int index = 0; index < columnCount - 1; index++)
        //    {
        //        var columnDefinition = new ColumnDefinition { Width = new GridLength(columnWidthPercentage * 100, GridUnitType.Star) };
        //        grid.ColumnDefinitions.Add(columnDefinition);
        //    }

        //    for (int index = 0; index < columnCount; index++)
        //    {
        //        var text = matrixRow.Columns[index].Contains(" - ") ? Regex.Replace(matrixRow.Columns[index], @"\s+", "") : matrixRow.Columns[index];
        //        var textColor = (index == 0 || string.IsNullOrEmpty(matrixRow.Columns[0]) || text == "X") ? Colors.Gray1 : Colors.PointsGreenBorder;
        //        var fontSize = (index == 0 || string.IsNullOrEmpty(matrixRow.Columns[0])) ? Fonts.SizePhoneS : Fonts.SizePhoneXS;
        //        var label = new Label
        //        {
        //            Text = text,
        //            TextColor = textColor,
        //            FontSize = fontSize,
        //            HorizontalOptions = LayoutOptions.Fill,
        //            VerticalOptions = LayoutOptions.FillAndExpand,
        //            HorizontalTextAlignment = index == 0 ? TextAlignment.Start : TextAlignment.Center,
        //            VerticalTextAlignment = TextAlignment.Center
        //        };
        //        grid.Children.Add(label, index, 0);
        //    }

        //    cell.View = grid;
        //}

        private static void UpdateCell(MatrixCell cell, MatrixRow matrixRow)
        {
            var grid = new Grid { WidthRequest = 800, VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };

            if (matrixRow == default(MatrixRow))
                return;

            double firstColumnWidth = 18;
            double remainingWidth = 100 - firstColumnWidth;
            int columnCount = matrixRow.Columns.Count;
            double columnWidthPercentage = remainingWidth / (double)columnCount / 100;

            // define first row
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100, GridUnitType.Star) });

            // define other rows, skip first
            for (int index = 0; index < columnCount - 1; index++)
            {
                var columnDefinition = new ColumnDefinition { Width = new GridLength(30, GridUnitType.Star) };
                grid.ColumnDefinitions.Add(columnDefinition);
            }

            for (int index = 0; index < columnCount; index++)
            {
                var text = matrixRow.Columns[index].Contains(" - ") ? Regex.Replace(matrixRow.Columns[index], @"\s+", "") : matrixRow.Columns[index];
                var textColor = (index == 0 || string.IsNullOrEmpty(matrixRow.Columns[0]) || text == "X") ? Colors.Gray1 : Colors.PointsGreenBorder;
                //var fontSize = (index == 0 || string.IsNullOrEmpty(matrixRow.Columns[0])) ? Fonts.SizePhoneS : Fonts.SizePhoneXS;
                var fontSize = (index == 0 || string.IsNullOrEmpty(matrixRow.Columns[0])) ? Fonts.SizePhoneXL : Fonts.SizePhoneL;
                var label = new Label
                {
                    Text = text,
                    TextColor = textColor,
                    FontSize = fontSize,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = index == 0 ? TextAlignment.Start : TextAlignment.Center,
                    Margin = new Thickness(4, 0),
                };
                grid.Children.Add(label, index, 0);
            }

            cell.View = grid;
        }
    }
}
