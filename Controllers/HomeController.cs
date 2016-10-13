using Microsoft.PowerBI.Api.V1;
using Microsoft.PowerBI.Security;
using Microsoft.Rest;
using PBIEWebApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PBIEWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly string workspaceCollection;
        private readonly string workspaceId;
        private readonly string accessKey;
        private readonly string apiUrl;

        public HomeController()
        {
            this.workspaceCollection = ConfigurationManager.AppSettings["powerbi:WorkspaceCollection"];
            this.workspaceId = ConfigurationManager.AppSettings["powerbi:WorkspaceId"];
            this.accessKey = ConfigurationManager.AppSettings["powerbi:AccessKey"];
            this.apiUrl = ConfigurationManager.AppSettings["powerbi:ApiUrl"];
        }

        public async Task<ActionResult> Index()
        {
            ReportsViewModel reportsList;
            using (var client = this.CreatePowerBIClient())
            {
                var reportsResponse = client.Reports.GetReports(this.workspaceCollection, this.workspaceId);
                reportsList = new ReportsViewModel
                {
                    Reports = reportsResponse.Value.ToList()
                };
            }

            // bind the report
            var embedToken = PowerBIToken.CreateReportEmbedToken(this.workspaceCollection, this.workspaceId, reportsList.Reports[0].Id);
            var viewModel = new ReportViewModel
            {
                Report = reportsList.Reports[0],
                AccessToken = embedToken.Generate(this.accessKey)
            };

            return View(viewModel);
        }

             
        /// <summary>
        /// Create A PowerBI Client Token
        /// </summary>
        /// <returns></returns>
        private IPowerBIClient CreatePowerBIClient()
        {
            var credentials = new TokenCredentials(this.accessKey, "AppKey");
            var client = new PowerBIClient(credentials)
            {
                BaseUri = new Uri(apiUrl)
            };

            return client;
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}