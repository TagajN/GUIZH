using Computer_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_app.ViewModels
{
    public class InvoiceWindowViewModel
    {
        public IList<ComponentAsset> Actual { get; set; }
        public void Setup(IList<ComponentAsset> componentAssets)
        {
            this.Actual = componentAssets;
        }
        public InvoiceWindowViewModel()
        {

        }
    }
}
