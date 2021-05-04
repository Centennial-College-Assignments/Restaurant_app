using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Q1
{
    public class ViewModel : INotifyPropertyChanged
    {
        // Properties with event rasing upon property change

        private double totalBeforeTax;

        public double TotalBeforeTax
        {
            get { return totalBeforeTax; }
            set
            {
                totalBeforeTax = value;
                RaisePropertyChanged(nameof(TotalBeforeTax));
            }
        }

        private double taxAmount;

        public double TaxAmount
        {
            get { return taxAmount; }
            set
            {
                taxAmount = value;
                RaisePropertyChanged(nameof(TaxAmount));
            }
        }

        private double totalWithTax;

        public double TotalWithTax
        {
            get { return totalWithTax; }
            set
            {
                totalWithTax = value;
                RaisePropertyChanged(nameof(TotalWithTax));
            }
        }

        //Collections to hold Food Items data
        public ObservableCollection<FoodOrDrinkItem> Beverages { get; set; }

        public ObservableCollection<FoodOrDrinkItem> MainCourse { get; set; }

        public ObservableCollection<FoodOrDrinkItem> Appetizer { get; set; }

        public ObservableCollection<FoodOrDrinkItem> Dessert { get; set; }

        public ObservableCollection<FoodOrDrinkItemsOrdered> OrderedItemsList { get; set; }


        //Constructor
        public ViewModel()
        {
           
            Beverages = new ObservableCollection<FoodOrDrinkItem>()
                {
                new FoodOrDrinkItem("Soda", 1.95),
                new FoodOrDrinkItem("Tea", 1.50),
                new FoodOrDrinkItem("Coffee", 1.25),
                new FoodOrDrinkItem("Mineral Water", 2.95),
                new FoodOrDrinkItem("Juice", 2.50),
                new FoodOrDrinkItem("Milk", 1.50)
                };

            MainCourse = new ObservableCollection<FoodOrDrinkItem>()
                {
                new FoodOrDrinkItem("Chicken Alfredo", 13.95),
                new FoodOrDrinkItem("Chicken Picatta", 13.95),
                new FoodOrDrinkItem("Turkey Club", 11.95),
                new FoodOrDrinkItem("Lobster Pie", 19.95),
                new FoodOrDrinkItem("Prime Rib", 20.95),
                new FoodOrDrinkItem("Shrimp Scampi", 18.95),
                new FoodOrDrinkItem("Turkey Dinner", 13.95),
                new FoodOrDrinkItem("Stuffed Chicken", 14.95)
                };

            Appetizer = new ObservableCollection<FoodOrDrinkItem>()
                {
                new FoodOrDrinkItem("Buffalo Wings", 5.95),
                new FoodOrDrinkItem("Buffalo Fingers", 6.95),
                new FoodOrDrinkItem("Potato Skins", 8.95),
                new FoodOrDrinkItem("Nachos", 8.95),
                new FoodOrDrinkItem("Mushroom Caps", 10.95),
                new FoodOrDrinkItem("Chips and Salsa", 6.95)
                };

            Dessert = new ObservableCollection<FoodOrDrinkItem>()
                {
                new FoodOrDrinkItem("Apple Pie", 5.95),
                new FoodOrDrinkItem("Sundae", 3.95),
                new FoodOrDrinkItem("Carrot Cake", 5.95),
                new FoodOrDrinkItem("Mud Pie", 4.95),
                new FoodOrDrinkItem("Apple Crisp", 5.95)
                };

            OrderedItemsList = new ObservableCollection<FoodOrDrinkItemsOrdered>();
        }

        //To calculate the total
        public void CalculateBillAmounts()
        {
            TotalBeforeTax = 0;
            TaxAmount = 0;
            TotalWithTax = 0;

            foreach (var item in OrderedItemsList)
            {
                TotalBeforeTax = Math.Round((TotalBeforeTax +  item.FoodItemCost * item.ItemQuantity),2);
            }

            TaxAmount = Math.Round((TotalBeforeTax * 0.13),2);

            TotalWithTax = Math.Round((TotalBeforeTax + TaxAmount),2);
        }

        //When clearbill button is clicked, Total Amounts and tax amount is set to Zero

        public void Reset()
        {
            TotalBeforeTax = 0;
            TaxAmount = 0;
            TotalWithTax = 0;
            OrderedItemsList.Clear();
            
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

