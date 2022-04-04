using Microsoft.Toolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using PCBuilder.Model;
using PCBuilder.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Logic
{
    public class ComputerLogic : IComputerLogic
    {
        IList<Part> storage;
        IList<Part> pc;
        IMessenger messenger;
        IRecipe recipe;
        public ComputerLogic(IMessenger messenger, IRecipe recipe)
        {
            this.messenger = messenger;
            this.recipe = recipe;
        }
        public void SetupCollection(IList<Part> storage, IList<Part> pc)
        {
            this.storage = storage;
            this.pc = pc;
        }

        public void Load()
        {
            if (File.Exists("storage.json"))
            {
                JsonConvert.DeserializeObject<List<Part>>(File.ReadAllText("storage.json")).ForEach(x => storage.Add(x));
            }
        }

        public int AllCost
        {
            get
            {
                return pc.Count == 0 ? 0 : pc.Sum(x => x.Price);
            }
        }
        public void AddToPC(Part part)
        {
            if (part.Type == "CPU" && !(pc.Any(t => t.Type=="CPU")))
            {
                pc.Add(part.GetCopy());
                messenger.Send("PartAdded", "PartInfo");
            }
            else if (part.Type == "MOTHERBOARD" && !(pc.Any(t => t.Type == "MOTHERBOARD")))
            {
                pc.Add(part.GetCopy());
                messenger.Send("PartAdded", "PartInfo");
            }
            else if (part.Type == "RAM" || part.Type == "SSD")
            {
                pc.Add(part.GetCopy());
                messenger.Send("PartAdded", "PartInfo");
            }
            
        }

        public void RemoveFromPC(Part part)
        {
            pc.Remove(part);
            messenger.Send("PartRemoved", "PartInfo");
        }

        public void Sale(Part part)
        {
            part.Price = (part.Price / 100) * 90;
        }

        public void Recipe()
        {
            recipe.Recipe(pc);
        }
    }
}
