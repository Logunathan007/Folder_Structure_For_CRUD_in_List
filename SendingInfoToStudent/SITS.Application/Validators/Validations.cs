using FluentValidation;
using SITS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SITS.Application.Validators
{
    public  class StudentValidations : AbstractValidator<Student>
    {
        public StudentValidations() {
            RuleFor(x => x.StudentId).NotEmpty().WithMessage("Id is empty");
            RuleFor(x => x.Name).NotEmpty().MinimumLength(1).MaximumLength(50);
        }
    }
    public class StudentDetailsValidations : AbstractValidator<StudentDetail>
    {
        public StudentDetailsValidations()
        {
            RuleFor(x => x.StudentId).NotEmpty().WithMessage("Id is empty");
            RuleFor(x => x.FatherName).NotEmpty().MinimumLength(1).MaximumLength(50);
            RuleFor(x => x.Email).EmailAddress().WithMessage("Not a valid Email Address");
            RuleFor(x => x.PhoneNumber).Length(10).WithMessage("Phone number count must be 10");
        }
    }
}
