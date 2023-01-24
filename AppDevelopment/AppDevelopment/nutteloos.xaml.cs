using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;
using Tamagotchi;

namespace AppDevelopment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class nutteloos : ContentPage
    {


        public Creature Markie { get; set; } = new Creature
        {

        };



        public Creature MyCreature { get; set; }

        public float hong { get; set; } = .0f;
        public float Status => hong;
        public string HungerText => hong switch
        {
            >= 1.0f => "plenty of food!",
            >= .5f => "Nomming away.",
            >= .1f => "Very hungry.",
            > .0f => "Loading food status...",
            .0f => "Loading food stats...",
            _ => throw new Exception("impossible")

        };

        public float happy { get; set; } = .0f;

     //   public string SpinText => happy switch
      //  {
      //      >= 1.0f => "Happy",
       //     >= .5f => "Fine",
       //     > .0f => "Bored",
       //     .0f => "Angry",
       //     _ => throw new Exception("impossible")
      //  };


        
       

        public nutteloos()
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);

            var timer = new Timer();
            timer.Interval = 3000.0;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            BindingContext = this;

            InitializeComponent();

           
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if(Markie.Hunger > 0.09)
                {
                    Markie.Hunger -= 0.05f;
                    Console.WriteLine(Markie.Hunger);
                    hong = Markie.Hunger;
                }
             
            });
            
        }



        void Feed(object sender, EventArgs args)
        {
            Navigation.PushAsync(new food());
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);

        }
        void spin(object sender, EventArgs args)
        {
            Navigation.PushAsync(new playing());
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);

        }
         void thirst(object sender, EventArgs args)
        {
            Navigation.PushAsync(new drink());
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);

        }
         void sleep(object sender, EventArgs args)
        {
            Navigation.PushAsync(new bed());
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            Markie = await creatureDataStore.ReadItem();
            if (Markie == null)
            {
                Markie = new Creature { Name = "Markie" };
                await creatureDataStore.CreateItem(Markie);
            }

            // await creatureDataStore.UpdateItem(Markie);

            Console.WriteLine(Markie.Hunger);
        }
    }
}