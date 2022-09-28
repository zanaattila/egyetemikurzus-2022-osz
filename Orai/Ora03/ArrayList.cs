using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora03
{

    /// <summary>
    /// MAX MACSKA COUNT = 640; Otherwise GOES BUMM!
    /// </summary>
    internal sealed class CicaList : IEnumerable<string>
    {
        private readonly string[] _macskak;
        private int _count;
        public const int MaxMacska = 640;

        public CicaList()
        {
            _macskak = new string[MaxMacska];
            _count = 0;
        }

        public void Add(string macska)
        {
            if (_count >= MaxMacska)
            {
                throw new InvalidOperationException("Too many macseks");
            }
            _macskak[_count] = macska;
            ++_count;
        }

        public bool TryAdd(string macska)
        {
            if (_count < MaxMacska)
            {
                Add(macska);
                return true;
            }
            return false;
        }


        public IEnumerator<string> GetEnumerator()
        {
            foreach (string macska in _macskak)
            {
                yield return macska;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _macskak.GetEnumerator();
        }
    }
}
