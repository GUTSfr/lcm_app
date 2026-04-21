using System.Numerics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string emailSlug = "akmalnomad1501_gmail_com";

app.MapGet($"/{emailSlug}", (string? x, string? y) =>
{
    var parsedX = ParseNatural(x);
    var parsedY = ParseNatural(y);
    if (parsedX is null || parsedY is null)
        return Results.Text("NaN");
    var result = Lcm(parsedX.Value, parsedY.Value);
    return Results.Text(result.ToString());
});

app.Run();

static BigInteger? ParseNatural(string? s)
{
    if (s is null) return null;
    if (s.Contains('.') || s.Contains('e') || s.Contains('E')) return null;
    if (!BigInteger.TryParse(s, out BigInteger n)) return null;
    if (n <= 0) return null;
    return n;
}

static BigInteger Lcm(BigInteger a, BigInteger b)
{
    return a / BigInteger.GreatestCommonDivisor(a, b) * b;
}
