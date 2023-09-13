using System.IO;
using System.Text.RegularExpressions;

string textPath = @"C:\Users\zacharie.montreuil\source\repos\W23\IOLesson\IOLesson\theMachineStops.txt";

FileInfo textFile = new FileInfo(textPath);

string fullText = "";

using(StreamReader reader = textFile.OpenText())
{
    fullText = reader.ReadToEnd();
}

List<string> words = GetWordList(fullText);
Dictionary<string, int> wordCount = GetWordCounts(words);

foreach(KeyValuePair<string, int> word in wordCount)
{
    Console.WriteLine($"{word.Key}: {word.Value}");
}

List<string> GetWordList(string text)
{
    // normalize by setting to lower case
    text = text.ToUpper();

    char[] delimiters = new char[] { ',', '.', ';', ':', '!', '?', '-', '—', '(', ')', '[', ']', '{', '}', '<', '>', '/', '\\', '|', '_', '*', '&', '#', '@', '%', '$', '^', '=', '+', '~', '`', '"', ' ', '\n', '\r' };


    List<string> words = text.Split(delimiters).ToList();

    words.RemoveAll(s => s == "");
    return words;
}

Dictionary<string, int> GetWordCounts(ICollection<string> words)
{
    Dictionary<string, int> wordCount = new Dictionary<string, int>();

    foreach(string s in words)
    {
        if(wordCount.ContainsKey(s)) {
            wordCount[s]++;
        } else
        {
            wordCount.Add(s, 1);
        }
    }

    return wordCount;
}
