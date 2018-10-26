using System;

using MemoryTest.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace MemoryTest.Views
{
    public sealed partial class TabbedPage : Page
    {
        public TabbedViewModel ViewModel => DataContext as TabbedViewModel;

        public TabbedPage()
        {
            InitializeComponent();
            NavigationCacheMode = NavigationCacheMode.Enabled;
            DataContext = new TabbedViewModel();

            ViewModel.CloseRequired += ViewModel_CloseRequired;
            ViewModel.AddRequired += ViewModel_AddRequired;
        }

        private void ViewModel_CloseRequired()
        {
            if (PivotField?.Items == null
                || PivotField.Items.Count == 0)
                return;

            PivotItem pivotItem = PivotField.SelectedItem as PivotItem;

            if (pivotItem != null
                && PivotField.Items.Contains(pivotItem))
            {
                PivotField.Items.Remove(pivotItem);
                pivotItem = null;
            }

        }

        private void ViewModel_AddRequired()
        {
            PivotItem pivotItem = new PivotItem();
            pivotItem.Header = "Item " + (PivotField.Items.Count + 1).ToString();

            SamplePage page = new SamplePage();
            page.DataContext = ViewModel;
            pivotItem.Content = page;

            PivotField.Items.Add(pivotItem);

            page = null;
            pivotItem = null;
        }

    }
}
