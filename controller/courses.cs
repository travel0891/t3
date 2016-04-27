using System;
using System.Collections.Generic;
using System.Web;

namespace controller
{
    using model.table;
    using model.entity;

    public partial class controllerProvider
    {
        public courses selectCoursesByCharId(courses model)
        {
            return entityProvider.instance().selectCoursesByCharId(model.charId);
        }

        public List<courses> selectCourses()
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectCourses(Int32.MaxValue, 1, out dataCount, out pageCount, null, null);
        }

        /// <summary>
        /// doCourses
        /// </summary>
        /// <param name="type">1 insert 2 update 3 delete</param>
        /// <param name="model">Courses</param>
        /// <returns>Boolean</returns>
        public Boolean doCourses(Int32 type, courses model)
        {
            Boolean ef = false;
            switch (type)
            {
                case 1:
                    ef = entityProvider.instance().insertCourses(model) > 0 ? true : false;
                    break;
                case 2:
                    ef = entityProvider.instance().updateCourses(model) > 0 ? true : false;
                    break;
                case 3:
                    ef = entityProvider.instance().deleteCourses(model) > 0 ? true : false;
                    break;
            }
            return ef;
        }
    }
}