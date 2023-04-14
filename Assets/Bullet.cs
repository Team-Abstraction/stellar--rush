using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //для кода нужен префаб взрыва
        //Instantiate(hitEffect, transform.position, Quaternion.identity);
        Debug.Log("hit");
        Destroy(gameObject);
    }
}
