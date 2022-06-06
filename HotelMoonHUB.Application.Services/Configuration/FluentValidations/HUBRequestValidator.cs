using FluentValidation;

namespace HotelMoonHUB.Application.Services.Configuration.FluentValidations
{
    public class HUBRequestValidator : AbstractValidator<HUBRequest>
    {
        public HUBRequestValidator()
        {
            Include(new NullHotelId());
            Include(new NullCheckIn());
            Include(new NullCheckOut());
            Include(new NullNumberOfGuests());
            Include(new NullNumberOfRooms());
            Include(new NullCurrency());
            Include(new HotelIdUnder0());
            Include(new NumberOfGuestsUnder0());
            Include(new NumberOfRoomsUnder0());
        }
    }

    public class NullHotelId : AbstractValidator<HUBRequest>
    {
        public NullHotelId()
        {
            RuleFor(HUBRequest => HUBRequest.hotelId)
                .NotEmpty().WithMessage(FluentValidantionsMessages.EmpyHotelId);
        }
    }

    public class NullCheckIn : AbstractValidator<HUBRequest>
    {
        public NullCheckIn()
        {
            RuleFor(HUBRequest => HUBRequest.checkIn)
                .NotEmpty().WithMessage(FluentValidantionsMessages.EmpyCheckIn);
        }
    }

    public class NullCheckOut : AbstractValidator<HUBRequest>
    {
        public NullCheckOut()
        {
            RuleFor(HUBRequest => HUBRequest.checkOut)
                .NotEmpty().WithMessage(FluentValidantionsMessages.EmpyCheckOut);
        }
    }

    public class NullNumberOfGuests : AbstractValidator<HUBRequest>
    {
        public NullNumberOfGuests()
        {
            RuleFor(HUBRequest => HUBRequest.numberOfGuests)
                .NotEmpty().WithMessage(FluentValidantionsMessages.EmpyNumberOfGuests);
        }
    }

    public class NullNumberOfRooms : AbstractValidator<HUBRequest>
    {
        public NullNumberOfRooms()
        {
            RuleFor(HUBRequest => HUBRequest.numberOfRooms)
                .NotEmpty().WithMessage(FluentValidantionsMessages.EmpyHotelId);
        }
    }

    public class NullCurrency : AbstractValidator<HUBRequest>
    {
        public NullCurrency()
        {
            RuleFor(HUBRequest => HUBRequest.currency)
                .NotEmpty().WithMessage(FluentValidantionsMessages.NullCurrency);
        }
    }

    public class HotelIdUnder0 : AbstractValidator<HUBRequest>
    {
        public HotelIdUnder0()
        {
            RuleFor(HUBRequest => HUBRequest.hotelId)
                .GreaterThan(0).WithMessage(FluentValidantionsMessages.HotelIdUnder0);
        }
    }

    public class NumberOfGuestsUnder0 : AbstractValidator<HUBRequest>
    {
        public NumberOfGuestsUnder0()
        {
            RuleFor(HUBRequest => HUBRequest.numberOfGuests)
                .GreaterThan(0).WithMessage(FluentValidantionsMessages.NumberOfGuestsUnder0);
        }
    }

    public class NumberOfRoomsUnder0 : AbstractValidator<HUBRequest>
    {
        public NumberOfRoomsUnder0()
        {
            RuleFor(HUBRequest => HUBRequest.numberOfRooms)
                .GreaterThan(0).WithMessage(FluentValidantionsMessages.NumberOfRoomsUnder0);
        }
    }
}
