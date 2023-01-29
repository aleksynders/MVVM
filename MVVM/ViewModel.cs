using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<String> ComboChange
        {
            get
            {
                return Model.dataListOperationStr;
            }
        }

        int cbIndex = -1;
        public int IndexSelected // Cвойство для нахождения индекса выбранного в Combobox элемента
        {
            set
            {
                Model.indexComboBox = value;
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));
            }
        }

        public string CBIndex // Свойство для отображения выбранной арифметической операции
        {
            get
            {
                if (cbIndex == -1)
                {
                    return "";
                }
                else
                {
                    return Model.dataListOperationZnak[cbIndex];
                }
            }
        }
    }
}
