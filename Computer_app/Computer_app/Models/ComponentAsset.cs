using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_app.Models
{
    public class ComponentAsset : ObservableObject
    {
        private string type;

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        public string Type
        {
            get { return type; }
            set { SetProperty(ref type, value); }
        }

        private double price;

        public double Price
        {
            get { return price; }
            set { SetProperty(ref price, value); }
        }
        public ComponentAsset GetCopy()
        {
            return new ComponentAsset()
            {
                Name = this.Name,
                Type = this.Type,
                Price = this.Price
            };
        }
    }
}
