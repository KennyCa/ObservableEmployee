using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObservableDemo
{
    public class ObservableText : TextBox, IObservable<string>
    {
        private List<IObserver<string>> observers;

        public ObservableText()
        {
            observers = new List<IObserver<string>>();
        }

        IDisposable IObservable<string>.Subscribe(IObserver<string> observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            return new Unsubscriber(observers, observer);
        }
        public void Notify(string text)
        {
            foreach (IObserver<string> observer in observers)
            {
                observer.OnNext(text);
            }
        }
    }
}
