namespace Api.Infrastructure.Validation
{
    using System.Linq;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR.Pipeline;

    public class ValidationPreProcessor<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly IValidator<TRequest>[] _validators;

        public ValidationPreProcessor(IValidator<TRequest>[] validators)
        {
            _validators = validators;
        }

        public Task Process(TRequest request)
        {
            var context = new ValidationContext(request);

            var failures = _validators.Select(validator => validator.Validate(context))
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailure => validationFailure != null)
                .ToList();

            if (failures.Any())
                throw new ValidationException(failures);

            return Task.FromResult(0);
        }
    }
}