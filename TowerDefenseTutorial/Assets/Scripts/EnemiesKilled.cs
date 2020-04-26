using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesKilled : MonoBehaviour
{
    public Text enemiesKilled;

    /* DictionaryToString
     * 
     * helper method that converts a dictionary string
     * strings as keys and ints as values to an output string that will be
     * displayed on the GameOver screen
     */
    public string DictionaryToString(Dictionary<string, int> dictionary)
    {
        string dictionaryString = "";
        if (dictionary.Count != 0)
        {
            foreach (KeyValuePair<string, int> keyValues in dictionary)
            {
                dictionaryString += keyValues.Key.Substring(0, keyValues.Key.Length - 7) + " : " + keyValues.Value.ToString() + ", \n";
            }
            dictionaryString = dictionaryString.TrimEnd('\n');
            return dictionaryString.Substring(0, dictionaryString.Length - 2);
        }
        // if the dictionary is empty, just return an empty string
        return dictionaryString;
    }

    void OnEnable()
    {
        enemiesKilled.text = DictionaryToString(PlayerStats.enemiesKilled);
    }

}
