using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncWpfTest
{
    public class TestItem:BindDatbleBase
    {
        private string _Count;
        public string Count {

            get { return _Count; }
            set {

                SetProperty(ref _Count,value);
            }
        }
    }
}
