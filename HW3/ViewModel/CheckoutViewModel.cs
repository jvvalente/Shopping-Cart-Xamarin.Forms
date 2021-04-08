using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HW3.Model;

namespace HW3.ViewModel
{
    public class CheckoutViewModel
    {
        public List<Product> myCheckout = new List<Product>();

        public ObservableCollection<Product> CheckoutCart { get; set; }

        MyCartViewModel myCartViewModel = new MyCartViewModel();

        public double totalPrice = 0;
     
        public CheckoutViewModel()
        {
            CheckoutCart = new ObservableCollection<Product>();

            myCheckout = myCartViewModel.myCart;

            foreach(Product prod in myCheckout)
            {
                totalPrice += prod.Price;
                CheckoutCart.Add(prod);
            }

           
        }
    }
}
