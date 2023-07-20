using System.Text.RegularExpressions;

namespace SchoolManagement.Services.Sciences.Extensions;

public static class StringExtensions
{
    public static string ToNormalized(this string value) => Regex.Replace(value.ToLower(), @"\s+", "-");
}