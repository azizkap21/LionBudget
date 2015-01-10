using System;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Lion.Domain.Models;
using Lion.DAL.Abstract;

namespace Lion.Business
{
    public interface IRepositoryContainer
    {

        IAddressTypeRepository AddressTypeRepository { get; }

        IBudgetRepository BudgetRepository { get;  }

        ICountryDetailRepository CountryDetailRepository { get;  }

        ICurrencyRepository CurrencyRepository { get;  }

        ILedgerAccountAddressRepository LedgerAccountAddressRepository { get;  }

        ILedgerAccountRepository LedgerAccountRepository { get;  }

        ISecurityQuestionRepository SecurityQuestionRepository { get;  }

        IUserAccountAddressRepository UserAccountAddressRepository { get;  }

        IUserAccountRepository UserAccountRepository { get;  }

        IUserStatusRepositoryRepository UserStatusRepository { get;  }

        IVoucherDetailRepository VoucherDetailRepository { get;  }

        IVoucherHeaderRepository VoucherHeaderRepository { get;  }

        IVoucherTypeRepository VoucherTypeRepository { get;  }
        
    }
}
