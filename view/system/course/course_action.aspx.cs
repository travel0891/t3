using System;

namespace view
{
    using controller;
    using model.table;

    public partial class course_action : viewBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString["charId"]))
            {
                courses editModel = new courses();
                editModel.charId = Request.QueryString["charId"];
                courses readModel = controllerProvider.instance().selectCoursesByCharId(editModel);
                number.Value = readModel.number;
                title.Value = readModel.title;
                hiContents.Value = readModel.contents;
            }
        }
    }
}