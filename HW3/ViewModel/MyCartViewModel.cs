using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using HW3.Model;
using Xamarin.Forms;

namespace HW3.ViewModel
{
    public class MyCartViewModel 
    {

        public List<Product> myCart = new List<Product>();

        
        public ObservableCollection<Product> Cart { get; set; }

        Product jello = new ProductByQuantity(1.00, 3, "Jello", "Canned & Packaged Foods", 0001);
        Product mayonnaise = new ProductByQuantity(2.00, 1, "Mayonnaise", "Canned & Packaged Foods", 0003);
        Product chocolate = new ProductByQuantity(5.00, 2, "Chocolate bar", "Canned & Packaged Foods", 0004);
        Product tomatoes = new ProductByWeight(4.25, 1, "Tomato", "Produce", 0013);
        Product beef = new ProductByWeight(15.75, 1, "Beef", "Produce", 0014);
        Product lemons = new ProductByWeight(3.50, 2, "Lemon", "Produce", 0015);

        public MyCartViewModel()
        {
            
            //myCart.Add(jello);

            Cart = new ObservableCollection<Product>();

            myCart.Add(jello);
            myCart.Add(mayonnaise);
            myCart.Add(chocolate);
            myCart.Add(tomatoes);
            myCart.Add(lemons);
            myCart.Add(beef);

            foreach (Product prod in myCart)
            {
                if (prod is ProductByQuantity)
                {
                    if (((ProductByQuantity)prod).getUnits() > 0)
                    {
                        Cart.Add(prod);
                    }
                }
                else if (prod is ProductByWeight)
                {
                    if (((ProductByWeight)prod).getOunces() > 0)
                    {
                        Cart.Add(prod);
                    }
                }
            }

            addtolist();
            
        }

        public void addtolist()
        {
            Cart.Add(jello);
        }

        
    }
}
