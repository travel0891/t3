using System;
using System.Configuration;
using System.Web.UI;

namespace view
{
    public class viewBase : Page
    {
        private String websiteTitle;
        /// <summary>
        /// 整站页面标题
        /// </summary>
        public String WebsiteTitle { get { return websiteTitle; } }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            websiteTitle = ConfigurationManager.AppSettings["websiteTitle"];
        }
    }
}