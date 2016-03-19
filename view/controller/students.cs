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

        private static controllerProvider controller = null;

        private controllerProvider() { }

        public static controllerProvider instance()
        {
            return controller == null ? new controllerProvider() : controller;
        }
    }
}