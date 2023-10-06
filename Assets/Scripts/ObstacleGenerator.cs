using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject obstaclePrefab;
    [SerializeField]
    private Vector3 spawnPosition;
    [SerializeField]
    private float spawnIntervalEasy;
    [SerializeField]
    private float spawnIntervalHard;
    [SerializeField]
    private float chronometer;
    [SerializeField]
    private List<Obstacle> inGameObstacles;
    public Transform airplaneTransform;
    [SerializeField]
    private DifficultyControl difficultyControl;
    [SerializeField]
    private bool isEnabled;

    void Start()
    {
        chronometer = spawnIntervalEasy;
        if (difficultyControl == null)
        {
            difficultyControl = GameObject.FindObjectOfType<DifficultyControl>();
        }
        //isEnabled = true;
    }

    void Update()
    {
        if (isEnabled)
        {
            chronometer -= Time.deltaTime;
            if (chronometer<=0) {
                GameObject obsIntance = GameObject.Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
                Obstacle obstacle = obsIntance.GetComponent<Obstacle>();
                obstacle.ObstacleGenerator = this;
                inGameObstacles.Add(obstacle);
                chronometer = Mathf.Lerp(spawnIntervalEasy, spawnIntervalHard, difficultyControl.Difficulty);
            }
        }
    }

    public void CleanScene ()
    {
        foreach(Obstacle obsInstance in inGameObstacles)
        {
            GameObject.Destroy(obsInstance.gameObject);
        }
        inGameObstacles.Clear();
        difficultyControl.ResetDifficulty();
    }

    public void StopObstacleGenerator()
    {
        isEnabled = false;
        foreach(Obstacle obstacles in inGameObstacles)
        {
            obstacles.enabled = false;
        }
    }

    public void RestartObstacleGenerator()
    {
        isEnabled = true;
        if (inGameObstacles.Count>0)
        {
            RemoveObstacle(inGameObstacles[0]);
        }
        foreach (Obstacle obstacle in inGameObstacles)
        {
            obstacle.enabled = true;
        }
    }

    public void RemoveObstacle (Obstacle obstacle)
    {
        inGameObstacles.Remove(obstacle);
        GameObject.Destroy(obstacle.gameObject);
    }
}
