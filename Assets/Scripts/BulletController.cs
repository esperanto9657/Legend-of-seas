using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Destroy(gameObject);
        Debug.Log(col.gameObject.name);
    }

    void Update()
    {
        transform.up = GetComponent<Rigidbody>().velocity;
    }
}
