namespace Core.Utilities.Result
{
    public interface IDataResult<T>:IResult
    {
        public T Data { get; }
    }
}
