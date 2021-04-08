using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using HW3.Model;

namespace HW3.Views
{
    public partial class CartSelectionPage : ContentPage
    {
        ObservableCollection<Product> pr;
        Product prod;
        MyHome Home;

        public CartSelectionPage(ObservableCollection<Product> p, Product product, double number, MyHome home)
        {
            InitializeComponent();

            cartName.Text = product.Name;
            cartPrice.Text = "Price: $" + product.PriceSingle;
            onCart.Text = "On cart: " + number.ToString();
            cartDescription.Text = product.Description;
            sliderC.Minimum = 1;
            sliderC.Maximum = (int)number; 
            sliderCart.Text = "Selected: 1";
            pr = p;
            prod = product;
            Home = home;

        }

        private void slidercart_changed(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 1.0);

            sliderC.Value = newStep * 1.0;
            sliderCart.Text = "Value: " + sliderC.Value;
        }

        private async void removeButton_clicked(Object sender, System.EventArgs e)
        {
            string str = sliderCart.Text;
            var result = str.Substring(str.LastIndexOf(" ") + 1);

            var addProduct = new Product();

            if (prod is ProductByQuantity)
            {
                ProductByQuantity temp = prod as ProductByQuantity;
                ProductByQuantity addProduct1 = new ProductByQuantity(temp.getUnitPrice(), (int)sliderC.Value, temp.Name, temp.Description, temp.ID);
               
                if (productInInventory(addProduct1) != -1)
                {
                    adjust((int)sliderC.Value);
                    Product temp1 = Home.ProductInventory[productInInventory(addProduct1)];
                    (temp1 as ProductByQuantity).addUnits((int)sliderC.Value);
                    Home.ProductInventory[productInInventory(addProduct1)] = temp1;
                }
                else
                {
                    adjust((int)sliderC.Value);
                    Home.ProductInventory.Add(addProduct1);
                }
                
                
            }
            else
            {
                ProductByWeight temp = prod as ProductByWeight;
                ProductByWeight addProduct1 = new ProductByWeight(temp.getPricePerOunce(), (int)sliderC.Value, temp.Name, temp.Description, temp.ID);
                pr.Add(addProduct1);

                if (productInInventory(addProduct1) != -1)
                {
                    adjust((int)sliderC.Value);
                    Product temp1 = Home.ProductInventory[productInInventory(addProduct1)];
                    (temp1 as ProductByWeight).addOunces((int)sliderC.Value);
                    Home.ProductInventory[productInInventory(addProduct1)] = temp1;
                }
                else
                {
                    adjust((int)sliderC.Value);
                    Home.ProductInventory.Add(addProduct1);
                }
            }


            //Home.checkout.update();

        }

        private async void backCartButton_clicked(Object sender, System.EventArgs e) { Navigation.PopModalAsync(); }

        private int productInInventory(Product prod) {

            int count = 0;

            foreach(Product item in Home.ProductInventory)
            {
                if(item.Name == prod.Name) { return count; }
                count += 1;
            }

            return -1;
             
        }

        private bool adjust(int items)
        {
            if (prod is ProductByQuantity)
            {
                if ((prod as ProductByQuantity).editUnits(items))
                {
                    if ((prod as ProductByQuantity).getUnits() == 0)
                    {
                        sliderC.Minimum = 0;
                        Home.Cart.Remove(prod);
                        Navigation.PopModalAsync();
                        return true;
                    }
                    sliderC.Maximum = (prod as ProductByQuantity).getUnits();
                    onCart.Text = "On cart: " + (prod as ProductByQuantity).getUnits().ToString();
                    return true;
                }
            }
            else
            {
                if ((prod as ProductByWeight).editOunces(items))
                {
                    sliderC.Maximum = (prod as ProductByWeight).getOunces();
                    if ((prod as ProductByWeight).getOunces() == 0)
                    {
                        sliderC.Minimum = 0;
                        Home.Cart.Remove(prod);
                        Navigation.PopModalAsync();
                        return true;
                    }
                    onCart.Text = "On cart: " + (prod as ProductByWeight).getOunces().ToString();
                    return true;
                }
            }

            return false;
        }
    }
}
