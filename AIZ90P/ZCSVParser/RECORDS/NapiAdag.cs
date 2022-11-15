using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using ZCSVParser.DATATYPES;

namespace ZCSVParser.RECORDS
{
    public sealed record class NapiAdag
    {
        [XmlElement(DataType = "date")]
        public DateTime Datum { get; init; }
        public int Adag { get; init; }

        public NapiAdag(DateTime datum, int adag = 0)
        {
            Datum = datum;
            Adag = adag;
        }

        public NapiAdag()
        {
            Datum = DateTime.MinValue;
            Adag = 0;
        }
    }
}
