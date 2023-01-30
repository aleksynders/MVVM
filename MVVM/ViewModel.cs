using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

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

        public string One
        {
            set
            {
                Model.One = value;
            }
        }
        public string Two
        {
            set
            {
                Model.Two = value;
            }
        }

        public string Result
        {
            get
            {
                return Model.result.ToString();
            }
        }

        int cbIndex = -1;
        public int IndexSelected
        {
            set
            {
                Model.indexComboBox = value;
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));
            }
        }

        public string CBIndex
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

        public RoutedCommand Command { get; set; } = new RoutedCommand();



        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                double numberOne = 0;
                double numberTwo = 0;
                if (Model.One != "")
                {
                    try
                    {
                        numberOne = Convert.ToDouble(Model.One);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Неверный формат!", "Ошибка");
                        return;
                    }
                }
                if (Model.Two != "")
                {
                    try
                    {
                        numberTwo = Convert.ToDouble(Model.Two);
                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Неверный формат!", "Ошибка");
                        return;
                    }
                }
                switch (Model.indexComboBox)
                {
                    case -1:
                        MessageBox.Show("Выберите операцию!", "Ошибка");
                        return;
                    case 0:
                        Model.result = Convert.ToString(numberOne + numberTwo);
                        break;
                    case 1:
                        Model.result = Convert.ToString(numberOne - numberTwo);
                        break;
                    case 2:
                        Model.result = Convert.ToString(numberOne * numberTwo);
                        break;
                    case 3:
                        if (numberTwo == 0)
                            Model.result = "Деление на 0 невозможно!";
                        else
                            Model.result = Convert.ToString(numberOne / numberTwo);
                        break;
                    default:
                        Model.result = "Ошибка...";
                        return;
                }
                PropertyChanged(this, new PropertyChangedEventArgs("Result"));
            }
            catch
            {
                MessageBox.Show("При вычисление арифметической операции возникла ошибка");
            }
        }


        public CommandBinding bind;
        public ViewModel()
        {
            bind = new CommandBinding(Command);
            bind.Executed += Command_Executed;
        }
    }
}
