namespace OndatoCacheSolution.Domain.Dtos.Base
{
    public abstract class CreateCacheItemDto<T>
    {
        public string Key { get; set; }

        public T Value { get; set; }

        public string Offset { get; set; }
    }
}
