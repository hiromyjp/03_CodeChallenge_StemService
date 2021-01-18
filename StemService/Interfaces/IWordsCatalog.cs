using System.Collections.Generic;

namespace StemService.Interfaces
{
    public interface IWordsCatalog
    {
        IList<string> Find(string stem);
    }
}
