using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int killCountToWin = 50;
    [SerializeField] private TMP_Text killCountText;
    [SerializeField] private EndgameController endgameController;

    private int _killCount = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void AddKillToCounter()
    {
        _killCount++;
        UpdateKillCounterText();

        if (_killCount == killCountToWin)
        {
            TriggerEndgameScreen(true);
        }
    }

    private void UpdateKillCounterText()
    {
        killCountText.text = _killCount.ToString();
    }

    public void TriggerEndgameScreen(bool isVictory)
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        endgameController.ShowEndgameScreen(isVictory, _killCount);
    }
}
