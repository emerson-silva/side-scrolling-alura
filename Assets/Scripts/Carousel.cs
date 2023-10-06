using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carousel : MonoBehaviour
{
    private Vector3 initialPosition;
    private float floorSize;

    [SerializeField]
    private SharedPropertyFloat speed;

    private void Awake()
    {
        this.initialPosition = transform.position;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        this.floorSize = spriteRenderer.size.x * transform.localScale.x * 100 / spriteRenderer.sprite.pixelsPerUnit;
    }

    void FixedUpdate()
    {
        float deslocation = Mathf.Repeat(this.speed.value * Time.time, this.floorSize/2);
        transform.position = this.initialPosition + Vector3.left * deslocation;
    }
}
