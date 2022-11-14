﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZCSVParser.RECORDS
{
    public interface IExportable
    {
        public void ExportCSV();
        public void ExportJSON();
        public void ExportXML();
    }
}