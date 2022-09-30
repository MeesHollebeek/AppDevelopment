using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Newtonsoft.Json;


namespace AppDevelopment
{
    public partial class MainPage : ContentPage
    {
      
        public Creature Markie { get; set; } = new Creature
        {
            Name = "mark",

            Hunger = 0.5f,

            Thirst = 0.5f,

            Boredom = 0.5f
        };

        private Timer timer;

        

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);
        }

        // protected override async void OnAppearing()
        //  {
        //       base.OnAppearing();

        //       var CreatureDatastore = DependencyService.Get<IDataStore<Creature>>();
        //       Markie = CreatureDatastore.ReadItem();
        //       if (Markie == null)
        //       {
        //           Markie = new Creature { Name = "Markie" };
        //           CreatureDatastore.CreateItem(Markie);
        ///       }
        //       Markie.Name = "mark";
        //         Markie.Hunger = 0.3f;
        //         CreatureDatastore.UpdateItem(Markie);
        //     }

      

        async void OnButtonClicked(object sender, EventArgs args)
        {
            

          
            Navigation.PushAsync(new nutteloos());
        }
    }
}
