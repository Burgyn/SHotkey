using EnvDTE80;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using SearchingKeyboardShortcut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MMLib.SHotkey
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class SearchingControl : UserControl
    {
        private HotKeyEditorHelper _hotKeyEditor = new HotKeyEditorHelper();
        private ViewModel.ShortcutViewModel _dataContext;

        public SearchingControl()
        {
            InitializeComponent();
            DTE2 dte = ServiceProvider.GlobalProvider.GetService(typeof(SDTE)) as DTE2;
            _dataContext = new ViewModel.ShortcutViewModel(dte);
            this.DataContext = _dataContext;
        }

        private void MyToolWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SearchTypeInfo();
            txtSearch.Focus();
            if (e.NewValue == null)
            {
                _hotKeyEditor.Detach(txtSearch);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            SearchTypeInfo();
            _dataContext.SearchingString = string.Empty;
        }

        private void SearchTypeInfo()
        {
            if (chkSearchByShortcut.IsChecked.Value)
            {
                checkText.Text = "Search by shortcut";
                chkSearchByShortcut.ToolTip = "Switch to search by name";
                _hotKeyEditor.Attach(txtSearch);
                checkedImg.Visibility = System.Windows.Visibility.Visible;
                uncheckedImg.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                checkText.Text = "Search by name";
                chkSearchByShortcut.ToolTip = "Switch to search by shortcut";
                _hotKeyEditor.Detach(txtSearch);
                checkedImg.Visibility = System.Windows.Visibility.Collapsed;
                uncheckedImg.Visibility = System.Windows.Visibility.Visible;
            }
        }

        public void FocusSearchingBox()
        {
            txtSearch.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _dataContext.OpenSettings();
        }

        private void DataGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Down && e.Key != Key.Up)
            {
                txtSearch.Focus();
                txtSearch.SelectionStart = 1;
                txtSearch.SelectionLength = 0;
            }
        }

        private void txtSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down && dataGrid.SelectedIndex < _dataContext.ItemsSource.Count - 1)
            {
                dataGrid.SelectedIndex++;
            }
            else if (e.Key == Key.Up && dataGrid.SelectedIndex > 0)
            {
                dataGrid.SelectedIndex--;
            }
        }
    }
}