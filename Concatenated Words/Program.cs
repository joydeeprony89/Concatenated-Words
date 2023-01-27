// See https://aka.ms/new-console-template for more information
var words = new string[] { "cat", "cats", "catsdogcats", "dog", "dogcatsdog", "hippopotamuses", "rat", "ratcatdogcat" };
Solution s = new Solution();
var answer = s.FindAllConcatenatedWordsInADict(words);
Console.WriteLine(string.Join(",", answer));

public class Solution
{
  public IList<string> FindAllConcatenatedWordsInADict(string[] words)
  {
    /*
     * step 1 - create a Hash using the words
     * step 2 - for each word in words check substrings are also present in words
     * Optimise 1 - get the minimum length of the word from the array, so we try finding the substring of min length at least always
     * Optimise 2 - have a visited set
     */

    var result = new List<string>();
    var set = new HashSet<string>();
    var visited = new HashSet<string>();
    int min = int.MaxValue;
    foreach (var word in words)
    {
      set.Add(word);
      min = Math.Min(min, word.Length);
    }
    foreach (string word in words)
    {
      if (Check(word))
      {
        result.Add(word);
      }
    }

    bool Check(string word) 
    {
      if (visited.Contains(word)) return true;
      for(int i = min; i <= word.Length - min; i++)
      {
        string left = word.Substring(0, i);
        string right = word.Substring(i);
        if (set.Contains(left))
        {
          if (set.Contains(right) || Check(right))
          {
            visited.Add(word);
            return true;
          }
        }
      }
      return false;
    }
    return result;
  }
}