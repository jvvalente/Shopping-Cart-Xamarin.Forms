using System;
using System.Collections;
using System.Collections.Generic;
using HW3.ViewModel;
using HW3.Model;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace HW3.Views
{
    public partial class MyHome : ContentPage
    {

        public ObservableCollection<Product> ProductInventory { get; set; }
        public ObservableCollection<Product> Cart { get; set; }

        //public Checkout checkout;

        Product jello = new ProductByQuantity(1.00, 3, "Jello", "Canned & Packaged Foods", 0001);

        public MyHome()
        {
            InitializeComponent();

            //checkout = checkout1;

            ProductInventory = new ObservableCollection<Product>();
            Cart = new ObservableCollection<Product>();

            BindingContext = new ProductViewModel(ProductInventory);

            Cart = new ObservableCollection<Product>();
            Cart.Add(jello);
           
        }

        private async void OnItemSelected(Object sender, ItemTappedEventArgs e)
        {

            
            if (e.Item is ProductByWeight)
            {
                var extra = e.Item as ProductByWeight;
                var details = e.Item as Product;

                await Navigation.PushModalAsync(new SelectionPage(details.Name, details.Price, details.Description, details.ID, extra.getOunces(), extra, Cart, this));
            }
            else if(e.Item is ProductByQuantity)
            {
                var extra = e.Item as ProductByQuantity;
                var details = e.Item as Product;

                await Navigation.PushModalAsync(new SelectionPage(details.Name, details.Price, details.Description, details.ID, extra.getUnits(), extra, Cart, this));
            }

        }    

    };

}
