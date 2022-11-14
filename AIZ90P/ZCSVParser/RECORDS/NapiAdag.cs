using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZCSVParser.DATATYPES;

namespace ZCSVParser.RECORDS
{
    public sealed record class NapiAdagPerEtkezedFajta : IExportable
    {
        public DateOnly Datum { get; init; }
        public int Adag { get; init; }

        public NapiAdagPerEtkezedFajta(DateOnly datum, int adag = 0)
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
