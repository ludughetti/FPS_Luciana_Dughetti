using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int killCountToWin = 50;
    [SerializeField] private TMP_Text killCountText;

    private int _killCount = 0;

    public void AddKillToCounter()
    {
        _killCount++;
        UpdateKillCounterText();

        if (_killCount == killCountToWin)
        {
            Debug.Log($"{name}: Player won!");
        }
    }

    private void UpdateKillCounterText()
    {
        killCountText.text = _killCount.ToString();
    }
}
