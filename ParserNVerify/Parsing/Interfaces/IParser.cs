using System.Collections.Generic;
using System.IO;

namespace ParserNVerify.Parsing.Interfaces
{
    public interface IParser<T>
    {
        List<T> Parse(string filename);

        List<T> Parse(TextReader textReader);
    }
}