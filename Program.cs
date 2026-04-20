var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// REPLACE THIS with your actual email slug, e.g. "john_doe_gmail_com"
const string emailSlug = "your_email_here";

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

static long? ParseNatural(string? s)
{
    if (s is null) return null;
    // Reject floats and scientific notation
    if (s.Contains('.') || s.Contains('e') || s.Contains('E')) return null;
    if (!long.TryParse(s, out long n)) return null;
    if (n < 0) return null;
    return n;
}

static long Lcm(long a, long b)
{
    if (a == 0 || b == 0) return 0;
    return a / Gcd(a, b) * b;
}

static long Gcd(long a, long b)
{
    while (b != 0) { (a, b) = (b, a % b); }
    return a;
}
