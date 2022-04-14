using Core.Exceptions.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Exceptions.Concrete
{
    public class FileHelperCustomException:Exception, ICustomException
    {
        public FileHelperCustomException(string message):base(message)
        {

        }
    }
}
