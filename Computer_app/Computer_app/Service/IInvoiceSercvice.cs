using Computer_app.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computer_app.Service
{
    public interface IInvoiceSercvice
    {
        void InvoiceList(IList<ComponentAsset> componentAssets);
    }
}
