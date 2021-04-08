using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HW3.Views;
using System.Collections.ObjectModel;
using HW3.Model;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace HW3
{
    public partial class App : Application
    {

        public MyHome myHome = new MyHome();
        public Checkout checkout;

        public App()
        {
            InitializeComponent();

            var handler = new WebRequestHandler();
            try
            {
                //string idk = handler.Get("https://localhost:5002/controller/GetAll").Result;
                //Console.WriteLine("idk: " + idk.ToString());
                List<Product> test = JsonConvert.DeserializeObject<List<Product>>(handler.Get("https://localhost:5002/controller/GetAll").Result);
                foreach (Product x in test)
                {
                    Console.WriteLine("please " + x.Name);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("e message: " + e.Message);
            }
            

            //myHome = new MyHome(checkout);

            checkout = new Checkout(myHome);

            MainPage = new TabbedPage
            {
                Children =
                {
                    myHome,
                    new MyCart(myHome),
                    checkout
                    //new Checkout(myHome)
                }
            };

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
