using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerGameManager : GameManager
{
    [SerializeField]
    private int pointsToRevivePartner;
    private int pointsUntilRevivePartner;
    private bool partnerIsDead;
    [SerializeField]
    private PlayerManager[] players;
    [SerializeField]
    private DeadPlayerInterfaceManager deadInterface;

    protected override void Start()
    {
        base.Start();
        if (players.Length<=0)
        {
            players = FindObjectsOfType<PlayerManager>();
        }
    }

    public void RevivePartner()
    {
        if (partnerIsDead)
        {
            pointsUntilRevivePartner--;
            deadInterface.SetPointsUntilRevive(pointsUntilRevivePartner);
            if (pointsUntilRevivePartner<=0)
            {
                partnerIsDead = false;
                RevivePlayers();
            }
        }
    }

    public void OnPlayerCrash(Camera camera)
    {
        if (partnerIsDead)
        {
            deadInterface.Hide();
            GameOver();
        } else
        {
            pointsUntilRevivePartner = pointsToRevivePartner;
            partnerIsDead = true;
            deadInterface.SetPointsUntilRevive(pointsUntilRevivePartner);
            deadInterface.Display(camera);
        }
    }

    private void RevivePlayers()
    {
        deadInterface.Hide();
        partnerIsDead = false;
        foreach (PlayerManager player in players)
        {
            player.RevivePlayer();
        }
    }

    public override void RestartGame()
    {
        RevivePlayers();
        goManager.HideGameOverScreen();
        Time.timeScale = 1;
    }
}
