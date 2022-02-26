using Xunit;
using IsbnValidator.Interfaces;
using IsbnValidator.Implementations;
using IsbnValidator.Common.Enums;

namespace Tests;

public class UnitTest1
{
    [Theory]
    [InlineData("0-471-19047-0")]
    [InlineData("0-471-19077-0")]
    public void TenTest(string isbn)
    {
        IIsbnValidator isbnValidator = IsbnValidatorResolver.Resolve(IsbnScheme.Ten);
        bool isValid = isbnValidator.Validate(isbn);
        if (isbn.Equals("0-471-19047-0"))
            Assert.Equal(isValid, true);
        else if (isbn.Equals("0-471-19077-0"))
            Assert.Equal(isValid, false);
    }

    [Theory]
    [InlineData("9781861972712")]
    [InlineData("9781681972712")]
    public void ThirteenTest(string isbn)
    {
        IIsbnValidator isbnValidator = IsbnValidatorResolver.Resolve(IsbnScheme.Thirteen);
        bool isValid = isbnValidator.Validate(isbn);
        if (isbn.Equals("9781861972712"))
            Assert.Equal(isValid, true);
        else if (isbn.Equals("9781681972712"))
            Assert.Equal(isValid, false);
    }

}
