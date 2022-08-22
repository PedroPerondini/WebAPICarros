using FluentValidation;
using WebAPICarros.Domain.Model;

namespace WebAPICarros.Domain.Validation
{
    public class UserValidation : AbstractValidator<User>
    {
        private const string _defaultInvalidMessage = "Informed parameter {0} is invalid.";

        public UserValidation()
        {
            RuleFor(user => user.Id)
                .NotNull()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(User.Id)));

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(User.Password)));

            RuleFor(user => user.Role)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(User.Role)));

            RuleFor(user => user.Username)
                .NotEmpty()
                .WithMessage(string.Format(_defaultInvalidMessage, nameof(User.Username)));
        }
    }
}
