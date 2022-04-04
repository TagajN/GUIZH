using PCBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Services
{
    public class RecipeViaWindow : IRecipe
    {
        public void Recipe(IList<Part> pc)
        {
            new RecipeWindow(pc).ShowDialog();
        }
    }
}
