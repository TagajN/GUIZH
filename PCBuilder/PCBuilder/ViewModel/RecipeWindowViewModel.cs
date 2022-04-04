using PCBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.ViewModel
{
    public class RecipeWindowViewModel
    {
        public IList<Part> list { get; set; }

        public void Setup(IList<Part> list)
        {
            this.list = list;
        }

        public RecipeWindowViewModel()
        {

        }
    }
}
