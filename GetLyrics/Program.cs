using System;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using GetLyrics;



string troubleTaylorSwift = "72jCZdH0Lhg93z6Z4hBjgj";
string antiheroTaylorSwift = "0V3wPSX9ygBnCm8psDIegu";
string blankspaceTaylorSwift = "7flrjP7Dag40j2Fw8TX4iC";
string lovestoryTaylorSwift = "7flrjP7Dag40j2Fw8TX4iC";
string badbloodTaylorSwift = "7flrjP7Dag40j2Fw8TX4iC";
string songName = "";




var Songs = new string[] { "Trouble", "Anti-Hero", "Blank-Space", "Love Story", "Bad Blood"};
Console.WriteLine("Which of these songs would you like the lyrics to?");

for (int i = 0; i < Songs.Length; i++)
{
    Console.WriteLine($"{i + 1} {Songs[i]}");
}

int input = int.Parse(Console.ReadLine());
switch (input)
{
    case 1:
        songName = troubleTaylorSwift;
        break;
    case 2:
        songName = antiheroTaylorSwift;
        break;
    default:
        break;
}


var client = new HttpClient();
var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    RequestUri = new Uri($"https://spotify23.p.rapidapi.com/track_lyrics/?id={songName}"),
    Headers =
    {
        { "X-RapidAPI-Key", "d37724f31amsh5b7b473995b9699p1dd08djsn1424a0334a39" },
        { "X-RapidAPI-Host", "spotify23.p.rapidapi.com" },
    },
};
//using (var response = await client.SendAsync(request))
//{
//    response.EnsureSuccessStatusCode();
//    var body = await response.Content.ReadAsStringAsync();
//    Line line = JsonConvert.DeserializeObject<Line>(body);
//    Lyrics lyrics = JsonConvert.DeserializeObject<Lyrics>(body);
//    Console.WriteLine(lyrics);
//}

using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    var body = await response.Content.ReadAsStringAsync();
    Console.WriteLine(body); // Debugging statement to print the raw JSON response
    try
    {
        Lyrics lyrics = JsonConvert.DeserializeObject<Lyrics>(body);
        Line[] linez = lyrics.lines;
        foreach (var item in linez)
        {
            Console.WriteLine(item.words);
        }
        //Console.WriteLine(linez + "Is this working?"); // Prints only the lyrics property
        //Console.WriteLine(lyrics.syncType);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Error deserializing JSON: " + ex.Message);
    }
}

