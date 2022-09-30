using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Timers;

namespace AppDevelopment
{
  public class Creature
    {
        public string Name { get; set; }
        public float Hunger { get; set; }
        public float Thirst { get; set; }
        public float Boredom { get; set; }

    }


}
