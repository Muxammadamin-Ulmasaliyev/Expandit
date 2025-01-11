
using Expandit.Models;
using System.Data;

namespace Expandit.Helpers;

public static class DynamicPlaceholderHelper
{
    public static string CalculateStringExpression(DynamicPlaceholder placeholder, string userInput)
    {
        var array = userInput.Split('?');

        if (array.Length == 1)
        {
            return string.Empty;
        }
        else
        {
            return new DataTable().Compute(array[1], null).ToString();
        }

    }
}
