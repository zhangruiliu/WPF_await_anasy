using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWpfTest
{
    public class BindDatbleBase : INotifyPropertyChanged
    {
        protected void SetProperty<T>(ref T prop, T value, [CallerMemberName] string callerName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(prop, value))
            {
                prop = value;
                OnPropertyChanged(callerName);
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name) {

            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(name));
        }
    }
}
