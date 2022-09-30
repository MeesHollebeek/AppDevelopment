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
    public partial class drink : ContentPage
    {
        public Creature MyCreature { get; set; }
        public float thirst { get; set; } = .0f;

        public string ThirstText => thirst switch
        {
            >= 1.0f => "plenty of water!",
            >= .5f => "drinking away.",
            > .0f => "water is  running low...",
            .0f => "Nothing left",
            _ => throw new Exception("impossible")

        };


        public drink()
        {
            var timer = new Timer();
            timer.Interval = 3000.0;
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();


            //  MyCreature = new Creature
            //  {
            //     Name = "Henk",

            //  };

            //  var datastore = new CreatureDatastore();
            //  datastore.CreateEntry(MyEntry);

            BindingContext = this;

            InitializeComponent();
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (thirst > 0)
                {
                    thirst = thirst - .1f;
                }
                if (thirst <= 0)
                {
                    thirst = 0;
                }

            });

        }
        async void thirsty(object sender, EventArgs args)
        {


            if (thirst >= 0 && thirst < 1.2)
            {
                thirst = thirst + .1f;
            }


            await rutten.TranslateTo(0, 5);
            await rutten.TranslateTo(0, 0);
            await rutten.TranslateTo(0, 5);
            rutten.TranslateTo(0, 0);


        }
    }
}