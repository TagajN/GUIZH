using PCBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Services
{
    public interface IRecipe
    {
        void Recipe(IList<Part> pc);
    }
}
