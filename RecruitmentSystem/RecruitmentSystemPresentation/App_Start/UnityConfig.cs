using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using System.Linq;
using System.Web;
using Unity.Mvc5;
using RecruitmentSystemBusiness;
using System.Web.Mvc;

namespace RecruitmentSystemPresentation.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IBusinessData, BusinessData>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}