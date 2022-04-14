using Core.DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDTO> GetDetails(Expression<Func<Car,bool>> filter=null);
        CarDetailDTO GetDetail(Expression<Func<Car,bool>> filter);
    }
}
