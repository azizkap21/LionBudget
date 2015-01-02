using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleInjector;
using Lion.DAL.Abstract;
using Lion.DAL.Concrete;

namespace Lion.API.App_Start
{
    public class RegisterContainer
    {
        Container container = new Container();

        public RegisterContainer()
        {
            container.RegisterSingle<AddressTypeRepository>(new AddressTypeRepository());

           
        }
    }
}