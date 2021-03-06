﻿#region Copyright Syncfusion Inc. 2001 - 2015
// Copyright Syncfusion Inc. 2001 - 2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Windows;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Windows.Input;
using Syncfusion.Windows.Shared;

namespace SfDataGridDemo
{
    public static class Commands
    {
        static Commands()
        {
            CommandManager.RegisterClassCommandBinding(typeof(SfDataGrid), new CommandBinding(PrintPreview, OnPrintGrid));
        }

        #region Print Preview Command

        public static RoutedCommand PrintPreview = new RoutedCommand("PrintPreview", typeof (SfDataGrid));

        //Print the content of Grid
        private static void OnPrintGrid(object sender, ExecutedRoutedEventArgs args)
        {
            var dataGrid = args.Source as SfDataGrid;
            if (dataGrid == null) return;
            try
            {
                var window = new PreviewWindow
                    {
                        WindowStartupLocation = WindowStartupLocation.CenterScreen,
                    };
                SkinStorage.SetEnableOptimization(window, false);
                SkinStorage.SetVisualStyle(window, "Metro");

                //Call the new CustomPrintManager class
                window.PrintPreviewArea.PrintManagerBase = new CustomPrintManager(dataGrid);
                window.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        #endregion
    }
}
