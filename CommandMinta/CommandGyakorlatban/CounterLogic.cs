using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandGyakorlatban
{
    public class CounterLogic : ICounterLogic
    {
        public int Counter { get; set; }
        private IMessenger messenger;

        public void Increase()
        {
            Counter++;
            messenger.Send("Counter changed", "CounterResult");
        }
        public CounterLogic(IMessenger messenger)
        {
            this.messenger = messenger;
            Counter = 1;
        }
    }
}
