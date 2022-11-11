using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCSVParser.DATATYPES.OUTPUT
{
    public sealed record class NapiAdag : IExportable
    {
        public DateOnly Datum { get; init; }
        public int Adag { get; init; }

        public NapiAdag(DateOnly datum, int adag = 0)
        {
            Datum = datum;
            Adag = adag;
        }

        public void ExportCSV()
        {
            throw new NotImplementedException();
        }

        public void ExportJSON()
        {
            throw new NotImplementedException();
        }

        public void ExportXML()
        {
            throw new NotImplementedException();
        }
    }
}
