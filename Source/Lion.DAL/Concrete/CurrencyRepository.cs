﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.DAL.Abstract;
using Lion.Domain.Models;

namespace Lion.DAL.Concrete
{
    public class CurrencyRepository:GenericRepository<Currency>,ICurrencyRepository
    {
        public Currency GetCurrency(short id)
        {
            return GetAll().FirstOrDefault(x => x.CurrencyID == id);
        }
    }
}
