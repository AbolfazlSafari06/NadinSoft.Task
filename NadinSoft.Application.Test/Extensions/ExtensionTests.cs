using NadinSoft.Application.Contract.Extension;
using Xunit;

namespace NadinSoft.Application.Test.Extensions;

public class ExtensionTests 
{
    [Theory]
    [InlineData(true, "")]
    [InlineData(true,null)]
    [InlineData(false, "TEST")]
    public void String_Extension_Should_Work_Properly(bool excepted, string value)
    {
        var result = value.IsNullOrEmpty();

        Assert.Equal(excepted, result);
    }

    [Fact] 
    public void DateTime_Extension_Should_Work_Properly()
    {
        var dateTimeString = "2023-07-22T08:47:34.029Z";
        var exceptedPersiandateTimeString = "1402/04/31";
        var dateTime = Convert.ToDateTime(dateTimeString);
        var actual = dateTime.ToPersianDate();

        Assert.Equal(exceptedPersiandateTimeString, actual);
    }
}