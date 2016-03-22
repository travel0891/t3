using System;
using System.Collections.Generic;
using System.Web;

namespace view.controller
{
    using model.table;
    using model.entity;

    public class controllerProvider
    {
        public Boolean selectAccount(students model)
        {
            students tempModel = entityProvider.instance().selectStudentsByAccount(model);
            return tempModel == null ? false : true;
        }

        public students selectStudents(students model)
        {
            return entityProvider.instance().selectStudents(model);
        }

        public students selectStudentsByCharId(students model)
        {
            return entityProvider.instance().selectStudentsByCharId(model.charId);
        }

        public List<students> selectStudents()
        {
            Int32 dataCount = 0, pageCount = 0;
            return entityProvider.instance().selectStudents(null, Int32.MaxValue, 1, out dataCount, out pageCount);
        }

        /// <summary>
        /// doStudent
        /// </summary>
        /// <param name="type">1 insert 2 update 3 delete</param>
        /// <param name="model"></param>
        /// <returns></returns>
        public Boolean doStudent(Int32 type, students model)
        {
            Boolean ef = false;
            switch (type)
            {
                case 1:
                    ef = entityProvider.instance().insertStudents(model) > 0 ? true : false;
                    break;
                case 2:
                    ef = entityProvider.instance().updateStudents(model) > 0 ? true : false;
                    break;
                case 3:
                    ef = entityProvider.instance().deleteStudents(model) > 0 ? true : false;
                    break;
            }
            return ef;
        }

        private static controllerProvider controller = null;

        private controllerProvider() { }

        public static controllerProvider instance()
        {
            return controller == null ? new controllerProvider() : controller;
        }
    }
}