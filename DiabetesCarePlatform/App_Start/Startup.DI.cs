using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Owin;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;

namespace DiabetesCarePlatform
{
    public partial class Startup
    {
        //這個方法主要用來組態系統的注入式相依性，請詳閱使用說明。
        public void ConfigureDI(IAppBuilder app)
        {
            //DI使用說明:
            // DI 注入式相依性是用來解決系統內相依性上耦合問題，
            // 以利事後開發維護上避免一次性修改其他不相干卻耦合的程式碼造成系統不穩定。
            //
            // 而先前使用DI上本人(Edward)有所誤解與MEF混淆，事實上兩者是完全不同的框架是不能混用的。
            // 給各位開發同仁一個觀念: DI是切開內部相依耦合的概念，MEF是用來切開內部與外部組件相依性的框架。
            // 開發初期可以不需要使用DI或根本完全不用看Owner決定

            //採用 Autofac 作為注入式相依性的框架

            //宣告DI容器建立器
            var builder = new ContainerBuilder();

            //註冊相依性至容器
            builder.RegisterType<Services.ZoomNetMeetingService>().As<Services.Interfaces.IZoomNetMeetingService>().InstancePerRequest();
            builder.RegisterInstance(new Helpers.ZoomSupports.ZoomNetMeetingRepository());
            builder.RegisterInstance(new Repository.WorkShiftRepository());

            //MVC整合註冊
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // OPTIONAL: Register model binders that require DI.
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();

            builder.RegisterModule<AutofacWebTypesModule>();

            // OPTIONAL: Enable property injection in view pages.
            builder.RegisterSource(new ViewRegistrationSource());

            // OPTIONAL: Enable property injection into action filters.
            builder.RegisterFilterProvider();

            IContainer Container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(Container));

            app.UseAutofacMiddleware(Container);
            app.UseAutofacMvc();
            
        }
    }
}