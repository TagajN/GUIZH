using PCBuilder.Model;
using System.Collections.Generic;

namespace PCBuilder.Logic
{
    public interface IComputerLogic
    {
        int AllCost { get; }

        void AddToPC(Part part);
        void Load();
        void RemoveFromPC(Part part);
        void Sale(Part part);
        void SetupCollection(IList<Part> storage, IList<Part> pc);
        void Recipe();
    }
}