namespace Api.Infrastructure.Validation
{
    using FluentValidation.Results;

    public class ErrorMessage
    {
        public ErrorMessage(ValidationFailure validationFailure)
        {
            Message = validationFailure.ErrorMessage;
            Code = validationFailure.ErrorCode;
        }

        public string Message { get; set; }
        public string Code { get; set; }
    }
}