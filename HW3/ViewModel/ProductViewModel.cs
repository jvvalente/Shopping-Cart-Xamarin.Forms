using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using HW3.Model;
using Xamarin.Forms;


namespace HW3.ViewModel
{
    public class ProductViewModel
    {
        public ObservableCollection<Product> ProductInventory { get; set; }
        public List<Product> Inventory = new List<Product>();
        public List<ProductByQuantity> InventoryByQuantity;
        public List<ProductByWeight> InventoryByWeight;
        public ObservableCollection<Product> Cart { get; set; }
        public List<Product> cart = new List<Product>();

        ReadWriteJSON readWriteJSON = new ReadWriteJSON();

        public ProductViewModel(ObservableCollection<Product> ProductInventory1)
        {

            /*var jello = new ProductByQuantity(1.00, 10, "Jello", "Canned & Packaged Foods", 0001);
            var ketchup = new ProductByQuantity(2.00, 20, "Ketchup", "Canned & Packaged Foods", 0002);
            var mayonnaise = new ProductByQuantity(2.00, 35, "Mayonnaise", "Canned & Packaged Foods", 0003);
            var chocolate = new ProductByQuantity(5.00, 25, "Chocolate bar", "Canned & Packaged Foods", 0004);
            var paperTowels = new ProductByQuantity(3.50, 100, "Paper Towels", "Miscellaneous Kitchen Items", 0005);
            var plasticWrap = new ProductByQuantity(2.35, 80, "Plastic Wrap", "Miscellaneous Kitchen Items", 0006);
            var yougurt = new ProductByQuantity(1.50, 90, "Yougurt", "Refrigerated Foods", 0007);
            var bagels = new ProductByQuantity(1.25, 150, "Bagels", "Bakery", 0008);
            var bread = new ProductByQuantity(1.00, 200, "Bread", "Bakery", 0009);
            var cereal = new ProductByQuantity(3.50, 45, "Cereal", "Breakfast", 0010);

            var bacon = new ProductByWeight(10.50, 130, "Bacon", "Refrigerated Foods", 0011);
            var oranges = new ProductByWeight(5.50, 150, "Orange", "Produce", 0012);
            var tomatoes = new ProductByWeight(4.25, 100, "Tomato", "Produce", 0013);
            var beef = new ProductByWeight(15.75, 200, "Beef", "Produce", 0014);
            var lemons = new ProductByWeight(3.50, 100, "Lemon", "Produce", 0015);
            var chicken = new ProductByWeight(12.50, 75, "Chicken Breast", "Produce", 0016);
            var cheese = new ProductByWeight(10.00, 150, "Cheese", "Refrigerated foods", 0017);
            var apples = new ProductByWeight(3.50, 100, "Apple", "Produce", 0018);
            var carrot = new ProductByWeight(3.00, 200, "Carrot", "Produce", 0019);
            var lettuce = new ProductByWeight(20.00, 1000, "lettuce", "Produce", 0020);

            Inventory.Add(jello); Inventory.Add(ketchup); Inventory.Add(mayonnaise); Inventory.Add(chocolate);
            Inventory.Add(paperTowels); Inventory.Add(plasticWrap); Inventory.Add(yougurt); Inventory.Add(bagels);
            Inventory.Add(bread); Inventory.Add(cereal); Inventory.Add(bacon); Inventory.Add(oranges);
            Inventory.Add(tomatoes); Inventory.Add(beef); Inventory.Add(lemons); Inventory.Add(chicken);
            Inventory.Add(cheese); Inventory.Add(apples); Inventory.Add(carrot); Inventory.Add(lettuce);*/

            readWriteJSON.write();
            InventoryByQuantity = readWriteJSON.readByQuantity();
            InventoryByWeight = readWriteJSON.ReadByWeight();
           
            foreach(ProductByQuantity x in InventoryByQuantity)
            {
                ProductByQuantity prod = new ProductByQuantity(x.PriceSingle, x.Number, x.Name, x.Description, x.ID);
                Inventory.Add(prod);
            }

            foreach (ProductByWeight x in InventoryByWeight)
            {
                ProductByWeight prod = new ProductByWeight(x.PriceSingle, x.Number, x.Name, x.Description, x.ID);
                Inventory.Add(prod);
            }


            ProductInventory = ProductInventory1;

            foreach(Product prod in Inventory)
            {
                if(prod is ProductByQuantity)
                {
                    if(((ProductByQuantity)prod).getUnits() > 0)
                    {
                        ProductInventory.Add(prod);
                    }
                }
                else if(prod is ProductByWeight)
                {
                    if(((ProductByWeight)prod).getOunces() > 0)
                    {
                        ProductInventory.Add(prod);
                    }
                }
            }

        }
    }
}
