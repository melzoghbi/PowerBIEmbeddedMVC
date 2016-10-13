
using Microsoft.PowerBI.Api.V1;
using Microsoft.PowerBI.Api.V1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBIEWebApp.Models
{
    public class ReportViewModel
    {
        public Report Report { get; set; }

        public string AccessToken { get; set; }
    }
}
