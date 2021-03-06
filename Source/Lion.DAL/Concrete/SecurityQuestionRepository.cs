﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lion.DAL.Abstract;
using Lion.Domain.Models;

namespace Lion.DAL.Concrete
{
    public class SecurityQuestionRepository:GenericRepository<SecurityQuestion>,ISecurityQuestionRepository
    {
        public SecurityQuestion GetSecurityQuestion(short id)
        {
            return GetAll().FirstOrDefault(x => x.SecurityQuestionID == id);
        }
    }
}
