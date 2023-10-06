using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private SharedPropertyFloat speed;
    [SerializeField]
    private float variationRange;
    public ObstacleGenerator ObstacleGenerator { get; set; }

    //TODO: Define distance between floor and roof obstacle randomly
    void Awake()
    {
        transform.Translate(Vector3.up * Random.Range(-variationRange, variationRange));
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed.value * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DestroyObstacles"))
        {
            ObstacleGenerator.RemoveObstacle(this);
        }
    }
}
