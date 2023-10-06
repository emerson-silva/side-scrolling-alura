using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPU : MonoBehaviour
{
    private Airplane airplane;
    public float distanceToCollisionDown;
    public float distanceToCollisionInFront;
    [SerializeField]
    private LayerMask hitMask;

    void Start()
    {
        airplane = GetComponent<Airplane>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldPerformPropulsion())
        {
            airplane.CommandPropulsion();
        }
    }
    private bool ShouldPerformPropulsion()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
        Debug.DrawRay(transform.position, Vector2.right, Color.red);
        
        RaycastHit2D florHit = Physics2D.Raycast(transform.position, Vector2.down, distanceToCollisionDown, hitMask);
        RaycastHit2D obstacleHit = Physics2D.Raycast(transform.position, Vector2.right, distanceToCollisionInFront, hitMask);
        if (florHit.collider != null || obstacleHit.collider != null)
        {
            return true;
        }
        return false;
    }
}
