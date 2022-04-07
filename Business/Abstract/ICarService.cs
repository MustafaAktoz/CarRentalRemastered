using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int id);
        IDataResult<List<Car>> GetAll();
        IDataResult<List<CarDetailDTO>> GetDetails();
        IDataResult<List<Car>> GetAllByBrandId(int brandId);
        IDataResult<List<Car>> GetAllByColorId(int colorId);
    }
}
