namespace Api.Features.Values.Create
{
    using FluentValidation;

    public class CreateValuesValidator : AbstractValidator<CreateValuesRequest>
    {
        public CreateValuesValidator()
        {
            RuleFor(request => request.Value).NotEmpty();
        }
    }
}