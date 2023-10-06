using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private ObstacleGenerator obstacleGenerator;
    [SerializeField]
    private Carousel[] carousels;
    private InputManager inputManager;
    private CPU cpu;
    private bool isDead;
    private Airplane airplane;


    private void Start()
    {
        if (obstacleGenerator==null)
        {
            obstacleGenerator = GetComponentInChildren<ObstacleGenerator>();
        }
        carousels = GetComponentsInChildren<Carousel>();
        inputManager = GetComponentInChildren<InputManager>();
        cpu = GetComponentInChildren<CPU>();
        airplane = GetComponentInChildren<Airplane>();
    }

    public void OnPlayerCrash ()
    {
        isDead = true;
        if(inputManager!=null) inputManager.enabled = false;
        if (cpu != null) cpu.enabled = false;

        obstacleGenerator.StopObstacleGenerator();
        DisableScenario();
    }

    public void RevivePlayer()
    {
        if (isDead)
        {
            obstacleGenerator.RestartObstacleGenerator();
            EnableScenario();
            airplane.Respawn();
            if (inputManager != null) inputManager.enabled = true;
            if (cpu != null) cpu.enabled = true;
            isDead = false;
        }
    }

    private void DisableScenario()
    {
        foreach (Carousel carousel in carousels)
        {
            carousel.enabled = false;
        }
    }

    private void EnableScenario()
    {
        foreach (Carousel carousel in carousels)
        {
            carousel.enabled = true;
        }
    }

    public void EnablePlayer ()
    {
        if (!isDead)
        {
            airplane.EnablePlayer();
            obstacleGenerator.RestartObstacleGenerator();
        }
    }
}
