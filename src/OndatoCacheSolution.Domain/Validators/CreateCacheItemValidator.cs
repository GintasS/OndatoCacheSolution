using FluentValidation;
using Microsoft.Extensions.Options;
using OndatoCacheSolution.Domain.Models;
using OndatoCacheSolution.Domain.Settings;

namespace OndatoCacheSolution.Domain.Validators
{
    public class CreateCacheItemValidator<T> : AbstractValidator<CacheItem<T>>
    {

        public CreateCacheItemValidator(IOptions<CacheSettings> cacheSettings)
        {

            RuleFor(x => x.ExpiresAfter)
                .LessThanOrEqualTo(cacheSettings.Value.MaxExpirationPeriod);
        }
    }
}
