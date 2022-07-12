using System.Text;

var name = "Cesar";
var base64 = name.EncodeBase64();
var decode64 = base64.DecodeBase64();

Console.WriteLine(name);
Console.WriteLine(base64);
Console.WriteLine(decode64);

public static class StringExtensions {
    public static string EncodeBase64(this string value) {
        var plainTextBytes = Encoding.UTF8.GetBytes(value);
        return Convert.ToBase64String(plainTextBytes);
    }

    public static string DecodeBase64(this string value) {
        var base64EncodedBytes = Convert.FromBase64String(value);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }
}