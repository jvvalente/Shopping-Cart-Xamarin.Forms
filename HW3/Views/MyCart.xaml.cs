using System;
using System.Collections.Generic;
using HW3.Model;
using HW3.ViewModel;
using HW3.Views;

using Xamarin.Forms;

namespace HW3.Views
{
    public partial class MyCart : ContentPage
    {

        MyHome myHome;
       
        public MyCart(MyHome myHome1)
        {
            InitializeComponent();
            myHome = myHome1;
            this.BindingContext = myHome;
            
        }

        private async void OnItemCartSelected(Object sender, ItemTappedEventArgs e)
        {
            
            if (e.Item is ProductByWeight)
            {
                var extra = e.Item as ProductByWeight;
                var details = e.Item as Product;

                await Navigation.PushModalAsync(new CartSelectionPage(myHome.Cart, extra, extra.getOunces(),myHome));
            }
            else if (e.Item is ProductByQuantity)
            {
                var extra = e.Item as ProductByQuantity;
                var details = e.Item as Product;

                await Navigation.PushModalAsync(new CartSelectionPage(myHome.Cart, extra, extra.getUnits(),myHome));
            }

        }


    }
}
