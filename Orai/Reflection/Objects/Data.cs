using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Objects
{
    //0. Manuálisan - Hard
    //1. Binary - Not secure :|
    //2. XML - .NET :)
    //3. JSON - .NET :)
    //4. YAML - Not exist in .NET :) :)
    public record class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Data()
        {
            Name = string.Empty;
        }
    }
}
