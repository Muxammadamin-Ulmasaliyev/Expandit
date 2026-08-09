using Expandit.Helpers;

namespace Expandit.Tests;

public class TextShortcutValidatorTests
{
    [Fact]
    public void IsValid_ReturnsTrue_WhenAllFieldsPopulated()
    {
        Assert.True(TextShortcutValidator.IsValid("By the way", "btw", "by the way"));
    }

    [Theory]
    [InlineData("", "btw", "by the way")]
    [InlineData("Name", "", "by the way")]
    [InlineData("Name", "btw", "")]
    [InlineData("   ", "btw", "by the way")]
    [InlineData(null, "btw", "by the way")]
    public void IsValid_ReturnsFalse_WhenAnyFieldIsEmptyOrWhitespace(string? name, string key, string value)
    {
        Assert.False(TextShortcutValidator.IsValid(name, key, value));
    }
}
