using System;

namespace Assignment7_V2.Extensions;
public static class EnumExtensions
{
    /// <summary>Replaces underscore with space in any enum</summary>
    /// <typeparam name="T">Generic Enum</typeparam>
    /// <param name="tEnum">Enum member</param>
    /// <returns></returns>
    public static string ReplaceUnderscore<T>(this T tEnum) where T : Enum
    {
        return tEnum.ToString().Replace('_', ' ');
    }
}
