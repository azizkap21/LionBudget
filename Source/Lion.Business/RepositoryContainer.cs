using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.DAL.Abstract;
using Lion.DAL.Concrete;
using SimpleInjector;



namespace Lion.Business
{
    public class RepositoryContainer : IRepositoryContainer
    {

        static Container _container;


        public RepositoryContainer()
        {

        }


        public RepositoryContainer(Container container)
        {
            _container = container;
        }

        public IAddressTypeRepository AddressTypeRepository
        {
            get { return _container.GetInstance<IAddressTypeRepository>(); }
        }

        public IBudgetRepository BudgetRepository
        {
            get { return _container.GetInstance<IBudgetRepository>(); }
        }

        public ICountryDetailRepository CountryDetailRepository
        {
            get { return _container.GetInstance<ICountryDetailRepository>(); }
        }

        public ICurrencyRepository CurrencyRepository
        {
            get { return _container.GetInstance<ICurrencyRepository>(); }
        }

        public ILedgerAccountAddressRepository LedgerAccountAddressRepository
        {
            get { return _container.GetInstance<ILedgerAccountAddressRepository>(); }
        }

        public ILedgerAccountRepository LedgerAccountRepository
        {
            get { return _container.GetInstance<ILedgerAccountRepository>(); }
        }

        public ISecurityQuestionRepository SecurityQuestionRepository
        {
            get { return _container.GetInstance<ISecurityQuestionRepository>(); }
        }

        public IUserAccountAddressRepository UserAccountAddressRepository
        {
            get { return _container.GetInstance<IUserAccountAddressRepository>(); }
        }

        public IUserAccountRepository UserAccountRepository
        {
            get { return _container.GetInstance<IUserAccountRepository>(); }
        }

        public IUserStatusRepositoryRepository UserStatusRepository
        {
            get { return _container.GetInstance<IUserStatusRepositoryRepository>(); }
        }

        public IVoucherDetailRepository VoucherDetailRepository
        {
            get { return _container.GetInstance<IVoucherDetailRepository>(); }
        }

        public IVoucherHeaderRepository VoucherHeaderRepository
        {
            get { return _container.GetInstance<IVoucherHeaderRepository>(); }
        }

        public IVoucherTypeRepository VoucherTypeRepository
        {
            get { return _container.GetInstance<IVoucherTypeRepository>(); }
        }
    }

}
