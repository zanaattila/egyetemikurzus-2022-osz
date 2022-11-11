using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCSVParser.DATATYPES.OUTPUT
{
    public sealed record class NapiAdagPerFogyasztoKod : IExportable
    {
        public DateOnly Datum { get; init; }
        public string FogyasztoKod { get; init; }

        public int Adag { get; init; }

        public NapiAdagPerFogyasztoKod(DateOnly datum, string fogyasztoKod, int adag = 0)
        {
            Datum = datum;
            FogyasztoKod = fogyasztoKod;
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
