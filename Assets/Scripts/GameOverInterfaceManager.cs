using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverInterfaceManager : MonoBehaviour
{
    [SerializeField]
    private Text highScoreValue;
    [SerializeField]
    private GameObject gameOverScreen;
    public Sprite copperMedal;
    public Sprite silverMedal;
    public Sprite goldMedal;
    public Image medal;

    private const string PLAYER_HIGH_SCORE = "HighScore";

    public void UpdateHighScorePanel ()
    {
        highScoreValue.text = PlayerPrefs.GetInt(PLAYER_HIGH_SCORE).ToString();
        UpdateMedal();
    }

    public void DisplayGameOverScreen()
    {
        ScoreCount.Instance.SaveHighScore();
        UpdateHighScorePanel();
        gameOverScreen.SetActive(true);
    }

    public void HideGameOverScreen ()
    {
        ScoreCount.Instance.ResetScore();
        gameOverScreen.SetActive(false);
    }

    private void UpdateMedal ()
    {
        if (ScoreCount.Instance.Score > ScoreCount.Instance.PersonalRecord*0.8f)
        {
            medal.sprite = goldMedal;
        }
        else if (ScoreCount.Instance.Score > ScoreCount.Instance.PersonalRecord * 0.5f)
        {
            medal.sprite = silverMedal;
        }
        else
        {
            medal.sprite = copperMedal;
        }
    }
}
