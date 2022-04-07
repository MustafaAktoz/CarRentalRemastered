using Core.DataAccess.Concrete.InMemory;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class IMColorDal : IMEntityRepositoryBase<Color>, IColorDal
    {
    }
}
