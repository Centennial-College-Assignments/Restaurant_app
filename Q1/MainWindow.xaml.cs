using System.Diagnostics;
using System.Linq;
using System.Windows;

namespace Q1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void ComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // If no item is selected then return
            if (e.AddedItems.Count == 0)
            {
                return;
            }

            ViewModel dataContext = DataContext as ViewModel;
            // Selected item
            FoodOrDrinkItem foodOrDrinkItem = e.AddedItems[0] as FoodOrDrinkItem;
            
            if (dataContext.OrderedItemsList.Contains(foodOrDrinkItem))
            {
                var orderItem = dataContext.OrderedItemsList.Single(o => o.FoodItemName == foodOrDrinkItem.FoodItemName);
                orderItem.ItemQuantity++;
            }else
            {
                dataContext.OrderedItemsList.Add(new FoodOrDrinkItemsOrdered(foodOrDrinkItem.FoodItemName, foodOrDrinkItem.FoodItemCost));
            }

            dataContext.CalculateBillAmounts();
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext as ViewModel;
            dataContext.Reset();
            dataContext.OrderedItemsList.Clear();
            BeveragesComboBox.SelectedItem = null;
            AppetizerComboBox.SelectedItem = null;
            MainCourseComboBox.SelectedItem = null;
            DessertComboBox.SelectedItem = null;
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.ToString()) { UseShellExecute = true });
        }
    }
}