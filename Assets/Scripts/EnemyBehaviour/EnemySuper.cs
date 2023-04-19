using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuper : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] private float moveSpeed;
    private float healthPoint;
    [SerializeField] private float maxHealthPoint;

    private Transform target; //Player usually.
    [SerializeField] private float range;
    private SpriteRenderer Spr;

    // Start is called before the first frame update
    void Start()
    {
        healthPoint = maxHealthPoint;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        // Spr = GetComponent<SpriteRenderer>()
        Introduction();
    }

    // Update is called once per frame
    void Introduction()
    {
        Debug.Log("My Name is " + enemyName + ", HP: " + healthPoint + ", moveSpeed: " + moveSpeed);
    }

    private void Move()
    {
        if (Vector2.Distance(transform.position, target.position) < range)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }

    private void Update()
    {
        Move();
        //TurnDirection();
    }

    private void TurnDirection()
    {
        if (transform.position.x > target.position.x)
        {
            Spr.flipX = true;
        } else
        {
            Spr.flipX = false;
        }
    }
}
