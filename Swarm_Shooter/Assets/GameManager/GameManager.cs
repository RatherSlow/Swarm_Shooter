using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{ 
// DESIGN PATTERN: SINGLETON
    public static GameManager instance { get; private set; }
    public UIManager UIManager { get; private set; }
    public HighScoreSystem HighScoreSystem { get; private set; }

    private static float secondsSinceStart = 0;
    private static int score;
    private static string EndTime;
    private static string Result;
    

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }
        instance = this;

    UIManager = GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        secondsSinceStart += Time.deltaTime;
        instance.UIManager.UpdateTimeUI(secondsSinceStart);
    }

    public static string GetScoreText()
    {
        return score.ToString();
    }

    public static void IncrementScore(int value)
    {
        float MaxScore = 12;
        score += value;
        instance.UIManager.UpdateScoreUI(score);
        Debug.Log("Swarms killed: " + score);
        
        if(score == MaxScore)
        {
            Application.Quit();
        }
    }

    public static void ResetGame()
    {
        ResetScore();
        secondsSinceStart = 0f;
        Time.timeScale = 1f;
    }

    private static void ResetScore()
    {
        score = 0;
        instance.UIManager.UpdateScoreUI(score);
        Debug.Log("Swarms killed: " + score);
    }

    public void GameOver(string sType)
    {
        EndTime = System.TimeSpan.FromSeconds(secondsSinceStart).ToString("mm':'ss");
        Time.timeScale = 0f;
        MenuController.IsGamePaused = true;
        Debug.Log(EndTime);
        Result = sType;
        Debug.Log(Result);
        instance.UIManager.ActivateEndGame(score, sType);
    }
}
