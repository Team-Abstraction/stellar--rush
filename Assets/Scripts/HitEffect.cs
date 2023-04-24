using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject effectPrefab;

    void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject bullet = Instantiate(effectPrefab, coll.transform.position, Quaternion.identity);
    }  
}
