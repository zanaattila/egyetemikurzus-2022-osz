using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCSVParser.RECORDS
{
    public sealed record class NapiAdagPerEtkezesFajta : IExportable
    {
        public DateOnly Datum { get; init; }
        public string EtkezesFajta { get; init; }
        public int Adag { get; init; }

        public NapiAdagPerEtkezesFajta(DateOnly datum, string etkezesFajta, int adag=0)
        {
            Datum = datum;
            EtkezesFajta = etkezesFajta;
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
