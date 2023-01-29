using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    public static class Model
    {
        public static List<string> dataListOperationStr = new List<string>() { "Сложение", "Вычитание", "Умножение", "Деление" };
        public static List<string> dataListOperationZnak = new List<string>() { "+", "-", "*", "/" };
        public static int indexComboBox = -1;

        public static string One;
        public static string Two;
        public static string result = "";
    }
}
