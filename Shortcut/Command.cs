using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchingKeyboardShortcut
{
    public class VSCommand
    {
        public string Name { get; set; }

        public string Shortcut { get; set; }

        public string Type { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}; {2}", this.Name, this.Shortcut, this.Type);
        }
    }
}
