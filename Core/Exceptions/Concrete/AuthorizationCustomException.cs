using Core.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Exceptions.Concrete
{
    public class AuthorizationCustomException:Exception,ICustomException
    {
        public AuthorizationCustomException(string message):base(message)
        {

        }
    }
}
