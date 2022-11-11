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
        public string FogyasztoTipusNev { get; init; }
        public string EtkezesTipusKod { get; init; }
        public string EtkezesTipusNev { get; init; }
        public string EtkezesFajtaKod { get; init; }
        public string EtkezesFajtaNev { get; init; }
        public int f_adag { get; init; }

        public RendelesInput(DateOnly datum, string fogyasztoKod, string fogyasztoTipusKod, string fogyasztoTipusNev, string etkezesTipusKod, string etkezesTipusNev, string etkezesFajtaKod, string etkezesFajtaNev, int f_adag = 0)
        {
            Datum = datum;
            FogyasztoKod = fogyasztoKod;
            FogyasztoTipusKod = fogyasztoTipusKod;
            FogyasztoTipusNev = fogyasztoTipusNev;
            EtkezesTipusKod = etkezesTipusKod;
            EtkezesTipusNev = etkezesTipusNev;
            EtkezesFajtaKod = etkezesFajtaKod;
            EtkezesFajtaNev = etkezesFajtaNev;
            this.f_adag = f_adag;
        }
    }
}
