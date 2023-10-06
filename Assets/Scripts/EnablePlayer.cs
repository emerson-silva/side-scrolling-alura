using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnablePlayer : MonoBehaviour
{
    [SerializeField]
    private UnityEvent onFadeOut;

    public void OnFadeOut()
    {
        onFadeOut.Invoke();
    }
}
