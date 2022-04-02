using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiniEditorBinding
{
    public class Person : INotifyPropertyChanged
    {
        //public event EventHandler HaveGlassesChanged;
        public event PropertyChangedEventHandler? PropertyChanged;

        private string name;
        private int age;
        private string haveGlasses;

        public void OnPropertyChanged([CallerMemberName] string properyName="")
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(properyName));
        }
        public string HaveGlasses
        {
            get { return haveGlasses; } 
            set { 
                    haveGlasses = value;
                //HaveGlassesChanged?.Invoke(this, EventArgs.Empty);
                OnPropertyChanged();
                }
        }

        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public int Age { get => age; set { age = value; OnPropertyChanged(); } }
    }
}
