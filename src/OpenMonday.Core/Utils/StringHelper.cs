using System.Text.RegularExpressions;

public static class StringHelper
{
    public static string ToUpperOrStringEmpty(string val)
    {
        if (val != null)
        {
            return val.ToUpper();
        }
        else
        {
            return string.Empty;
        }
    }

    public static string ToStringOrStringEmpty(string val)
    {
        if (val != null)
        {
            return val;
        }
        else
        {
            return string.Empty;
        }
    }

    public static string GetBoardIdFromLinkString(string linkstring)
    {
        if (linkstring != null)
        {
            string pattern = @"\d+$";
            var match = Regex.Match(linkstring, pattern);
            if (match.Success)
            {
               return match.Value;
            }
            else
            {
                return string.Empty;
            }
        }
        else
        {
            return string.Empty;
        }
    }
}