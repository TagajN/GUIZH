using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Model
{
    public class Part : ObservableObject
    {
        private string type;
        private string name;
        private int price;

        public string Type
        {
            get { return type; }
            set
            {
                SetProperty(ref type, value);
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
            }
        }
        public int Price
        {
            get { return price; }
            set
            {
                SetProperty(ref price, value);
            }
        }

        public Part GetCopy()
        {
            return new Part()
            {
                Type = this.Type,
                Name = this.Name,
                Price = this.Price
            };
        }
    }
}
