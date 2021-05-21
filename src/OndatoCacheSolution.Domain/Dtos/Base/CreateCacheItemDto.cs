namespace OndatoCacheSolution.Domain.Dtos.Base
{
    public class CreateCacheItemDto<TKey, T>
    {
        public TKey Key { get; set; }

        public T Value { get; set; }

        public string Offset { get; set; }
    }
}
