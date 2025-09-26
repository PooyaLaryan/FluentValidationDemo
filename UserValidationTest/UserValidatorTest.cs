using FluentValidation.TestHelper;
using FluentValidationDemo.Dtos;
using FluentValidationDemo.Validators;

namespace UserValidationTest;

public class UserValidatorTest
{
    private readonly UserValidator _validator;

    public UserValidatorTest()
    {
        _validator = new UserValidator();
    }

    [Fact]
    public void Should_Have_Error_When_FirstName_Is_Empty()
    {
        var model = new User { FirstName = "" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.FirstName);
    }

    [Fact]
    public void Should_Have_Error_When_Age_Is_Less_Than_18()
    {
        var model = new User { Age = 15 };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Age);
    }

    [Fact]
    public void Should_Have_Error_When_Email_Is_Invalid()
    {
        var model = new User { Email = "not-an-email" };
        var result = _validator.TestValidate(model);
        result.ShouldHaveValidationErrorFor(x => x.Email);
    }

    [Fact]
    public void Should_Not_Have_Error_When_User_Is_Valid()
    {
        var model = new User
        {
            FirstName = "Pouya",
            LastName = "Lariyan",
            Age = 30,
            Email = "test@example.com"
        };

        var result = _validator.TestValidate(model);
        result.ShouldNotHaveAnyValidationErrors();
    }
}
