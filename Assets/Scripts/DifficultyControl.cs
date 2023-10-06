using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyControl : MonoBehaviour
{
    public float Difficulty { get; private set; }
    public float timeUntilMaxDifficulty;
    private float timeSinceGameStart;

    void Update()
    {
        timeSinceGameStart += Time.deltaTime;
        Difficulty = Mathf.Min(timeSinceGameStart / timeUntilMaxDifficulty, 1);
    }

    public void ResetDifficulty()
    {
        Difficulty = 0;
        timeSinceGameStart = 0;
    }
}
