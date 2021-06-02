using FluentValidation;

namespace FlightManagement.Application.Features.Airports.Commands.CreateAirport
{
    public class CreateAirportCommandValidator : AbstractValidator<CreateAirportCommand>
    {
        public CreateAirportCommandValidator()
        {
            RuleFor(q => q.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");

            RuleFor(q => q.IcaoCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .Length(4).WithMessage("{PropertyName} must be 4 characters.");

            RuleFor(q => q.IataCode)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .Length(3).WithMessage("{PropertyName} must be 3 characters.");

            RuleFor(q => q.Latitude)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(q => q.Longitude)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
        }
    }
}