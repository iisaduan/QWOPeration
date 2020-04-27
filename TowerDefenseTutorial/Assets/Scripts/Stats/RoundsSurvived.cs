using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text roundsText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    /* AnimateTest
     * 
     * a coroutine that counts up from 0 to the number of rounds the user has survived
     * 
     */
    IEnumerator AnimateText()
    {
        int round = 0;
        roundsText.text = "0";

        yield return new WaitForSeconds(0.7f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            roundsText.text = round.ToString();

            yield return new WaitForSeconds(0.05f);
        }
    }
}
