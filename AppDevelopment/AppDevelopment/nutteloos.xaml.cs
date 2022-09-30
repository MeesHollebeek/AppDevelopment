using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;

namespace AppDevelopment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class nutteloos : ContentPage
    {
        public Creature Markie { get; set; } = new Creature
        {
            Hunger = 0.5f,

            Thirst = 0.5f,

            Boredom = 0.5f
        };



        public Creature MyCreature { get; set; }
        public float food { get; set; } = .0f;

        public string HungerText => food switch
        {
            >= 1.0f => "plenty of food!",
            >= .5f => "Nomming away.",
            > .0f => "Food is  running low...",
            .0f => "Nothing left",
            _ => throw new Exception("impossible")

        };

        public float happy { get; set; } = .0f;

        public string SpinText => happy switch
        {
            >= 1.0f => "Happy",
            >= .5f => "Fine",
            > .0f => "Bored",
            .0f => "Angry",
            _ => throw new Exception("impossible")
        };


        
       

        public nutteloos()
        {
           // var CreatureDatastore = DependencyService.Get<IDataStore<Creature>>();
           // CreatureDatastore.UpdateItem(Markie);

            var timer = new Timer();
            timer.Interval = 3000.0;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            BindingContext = this;

            InitializeComponent();

            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);

            food = Markie.Hunger;

            happy = Markie.Thirst;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (Markie.Hunger > 0)
                {
                    Markie.Hunger = Markie.Hunger - .1f;
                }
                if (Markie.Hunger <= 0)
                {
                    Markie.Hunger = 0;
                }
                if (Markie.Thirst > 0)
                {
                    Markie.Thirst = Markie.Thirst - .1f;
                }
                if (Markie.Thirst <= 0)
                {
                    Markie.Thirst = 0;
                }
            });
            
        }

    

        async void Feed(object sender, EventArgs args)
        {
            Navigation.PushAsync(new food());


        }
        async void spin(object sender, EventArgs args)
        {
            Navigation.PushAsync(new playing());

        }
        async void thirst(object sender, EventArgs args)
        {
            Navigation.PushAsync(new drink());

        }
        async void sleep(object sender, EventArgs args)
        {
            Navigation.PushAsync(new bed());

        }
    }
}