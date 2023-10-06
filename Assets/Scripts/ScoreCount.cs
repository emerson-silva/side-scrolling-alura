using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public static ScoreCount Instance;
    private const string PLAYER_HIGH_SCORE = "HighScore";
    public int Score { get; private set; }
    public Text scoreText;
    private AudioSource scoreAudio;
    public int PersonalRecord { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        if (Instance!=this)
        {
            Destroy(this);
        }
        this.scoreAudio = GetComponent<AudioSource>();
        ResetScore();
    }

    public void ResetScore()
    {
        this.Score = 0;
        UpdateScoreText();
    }

    public void IncrementScore()
    {
        this.Score++;
        scoreAudio.Play();
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        this.scoreText.text = this.Score.ToString();
    }

    public void SaveHighScore()
    {
        PersonalRecord = PlayerPrefs.GetInt(PLAYER_HIGH_SCORE);
        if (this.Score > PersonalRecord)
        {
            PlayerPrefs.SetInt(PLAYER_HIGH_SCORE, this.Score);
            PersonalRecord = Score;
        }
    }
}
