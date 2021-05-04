using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Q1
{
    public class FoodOrDrinkItem
    {

        public string FoodItemName { get; set; }
        public double FoodItemCost { get; set; }

        public FoodOrDrinkItem(string itemName, double itemCost)
        {
            FoodItemName = itemName;
            FoodItemCost = itemCost;
        }

        public override bool Equals(object obj)
        {
            return obj is FoodOrDrinkItem item &&
                   FoodItemName == item.FoodItemName &&
                   FoodItemCost == item.FoodItemCost;
        }
    }

}