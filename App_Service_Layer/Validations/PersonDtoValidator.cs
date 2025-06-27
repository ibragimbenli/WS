using FluentValidation;
using App_Service_Layer.DTOs;

public class PersonDtoValidator : AbstractValidator<CreatePersonDto>
{
    public PersonDtoValidator()
    {
        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Ad boş olamaz")
            .MinimumLength(2).WithMessage("Ad en az 2 karakter olmalı");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Soyad boş olamaz");

        RuleFor(x => x.BirthDate)
            .LessThan(DateTime.Now).WithMessage("Doğum tarihi gelecekte olamaz");

        RuleFor(x => x.BirthDate)
            .Must(date => DateTime.Now.Year - date.Year >= 18)
            .WithMessage("18 yaşından küçükler sisteme eklenemez");
    }
}
