using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SimpleInjector;
using Lion.DAL.Abstract;
using Lion.DAL.Concrete;
using Lion.Business;

namespace Lion.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeContainer();
        }

        private void InitializeContainer()
        {
            Container container = new Container();

            container.RegisterSingle<IAddressTypeRepository>(new AddressTypeRepository());
            container.RegisterSingle<ILedgerAccountAddressRepository >(new LedgerAccountAddressRepository());
            container.RegisterSingle<IBudgetRepository>(new BudgetRepository());
            container.RegisterSingle<ICountryDetailRepository>(new CountryDetailRepository());
            container.RegisterSingle<ICurrencyRepository>(new CurrencyRepository());
            container.RegisterSingle<ILedgerAccountRepository>(new LedgerAccountRepository());
            container.RegisterSingle<IUserAccountAddressRepository>(new UserAccountAddressRespository());
            container.RegisterSingle<IUserAccountRepository>(new UserAccountRepository());
            container.RegisterSingle<IUserStatusRepositoryRepository>(new UserStatusRepository());
            container.RegisterSingle<IVoucherDetailRepository>(new VoucherDetailRepository());
            container.RegisterSingle<IVoucherHeaderRepository>(new VoucherHeaderRepository());
            container.RegisterSingle<IVoucherTypeRepository>(new VoucherTypeRepository());

            IRepositoryContainer repoCon = new RepositoryContainer(container);



        }
    }
}
