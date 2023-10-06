using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallToClick : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer image;

    private void Start()
    {
        this.image = this.GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            gameObject.SetActive(false);
        }
    }
}
