using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagrams.Entity.Abstract
{
    public interface IAnagramsRepository
    {
        List<String> Wordlist { get; }
    }
}
