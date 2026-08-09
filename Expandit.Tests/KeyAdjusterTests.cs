using Expandit.Helpers;

namespace Expandit.Tests;

public class KeyAdjusterTests
{
    [Theory]
    [InlineData(Keys.Enter)]
    [InlineData(Keys.Tab)]
    [InlineData(Keys.LWin)]
    [InlineData(Keys.LControlKey)]
    [InlineData(Keys.CapsLock)]
    [InlineData(Keys.F5)]
    public void IsSpecialKey_ReturnsTrue_ForNonPrintingKeys(Keys key)
    {
        Assert.True(KeyAdjuster.IsSpecialKey(key));
    }

    [Theory]
    [InlineData(Keys.A)]
    [InlineData(Keys.D1)]
    [InlineData(Keys.Space)]
    [InlineData(Keys.Oem1)]
    public void IsSpecialKey_ReturnsFalse_ForPrintableKeys(Keys key)
    {
        Assert.False(KeyAdjuster.IsSpecialKey(key));
    }
}
