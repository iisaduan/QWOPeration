using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretsBuilt : MonoBehaviour
{
    public Text turretsBuilt;

    /*
     * DictionaryToString is a helper method that converts a dictionary storing
     * strings as keys and ints as values to an output string that will be
     * displayed on the GameOver screen
     */
    public string DictionaryToString(Dictionary<string, int> dictionary)
    {
        string dictionaryString = "";
        foreach (KeyValuePair<string, int> keyValues in dictionary)
        {
            dictionaryString += keyValues.Key.Substring(0, keyValues.Key.Length) + " : " + keyValues.Value.ToString() + ", \n";
        }
        dictionaryString = dictionaryString.TrimEnd('\n');
        return dictionaryString.Substring(0, dictionaryString.Length - 2);
    }

    void OnEnable()
    {
        turretsBuilt.text = DictionaryToString(PlayerStats.turretsBuilt);
    }

}
