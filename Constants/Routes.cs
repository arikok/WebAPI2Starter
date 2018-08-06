using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WepAPI2Starter.Constants
{
    public class Routes
    {

        public const string sample = "sample";

        public static class Common
        {
            public const string AllRoutes = "admin/common/allroutes";
        }

        public static class SampleService
        {
            public const string Sample = "sampleservice/sample";
        }

        public static class UserManagementService
        {
            public const string ChangeEmailOfUser = "admin/usermanagementservice/changeemailofuser";
        }

    }
}