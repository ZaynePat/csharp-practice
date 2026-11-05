int[] scores = new int[3];        // room for 3 ints, all start at 0
scores[0] = 85;
scores[1] = 92;
scores[2] = 78;

int[] ages = { 20, 25, 30 };      // shortcut: create and fill at once

Console.WriteLine(scores.Length); // 3 (arrays use Length, lists use Count)
Console.WriteLine(scores[1]);     // 92

foreach (int s in scores)
{
    Console.WriteLine(s);
}