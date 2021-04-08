using System;
namespace HW3.Model
{
    public class Product
    {
        public virtual double Price { get; set; }
        public string Name { get; set; }
        public string Description;
        public int ID;
        public virtual int Number { get; set; }
        public virtual double PriceSingle { get; set; }
    }

    public class ProductByQuantity : Product
    {
        private double UnitPrice { get; set; }
        private int Units;

        public override double Price { get => base.Price; set => base.Price = value; }


        public ProductByQuantity(double unitPrice, int units, string name, string description, int iD)
        {
            Price = unitPrice * units;
            Name = name;
            Description = description;
            ID = iD;
            UnitPrice = unitPrice;
            Units = units;
            Number = units;
            PriceSingle = unitPrice;
        }

        public double getUnitPrice() { return UnitPrice; }
        public int getUnits() { return Units; }
        public void setUnits(int x) { Units = x; }
        public bool editUnits(int u)
        {
            if (u <= Units) { Units -= u; return true; }
            else { return false; }
        }
        public void addUnits(int x) { Units = Units + x; }

    }

    public class ProductByWeight : Product
    {
        private double PricePerOunce;
        private int Ounces;

        public override double Price { get => base.Price; set => base.Price = value; }

        public ProductByWeight(double pricePerOunce, int ounces, string name, string description, int iD)
        {
            Price = pricePerOunce * ounces;
            Name = name;
            Description = description;
            ID = iD;
            PricePerOunce = pricePerOunce;
            Ounces = ounces;
            Number = ounces;
            PriceSingle = pricePerOunce;
        }

        public double getPricePerOunce() { return PricePerOunce; }
        public double getOunces() { return Ounces; }
        public void setOunces(int x) { Ounces = x; }
        public bool editOunces(int o)
        {
            if (o <= Ounces) { Ounces -= o; return true; }
            else { return false; }
        }
        public void addOunces( int x) { Ounces = Ounces + x; }

    }
}
