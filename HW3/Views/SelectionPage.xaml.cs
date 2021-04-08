using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HW3.Model;
using HW3.ViewModel;
using Xamarin.Forms;

namespace HW3.Views
{
    public partial class SelectionPage : ContentPage
    {

        MyCartViewModel myCartViewModel = new MyCartViewModel();
        ObservableCollection<Product> pr;
        MyHome Home;
        Product chicken = new ProductByWeight(12.50, 75, "Chicken Breast", "Produce", 0016);
        public ObservableCollection<Product> Cart1 { get; set; }
        Product prod;

        public SelectionPage(string Name, double Price, string Description, int ID, double units_ounces, Product product, ObservableCollection<Product> p, MyHome home)
        {
            InitializeComponent();

            testName.Text = product.Name;
            testPrice.Text = "Price: $" + product.PriceSingle;
            testInventory.Text = "Inventory: " + units_ounces.ToString();
            testDescription.Text = Description;
            slider.Minimum = 1;
            slider.Maximum = units_ounces;
            sliderNumber.Text = "Value: 1";
            pr = p;
            Home = home;

            prod = product;
            

        }

        private void slider_changed(object sender, ValueChangedEventArgs e)
        {
            var newStep = Math.Round(e.NewValue / 1.0);

            slider.Value = newStep * 1.0;
            sliderNumber.Text = "Value: " + slider.Value;
        }

        private async void addButton_clicked(Object sender, System.EventArgs e)
        {
            string str = sliderNumber.Text;
            var result = str.Substring(str.LastIndexOf(" ") + 1);

            var addProduct = new Product();

            if(prod is ProductByQuantity)
            {
                ProductByQuantity temp = prod as ProductByQuantity;
                ProductByQuantity addProduct1 = new ProductByQuantity(temp.getUnitPrice(), (int)slider.Value, temp.Name, temp.Description, temp.ID);
                
                if (productInCart(addProduct1) != -1)
                {
                    adjust((int)slider.Value);
                    Product temp1 = Home.Cart[productInCart(addProduct1)];
                    (temp1 as ProductByQuantity).addUnits((int)slider.Value);
                    Home.Cart[productInCart(addProduct1)] = temp1;
                }
                else
                {
                    adjust((int)slider.Value);
                    Home.Cart.Add(addProduct1);
                }
            }
            else
            {
                ProductByWeight temp = prod as ProductByWeight;
                ProductByWeight addProduct1 = new ProductByWeight(temp.getPricePerOunce(), (int)slider.Value, temp.Name, temp.Description, temp.ID);
                
                if (productInCart(addProduct1) != -1)
                {
                    adjust((int)slider.Value);
                    Product temp1 = Home.Cart[productInCart(addProduct1)];
                    (temp1 as ProductByQuantity).addUnits((int)slider.Value);
                    Home.Cart[productInCart(addProduct1)] = temp1;
                }
                else
                {
                    adjust((int)slider.Value);
                    Home.Cart.Add(addProduct1);
                }

            }

            //Home.checkout.update();
            
        }

        private async void backButton_clicked(Object sender, System.EventArgs e){ Navigation.PopModalAsync(); }

        private int productInCart(Product prod)
        {

            int count = 0;

            foreach (Product item in Home.Cart)
            {
                if (item.Name == prod.Name) { return count; }
                count += 1;
            }

            return -1;

        }

        private bool adjust(int items)
        {
            if(prod is ProductByQuantity)
            {
                 if((prod as ProductByQuantity).editUnits(items)) {
                    if ((prod as ProductByQuantity).getUnits() == 0){
                        slider.Minimum = 0;
                        Home.ProductInventory.Remove(prod);
                        Navigation.PopModalAsync();
                        return true;
                    }
                    slider.Maximum = (prod as ProductByQuantity).getUnits();
                    testInventory.Text = "Inventory: " + (prod as ProductByQuantity).getUnits().ToString();
                    return true;
                }
            }
            else
            {
                if((prod as ProductByWeight).editOunces(items)) {
                    slider.Maximum = (prod as ProductByWeight).getOunces();
                    if ((prod as ProductByWeight).getOunces() == 0) {
                        slider.Minimum = 0;
                        Home.ProductInventory.Remove(prod);
                        Navigation.PopModalAsync();
                        return true;
                    }
                    testInventory.Text = "Inventory: " + (prod as ProductByWeight).getOunces().ToString();
                    return true;
                }
            }

            return false;
        }
    }
}
