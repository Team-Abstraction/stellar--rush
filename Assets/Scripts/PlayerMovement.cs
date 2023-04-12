using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;

    public Rigidbody2D rb;

    public float maxVelocity = 10;

    Vector2 mousePos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float axisX = Input.GetAxis("Horizontal");
        float axisY = Input.GetAxis("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        ThrustY(axisY);
        ThrustX(axisX);

        if (rb.velocity.sqrMagnitude > maxVelocity)
            VelocityClamp();

        RotationMouseControl();
    }


    private void VelocityClamp()
    {
        float x = Mathf.Clamp(rb.velocity.x, -maxVelocity, maxVelocity);
        float y = Mathf.Clamp(rb.velocity.y, -maxVelocity, maxVelocity);

        rb.velocity = new Vector2(x, y);
    }

    private void ThrustY(float amount)
    { 
        Vector2 forceY = transform.up * amount;

        rb.AddForce(forceY);
    }

    private void ThrustX(float amount)
    {
        Vector2 forceX = transform.right * amount;

        rb.AddForce(forceX);
    }

    private void RotationMouseControl()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log("Collision detected!");
    //}
}