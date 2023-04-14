using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{
    public Transform player;
    Rigidbody2D playerBody;
    public float influenceRange;
    public float intensity;
    public float distanceToPlayer;
    Vector2 pullForce;

    void Start()
    {
        playerBody = player.GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        distanceToPlayer = Vector2.Distance(player.position, transform.position);
    }

    private void FixedUpdate()
    {
        if (distanceToPlayer <= influenceRange)
        {
            pullForce = (transform.position - player.position).normalized / distanceToPlayer * intensity;
            playerBody.AddForce(pullForce, ForceMode2D.Force);
        }
    }
}
