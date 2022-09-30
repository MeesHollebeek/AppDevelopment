using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDevelopment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class food : ContentPage
    {

       
        public Creature MyCreature { get; set; }
        public float feed { get; set; } = .0f;

        public string HungerText => feed switch
        {
            >= 1.0f => "plenty of food!",
            >= .5f => "Nomming away.",
            > .0f => "Food is  running low...",
            .0f => "Nothing left",
            _ => throw new Exception("impossible")

        };

    

        public food()
        {
            var timer = new Timer();
            timer.Interval = 3000.0;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();

            feed = Markie.Hunger;

            BindingContext = this;

            InitializeComponent();

          

            Console.WriteLine(Markie.Hunger);
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                Markie.Hunger -= 0.1f;
                var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
                creatureDataStore.UpdateItem(Markie);

            });

        }

        public Creature Markie { get; set; } = new Creature
        {
            Name = "mark",

            Hunger = 0.5f,

            Thirst = 0.5f,

            Boredom = 0.5f
        };



        async void Feed(object sender, EventArgs args)
        {


            Markie.Hunger = .0f;
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            creatureDataStore.UpdateItem(Markie);

            await rutten.TranslateTo(0, 5);
            await rutten.TranslateTo(0, 0);
            await rutten.TranslateTo(0, 5);
            rutten.TranslateTo(0, 0);


        }
    }
}