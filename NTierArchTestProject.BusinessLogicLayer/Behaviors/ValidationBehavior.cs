using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierArchTestProject.BusinessLogicLayer.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : class,
        IRequest<TResponse>
    {
        //AbstractValidator Inherit etmiş sınıflarım için liste halinde tuttum
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        //Mediatr design patternda handlerlara gelmeden araya girerek validation kurallarını araya sokarak sonra delegate kısmıyla handlerlara yönlendireceğiz.
        //Delegeta,işlemden önce veya sonra araya girebileceğimi belirtir.
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //ilk önce AbstractValidator alan sınıfım var mı? yani validasyon işlemi yapılacak bir sınıf mevcutmu
            if (!_validators.Any()) return await next();//RequestHandlere devam et

            var context = new ValidationContext<TRequest>(request);

            var errorDictionary = _validators
                .Select(x => x.Validate(context))//içerilen validation kurallarında doğrulanmış değerleri seç
                .SelectMany(x => x.Errors)
                .Where(s => s != null)
                .GroupBy(
                z => z.PropertyName, y => y.ErrorMessage,
                (propertyName, errorMessage) => new
                {
                    key = propertyName,
                    values = errorMessage.Distinct().ToArray()//aynı hatalar birden fazla varsa teke düşür
                })
                .ToDictionary(s => s.key, y => y.values[0]);

            if (errorDictionary.Any())
            {
                var errors = errorDictionary.Select(s => new ValidationFailure
                {
                    PropertyName = s.Value,
                    ErrorCode = s.Key
                });

                throw new ValidationException(errors);
            }
            
            return await next();
        }
    }
}
