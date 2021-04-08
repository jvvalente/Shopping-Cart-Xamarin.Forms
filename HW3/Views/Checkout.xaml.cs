using System;
using System.Collections.Generic;
using HW3.Model;
using HW3.ViewModel;
using Xamarin.Forms;

namespace HW3.Views
{
    public partial class Checkout : ContentPage
    {
        MyHome myHome;
        private double totalPrice = 0;
        public Checkout(MyHome myHome1)
        {
            InitializeComponent();
            myHome = myHome1;
            this.BindingContext = myHome;
        
            foreach(Product prod in myHome1.Cart) { totalPrice += prod.Price; }

            total.Text = String.Format("Total: {0:0.00}", (totalPrice).ToString());
            tax.Text = String.Format("Total: {0:0.00}", (totalPrice * 0.07).ToString());
            totalTax.Text = String.Format("Total: {0:0.00}", (totalPrice * 1.07).ToString());

        }

        public void update()
        {
            total.Text = String.Format("Total: {0:0.00}", (totalPrice).ToString());
            tax.Text = String.Format("Total: {0:0.00}", (totalPrice * 0.07).ToString());
            totalTax.Text = String.Format("Total: {0:0.00}", (totalPrice * 1.07).ToString());
        }
    }
}
