using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.IO.IsolatedStorage;

namespace HW3.Model
{
    public class ReadWriteJSON
    {
        public ReadWriteJSON()
        {
        }

        public void write()
        {
            List<Product> toSerialize = new List<Product>();
            List<Product> toSerialize1 = new List<Product>();

            Console.WriteLine("Creating");

            var jello = new ProductByQuantity(1.00, 10, "Jello", "Canned & Packaged Foods", 0001);
            var ketchup = new ProductByQuantity(2.00, 20, "Ketchup", "Canned & Packaged Foods", 0002);
            var mayonnaise = new ProductByQuantity(2.00, 35, "Mayonnaise", "Canned & Packaged Foods", 0003);
            var chocolate = new ProductByQuantity(5.00, 25, "Chocolate bar", "Canned & Packaged Foods", 0004);
            var paperTowels = new ProductByQuantity(3.50, 100, "Paper Towels", "Miscellaneous Kitchen Items", 0005);
            var plasticWrap = new ProductByQuantity(2.35, 80, "Plastic Wrap", "Miscellaneous Kitchen Items", 0006);
            var yougurt = new ProductByQuantity(1.50, 90, "Yougurt", "Refrigerated Foods", 0007);
            var bagels = new ProductByQuantity(1.25, 150, "Bagels", "Bakery", 0008);
            var bread = new ProductByQuantity(1.00, 200, "Bread", "Bakery", 0009);
            var cereal = new ProductByQuantity(3.50, 45, "Cereal", "Breakfast", 0010);

            var bacon = new ProductByWeight(10.50, 100, "Bacon", "Refrigerated Foods", 0011);
            var oranges = new ProductByWeight(5.50, 150, "Orange", "Produce", 0012);
            var tomatoes = new ProductByWeight(4.25, 100, "Tomato", "Produce", 0013);
            var beef = new ProductByWeight(15.75, 200, "Beef", "Produce", 0014);
            var lemons = new ProductByWeight(3.50, 100, "Lemon", "Produce", 0015);
            var chicken = new ProductByWeight(12.50, 75, "Chicken Breast", "Produce", 0016);
            var cheese = new ProductByWeight(10.00, 150, "Cheese", "Refrigerated foods", 0017);
            var apples = new ProductByWeight(3.50, 100, "Apple", "Produce", 0018);
            var carrot = new ProductByWeight(3.00, 200, "Carrot", "Produce", 0019);
            var lettuce = new ProductByWeight(20.00, 1000, "lettuce", "Produce", 0020);

            toSerialize.Add(jello); toSerialize.Add(ketchup); toSerialize.Add(mayonnaise); toSerialize.Add(chocolate);
            toSerialize.Add(paperTowels); toSerialize.Add(plasticWrap); toSerialize.Add(yougurt); toSerialize.Add(bagels);
            toSerialize.Add(bread); toSerialize.Add(cereal); toSerialize1.Add(bacon); toSerialize1.Add(oranges);
            toSerialize1.Add(tomatoes); toSerialize1.Add(beef); toSerialize1.Add(lemons); toSerialize1.Add(chicken);
            toSerialize1.Add(cheese); toSerialize1.Add(apples); toSerialize1.Add(carrot); toSerialize1.Add(lettuce);

            String inventorySerializeByQuantity = JsonConvert.SerializeObject(toSerialize);
            String inventorySerializeByWeight = JsonConvert.SerializeObject(toSerialize1);

            Console.WriteLine("Serialize" + inventorySerializeByQuantity);

            string fileNameByQuantity = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serializedByQuantity.txt");
            string fileNameByWeight = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serializedByWeight.txt");

            File.WriteAllText(fileNameByQuantity, inventorySerializeByQuantity);
            File.WriteAllText(fileNameByWeight, inventorySerializeByWeight);

            //TODO HAV TO SEPARATE THIS BY PRODUCT TYPE

        }

        public List<ProductByQuantity> readByQuantity()
        {
            List<ProductByQuantity> Inventory = new List<ProductByQuantity>();

            //write();

            string fileNameByQuantity = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serializedByQuantity.txt");

            if (File.Exists(fileNameByQuantity))
            {
                Inventory = JsonConvert.DeserializeObject<List<ProductByQuantity>>(File.ReadAllText(fileNameByQuantity));
                Console.WriteLine("Hello12345");
                foreach (Product x in Inventory)
                    Console.WriteLine(x.Name);
                return Inventory;
            }
            else
                Console.WriteLine("Not yet");


            return Inventory;
        }

        public List<ProductByWeight> ReadByWeight()
        {
            List<ProductByWeight> Inventory = new List<ProductByWeight>();

            //write();

            string fileNameByWeight = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "serializedByWeight.txt");

            if (File.Exists(fileNameByWeight))
            {
                Inventory = JsonConvert.DeserializeObject<List<ProductByWeight>>(File.ReadAllText(fileNameByWeight));
                Console.WriteLine("Hello12345");
                foreach (Product x in Inventory)
                    Console.WriteLine(x.Name);
                return Inventory;
            }
            else
                Console.WriteLine("Not yet");

            

            return Inventory;
        }
    }
}
