using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Airplane : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float propulsionForce;
    private Vector3 initialPosition;
    private bool shouldPerformPropulsion;
    private Animator animator;
    [SerializeField]
    private UnityEvent playerCrash;
    [SerializeField]
    private UnityEvent onScore;
    private bool crashed;

    void Awake()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
    }

    void Update()
    {
        if (!crashed)
        {
            this.animator.SetFloat("VelocityY", rb2d.velocity.y);
        }
    }

    private void FixedUpdate()
    {
        if (shouldPerformPropulsion)
        {
            shouldPerformPropulsion = false;
            PerformPropulsion();
        }
    }

    public void CommandPropulsion ()
    {
        if (!crashed)
        {
            this.shouldPerformPropulsion = true;
        }
    }

    private void PerformPropulsion()
    {
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(Vector2.up * propulsionForce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!crashed)
        {
            rb2d.simulated = false;
            crashed = true;
            playerCrash.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreCount.Instance.IncrementScore();
        onScore.Invoke();
    }

    public void Respawn ()
    {
        transform.position = initialPosition;
        crashed = false;
        EnablePlayer();
    }

    public void EnablePlayer()
    {
        rb2d.simulated = true;
        CommandPropulsion();
    }
}
