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
    public partial class playing : ContentPage
    {
        public float happy { get; set; } = .0f;

        public string SpinText => happy switch
        {
            >= 1.0f => "Happy",
            >= .5f => "Fine",
            > .0f => "Bored",
            .0f => "Angry",
            _ => throw new Exception("impossible")
        };
        public playing()
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
              
                if (happy > 0)
                {
                    happy = happy - .1f;
                }
                if (happy <= 0)
                {
                    happy = 0;
                }
            });

        }
        async void spin(object sender, EventArgs args)
        {
            await rutten.RelRotateTo(45, 0);
            if (happy >= 0 && happy < 1.2)
            {
                happy = happy + .1f;
            }

        }
    }
}