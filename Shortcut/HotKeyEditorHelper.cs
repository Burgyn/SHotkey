using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SearchingKeyboardShortcut
{
    public class HotKeyEditorHelper
    {
        private HotKey _lastKey;
        private HashSet<Key> _ignoredKey = new HashSet<Key>() { Key.LeftAlt, Key.RightAlt, Key.LeftCtrl,
            Key.RightCtrl, Key.LeftShift, Key.RightShift, Key.RWin, Key.LWin};

        public void Attach(TextBox textBox)
        {
            textBox.PreviewKeyDown += textBox_PreviewKeyDown;
        }

        public void Detach(TextBox textBox)
        {
            textBox.PreviewKeyDown -= textBox_PreviewKeyDown;
        }

        void textBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;

            if (!_ignoredKey.Contains(e.Key) && (e.Key != Key.System || (e.Key == Key.System && !_ignoredKey.Contains(e.SystemKey))))
            {
                var key = (e.Key == Key.System && !_ignoredKey.Contains(e.SystemKey)) ? e.SystemKey : e.Key;
                if (!string.IsNullOrWhiteSpace(textBox.Text) && (_lastKey == null))
                {
                    textBox.Text = string.Empty;
                }
                else
                {
                    var hotKey = new HotKey()
                    {
                        Ctrl = ((Keyboard.Modifiers & ModifierKeys.Control) == ModifierKeys.Control),
                        Alt = ((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt),
                        Shift = ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift),
                        Key = key
                    };                    
                    textBox.Text = string.Format("{0}{1}{2}", _lastKey != null ? _lastKey.ToString() : string.Empty,
                        string.IsNullOrWhiteSpace(textBox.Text) ? string.Empty : ", ", hotKey);
                    textBox.SelectionStart = textBox.Text.Length;
                    textBox.SelectionLength = 0;
                    if (_lastKey == null)
                    {
                        _lastKey = hotKey;
                    }
                    else
                    {
                        _lastKey = null;
                    }
                }
            }
            e.Handled = true;
        }
    }
}
