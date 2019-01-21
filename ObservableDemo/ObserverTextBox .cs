using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ObservableDemo
{
    public class ObserverTextBox : TextBox, IObserver<string>
    {
        private IDisposable unsubscriber;
        private TextBox textBox;
        EmployeeRepository repository;

        public ObserverTextBox (TextBox textBox)
        {
            this.textBox = textBox;
            repository = new EmployeeRepository();
        }
        void IObserver<string>.OnCompleted()
        {
        }
        void IObserver<string>.OnError(Exception error)
        {

        }
        void IObserver<string>.OnNext(string value)
        {
            if (value != "")
            {
                var employee = GetEmployee(value);
                if (textBox.Name == "txtFirstName")
                {
                    textBox.Text = employee.FirstName;
                }
                else
                {
                    textBox.Text = employee.LastName;
                }
                this.Refresh();
            }
            
        }
        public virtual void Subscribe(IObservable<string> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        private EmployeeInfo GetEmployee(string id)
        {
            return repository.GetEmployee(int.Parse(id));
        }
    }
}
