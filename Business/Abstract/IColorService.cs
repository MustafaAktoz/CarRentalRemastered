using Core.Utilities.Result;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IColorService
    {
        IResult Add(Color color);
        IResult Update(Color color);
        IResult Delete(Color color);
        IDataResult<Color> GetById(int id);
        IDataResult<List<Color>> GetAll();
    }
}
