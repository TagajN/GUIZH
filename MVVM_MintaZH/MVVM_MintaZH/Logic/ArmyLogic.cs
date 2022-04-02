using Microsoft.Toolkit.Mvvm.Messaging;
using MVVM_MintaZH.Models;
using MVVM_MintaZH.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_MintaZH.Logic
{
    public class ArmyLogic : IArmyLogic
    {
        IList<Trooper> barracks;
        IList<Trooper> army;
        IMessenger messenger;
        ITrooperEditorSevice trooperEditorSevice;
        public ArmyLogic(IMessenger messenger, ITrooperEditorSevice trooperEditorSevice)
        {
            this.messenger = messenger;
            this.trooperEditorSevice = trooperEditorSevice;
        }

        public void SetupCollections(IList<Trooper> barracks, IList<Trooper> army)
        {
            this.barracks = barracks;
            this.army = army;
        }

        public void AddToArmy(Trooper trooper)
        {
            army.Add(trooper.GetCopy());
            messenger.Send("Trooper added", "TrooperInfo");
        }

        public void RemoveFromArmy(Trooper trooper)
        {
            army.Remove(trooper);
            messenger.Send("Trooper removed", "TrooperInfo");
        }

        public void EditTrooper(Trooper trooper)
        {
            trooperEditorSevice.Edit(trooper);
        }
        public int AllCost
        {
            get
            {
                return army.Count == 0 ? 0 : army.Sum(t => t.Cost);
            }
        }

        public double AVGPower
        {
            get
            {
                return Math.Round(army.Count == 0 ? 0 : army.Average(t => t.Power), 2);
            }
        }
        public double AVGSpeed
        {
            get
            {
                return Math.Round(army.Count == 0 ? 0 : army.Average(t => t.Speed), 2);
            }
        }
    }
}
