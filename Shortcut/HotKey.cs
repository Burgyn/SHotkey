using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SearchingKeyboardShortcut
{
    public class HotKey
    {
        public bool Ctrl { get; set; }

        public bool Shift { get; set; }

        public bool Alt { get; set; }

        public Key Key { get; set; }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}", (Ctrl ? "Ctrl+" : ""), (Shift ? "Shift+" : ""), (Alt ? "Alt+" : ""), KeyToString(Key));
        }

        public string KeyToString(Key key)
        {
            var ret = key.ToString();

            switch (key)
            {
                case Key.NumPad0:
                    ret = "0";
                    break;
                case Key.NumPad1:
                    ret = "1";
                    break;
                case Key.NumPad2:
                    ret = "2";
                    break;
                case Key.NumPad3:
                    ret = "3";
                    break;
                case Key.NumPad4:
                    ret = "4";
                    break;
                case Key.NumPad5:
                    ret = "5";
                    break;
                case Key.NumPad6:
                    ret = "6";
                    break;
                case Key.NumPad7:
                    ret = "7";
                    break;
                case Key.NumPad8:
                    ret = "8";
                    break;
                case Key.NumPad9:
                    ret = "9";
                    break;
                case Key.Down:
                    ret = "Down Arrow";
                    break;
                case Key.Up:
                    ret = "Up Arrow";
                    break;
                case Key.Right:
                    ret = "Right Arrow";
                    break;
                case Key.Left:
                    ret = "Left Arrow";
                    break;
                case Key.Subtract:
                    ret = "-";
                    break;
                case Key.Add:
                    ret = "+";
                    break;
                case Key.Multiply:
                    ret = "*";
                    break;
                case Key.Divide:
                    ret = "/";
                    break;
                case Key.Decimal:
                    ret = ",";
                    break;
                case Key.OemComma:
                    ret = ",";
                    break;
                case Key.OemPeriod:
                    ret = ".";
                    break;
                case Key.OemPipe:
                    ret = "|";
                    break;
            }

            return ret;
        }
    }
}
