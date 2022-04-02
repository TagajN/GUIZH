using MVVM_MintaZH.Models;
using System.Collections.Generic;

namespace MVVM_MintaZH.Logic
{
    public interface IArmyLogic
    {
        int AllCost { get; }
        double AVGPower { get; }
        double AVGSpeed { get; }

        void AddToArmy(Trooper trooper);
        void EditTrooper(Trooper trooper);
        void RemoveFromArmy(Trooper trooper);
        void SetupCollections(IList<Trooper> barracks, IList<Trooper> army);
    }
}