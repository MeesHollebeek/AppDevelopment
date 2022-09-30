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
    public partial class bed : ContentPage
    {
        public Creature MyCreature { get; set; }
        public float sleep { get; set; } = .0f;

        public string SleepText => sleep switch
        {
            >= 1.0f => "plenty of sleep!",
            >= .5f => "good night of sleep.",
            > .0f => "getting tired",
            .0f => "falling asleep on the ground",
            _ => throw new Exception("impossible")

        };


        public bed()
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
                if (sleep > 0)
                {
                    sleep = sleep - .1f;
                }
                if (sleep <= 0)
                {
                    sleep = 0;
                }

            });

        }
        async void sleepy(object sender, EventArgs args)
        {


            if (sleep >= 0 && sleep < 1.2)
            {
                sleep = sleep + .1f;
            }

            await rutten.RotateXTo(15, 0);
            await rutten.RotateXTo(0, 0);
            await rutten.RotateXTo(-15, 0);
            await rutten.RotateXTo(0, 0);


        }
    }
}