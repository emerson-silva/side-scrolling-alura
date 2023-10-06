using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadPlayerInterfaceManager : MonoBehaviour
{
    private Canvas canvas;
    [SerializeField]
    private GameObject backgroundPanel;
    [SerializeField]
    private Text scoreUntilRestart;
    public string pointsUntilReviveText;

    void Awake()
    {
        canvas = GetComponent<Canvas>();
    }

    public void Display(Camera camera)
    {
        scoreUntilRestart.gameObject.SetActive(true);
        backgroundPanel.SetActive(true);
        canvas.worldCamera = camera;
    }

    public void Hide ()
    {
        scoreUntilRestart.gameObject.SetActive(false);
        backgroundPanel.SetActive(false);
    }

    public void SetPointsUntilRevive(int value)
    {
        scoreUntilRestart.text = pointsUntilReviveText + value.ToString();
    }
}
