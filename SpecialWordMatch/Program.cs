using System.Text.RegularExpressions;

string text = "This is a {sample} [text].";
var dictionary = new Dictionary<string, string>();

// Özel kelimeleri bul ve değiştir
text = Regex.Replace(text, @"({.*?}|\[.*?\])", match =>
{
    string key = match.Value;
    if (!dictionary.ContainsKey(key))
    {
        // Rastgele bir 6 karakterli dize oluşturun
        string randomString = GenerateRandomString(6);
        dictionary.Add(key, randomString);
    }

    // Özel kelimeyi rastgele dizeyle değiştirin
    return dictionary[key];
});

Console.WriteLine(text);

foreach (var item in dictionary)
{
    text = text.Replace(item.Value, item.Key);
}

Console.WriteLine(text);

static string GenerateRandomString(int length)
{
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    var random = new Random();
    return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
}