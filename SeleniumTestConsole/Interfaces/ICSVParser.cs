using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTestConsole.Interfaces
{
    public interface ICSVParser<T>
    {
        List<T> Parse(string filename);

        List<T> Parse(TextReader textReader);
    }
}
