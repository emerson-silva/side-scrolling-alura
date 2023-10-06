using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    public KeyCode actionKey;
    [SerializeField]
    private UnityEvent onKeyDown;

    void Update()
    {
        if (Input.GetKeyDown(actionKey))
        {
            onKeyDown.Invoke();
        }
    }
}
