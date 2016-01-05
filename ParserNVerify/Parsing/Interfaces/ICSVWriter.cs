using System.Collections.Generic;
using System.IO;

namespace ParserNVerify.Parsing.Interfaces
{
    public interface ICSVWriter<T>
    {
        void Write(string filename, List<T> records, bool writeheader);

        void Write(TextWriter textWriter, List<T> records, bool writeheader);
    }
}