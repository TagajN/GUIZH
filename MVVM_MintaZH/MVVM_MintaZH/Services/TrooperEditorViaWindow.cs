using MVVM_MintaZH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_MintaZH.Services
{
    public class TrooperEditorViaWindow : ITrooperEditorSevice
    {
        public void Edit(Trooper t)
        {
            new TrooperEditoWindow(t).ShowDialog();
        }
    }
}
