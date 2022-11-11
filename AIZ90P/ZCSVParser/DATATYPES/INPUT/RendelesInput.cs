using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCSVParser.DATATYPES.INPUT
{
    public sealed record class RendelesInput
    {
        public DateOnly Datum { get; init; }
        public string FogyasztoKod { get; init; }
        public string FogyasztoTipusKod { get; init; }
        public string EtkezesTipusKod { get; init; }
        public string EtkezesFajtaKod { get; init; }
        public int f_adag { get; init; }

        public RendelesInput(DateOnly datum, string fogyasztoKod, string fogyasztoTipusKod, string etkezesTipusKod, string etkezesFajtaKod, int f_adag)
        {
            Datum = datum;
            FogyasztoKod = fogyasztoKod;
            FogyasztoTipusKod = fogyasztoTipusKod;
            EtkezesTipusKod = etkezesTipusKod;
            EtkezesFajtaKod = etkezesFajtaKod;
            this.f_adag = f_adag;
        }
    }
}
