using System.Collections.Generic;

namespace BlazorApp.Web.Models
{
    public class Configuration
    {

        #region Publisher Configuration
        public string id { get; set; } // 'id' property is required
        public string entity { get; set; }
        public string UserName { get; set; }
        public string Organization { get; set; }

        public string PublishTo { get; set; }
        public string SubscribeTo { get; set; }
        public int IsDeployed { get; set; }

        public List<string> AirLineCodesData { get; set; } = new List<string>();
        public List<string> AirportsData { get; set; } = new List<string>();
        #endregion

        #region Message broker Configuration
        public string CompanyCode { get; set; }
        #endregion
    }

}