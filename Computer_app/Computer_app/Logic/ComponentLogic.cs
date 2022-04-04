using Computer_app.Models;
using Computer_app.Service;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_app.Logic
{
    public class ComponentLogic : IComponentLogic
    {
        IList<ComponentAsset> storage;
        IList<ComponentAsset> basket;
        IMessenger messenger;
        IInvoiceSercvice invoiceSercvice;
        public ComponentLogic(IMessenger messenger, IInvoiceSercvice invoiceSercvice)
        {
            this.messenger = messenger;
            this.invoiceSercvice = invoiceSercvice;
        }

        public void SetupCollections(IList<ComponentAsset> storage, IList<ComponentAsset> basket)
        {
            this.storage = storage;
            this.basket = basket;
        }

        public void AddToBasket(ComponentAsset componentAsset)
        {
            int countCPU = 0;
            int countAlaplap = 0;
            foreach (var b in basket)
            {
                if (b.Type == "CPU")
                {
                    countCPU++;
                }
                else if (b.Type == "Alaplap")
                {
                    countAlaplap++;
                }
            }
            if (countAlaplap < 1 && componentAsset.Type == "Alaplap")
            {
                basket.Add(componentAsset.GetCopy());
                messenger.Send("Component added", "ComponentInfo");
            }
            else if (countCPU < 1 && componentAsset.Type == "CPU")
            {
                basket.Add(componentAsset.GetCopy());
                messenger.Send("Component added", "ComponentInfo");
            }
            else if (componentAsset.Type != "Alaplap" && componentAsset.Type != "CPU")
            {
                basket.Add(componentAsset.GetCopy());
                messenger.Send("Component added", "ComponentInfo");
            }
        }

        public void RemoveFromBasket(ComponentAsset componentAsset)
        {
            basket.Remove(componentAsset);
            messenger.Send("Component removed", "ComponentInfo");
        }

        public void Invoice(IList<ComponentAsset> basket)
        {
            TextWriter tw = new StreamWriter("Invoices.txt");
            foreach (var item in basket)
            {
                tw.WriteLine("Item: {0} - {1} - {2}", item.Name, item.Type, item.Price);
            }
            tw.Close();
            invoiceSercvice.InvoiceList(basket);
        }

        public IList<ComponentAsset> loadData()
        {
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("Data.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(';');
                storage.Add(new ComponentAsset()
                { Name = words[0], Type = words[1], Price = (int.Parse(words[2])) });
            }

            file.Close();
            return storage;
        }
        public double AllCost
        {
            get
            {
                return basket.Count == 0 ? 0 : basket.Sum(t => t.Price);
            }
        }

        public double UpdatePrice(ComponentAsset componentAsset)
        {
            return componentAsset.Price * 0.9;
        }
    }
}
