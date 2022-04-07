using Core.DataAccess.Concrete.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class IMCarDal:IMEntityRepositoryBase<Car>,ICarDal
    {
    }
}
