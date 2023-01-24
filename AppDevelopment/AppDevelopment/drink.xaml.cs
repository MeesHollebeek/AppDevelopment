using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Tamagotchi;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppDevelopment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class drink : ContentPage
    {
        public Creature Markie { get; set; } = new Creature
        {
        };

        public Creature MyCreature { get; set; }
        public float Status => Markie.Thirst;

        public string ThirstText => Status switch
        {
            >= 1.0f => "plenty of water!",
            >= .5f => "drinking away.",
            > .0f => "water is  running low...",
            .0f => "Nothing left",
            _ => throw new Exception("impossible")

        };

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

            Markie.Name = "mark";
            // Markie.Hunger;
            await creatureDataStore.UpdateItem(Markie);
        }
        public drink()
        {
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
                 var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
                 creatureDataStore.UpdateItem(Markie);
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
        async void thirsty(object sender, EventArgs args)
        {
            var creatureDataStore = DependencyService.Get<IDataStore<Creature>>();
            await creatureDataStore.UpdateItem(Markie);

            if (Markie.Thirst >= 0 && Markie.Thirst < 1.2)
            {
                Markie.Thirst = Markie.Thirst + .1f;
            }

      

            await rutten.TranslateTo(0, 5);
            await rutten.TranslateTo(0, 0);
            await rutten.TranslateTo(0, 5);
            rutten.TranslateTo(0, 0);


        }
 
    }
}