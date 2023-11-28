using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI ScoreValue;
    [SerializeField]
    TextMeshProUGUI TimeValue;
    [SerializeField]
    GameObject GameOverPanel;
    [SerializeField]
    TextMeshProUGUI EndTreasureValue;
    [SerializeField]
    TextMeshProUGUI EndTimeValue;
    [SerializeField]
    TextMeshProUGUI EndOutcome;
    [SerializeField]
    string sVictoryText = "Congratulations you exterminated the bugs!";
    [SerializeField]
    string sLossText = "You ran out of time and the swarm spread";
    string sEndTimeValue;



    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreUI(0);
        UpdateTimeUI(0);
    }

    public void UpdateScoreUI(int value)
    {
        // "D2" - minimum of 2 digits, preceding shorter numbers with 0s
        ScoreValue.text = value.ToString("D2");
    }

    public void UpdateTimeUI(float time)
    {
        int seconds = (int)time;
        TimeValue.text = System.TimeSpan.FromSeconds(seconds).ToString("mm':'ss");
    }

    public void ActivateEndGame(int score, string sType)
    {
        EndTreasureValue.text = score.ToString();
        EndTimeValue.text = TimeValue.text;
        sEndTimeValue = TimeValue.text;
        GameOverPanel.SetActive(true);
        if (sType == "Victory")
        {
            EndOutcome.text = sVictoryText;
        }
        else
        {
            EndOutcome.text = sLossText;
        }
        Cursor.visible = true;
    }

}
