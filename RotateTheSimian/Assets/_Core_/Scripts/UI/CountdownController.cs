using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class CountdownController : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private List<string> countdownStrings;

    [Header("References")]
    [SerializeField] public TextMeshProUGUI countdownUIText;

    public Action CountdownEnded;

    public void StartCountdown()
    {
        StartCoroutine(Countdown());
    }

    private IEnumerator Countdown()
    {
        for (int i = 0; i < countdownStrings.Count - 1; i++)
        {
            countdownUIText.text = countdownStrings[i];
            yield return new WaitForSeconds(1.0f);
        }

        countdownUIText.text = countdownStrings[countdownStrings.Count - 1];
        CountdownEnded?.Invoke();

        yield return new WaitForSeconds(1.0f);

        countdownUIText.text = "";
    }
}
