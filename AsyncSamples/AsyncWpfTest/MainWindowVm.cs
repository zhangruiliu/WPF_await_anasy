using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWpfTest
{
    public class MainWindowVm:BindDatbleBase
    {
        public MainWindowVm() {

            _Mlist = new ObservableCollection<TestItem>();
            _Mlist.CollectionChanged += delegate { OnPropertyChanged("Mlist"); };
        }
        private ObservableCollection<TestItem> _Mlist;
        public ObservableCollection<TestItem> Mlist => _Mlist;
    }
}
