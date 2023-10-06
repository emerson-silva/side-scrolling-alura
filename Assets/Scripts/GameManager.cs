using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public ObstacleGenerator obstacleGenerator;
    public Airplane airplane;
    [SerializeField]
    protected GameOverInterfaceManager goManager;

    private void Awake()
    {
        Instance = this;
    }

    protected virtual void Start()
    {
        if (goManager == null)
        {
            goManager = GameObject.FindObjectOfType<GameOverInterfaceManager>();
        }
    }

    public void GameOver ()
    {
        Time.timeScale = 0;
        goManager.DisplayGameOverScreen();
    }

    public virtual void RestartGame ()
    {
        obstacleGenerator.CleanScene();
        goManager.HideGameOverScreen();
        airplane.Respawn();
        Time.timeScale = 1;
    }
}
