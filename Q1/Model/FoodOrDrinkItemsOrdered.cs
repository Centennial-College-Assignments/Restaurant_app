using System.ComponentModel;


namespace Q1
{
    public class FoodOrDrinkItemsOrdered : FoodOrDrinkItem, INotifyPropertyChanged
    {
        private int itemQuantity;
        public int ItemQuantity
        {
            get
            {
                return itemQuantity;
            }
            set
            {
                itemQuantity = value;
            }
        }

        public FoodOrDrinkItemsOrdered(string foodOrDrinkName, double foodOrDrinkCost)
            : base(foodOrDrinkName, foodOrDrinkCost)
        {
            ItemQuantity = 1;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
