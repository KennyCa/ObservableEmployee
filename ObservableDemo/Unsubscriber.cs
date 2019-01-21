using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableDemo
{
    public class Unsubscriber : IDisposable
    {
        private List<IObserver<string>> observers;
        private IObserver<string> observer;

        public Unsubscriber(List<IObserver<string>> observers, IObserver<string> observer)
        {
            this.observers = observers;
            this.observer = observer;
        }
        public void Dispose()
        {
            if (observer != null && observers.Contains(observer))
            {
                observers.Remove(observer);
            }
        }
    }
}
