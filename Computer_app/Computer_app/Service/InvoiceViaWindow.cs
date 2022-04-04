using Computer_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_app.Service
{
    public class InvoiceViaWindow : IInvoiceSercvice
    {
        public void InvoiceList(IList<ComponentAsset> componentAssets)
        {
            new InvoiceWindow(componentAssets).ShowDialog();
        }
    }
}
