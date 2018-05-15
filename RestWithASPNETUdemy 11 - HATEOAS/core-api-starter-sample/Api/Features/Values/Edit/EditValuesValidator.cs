namespace Api.Features.Values.Edit
{
    using FluentValidation;
    using Infrastructure.Validation;

    public class EditValuesValidator : AbstractValidator<EditValuesRequest>
    {
        public EditValuesValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0).Must(Exist).WithErrorCode(ValidationErrorCode.NotFound);
            RuleFor(request => request.Value).NotEmpty();
        }

        private bool Exist(int valueId)
        {
            //Check if Value exists

            return valueId <= 5;
        }
    }
}