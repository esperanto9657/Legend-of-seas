using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxSpeed;
    public float speed;
    public int gear;
    public float enginePower;
    private float controller;
    [SerializeField] private float rotateSpeed;

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        controller = controller + v;
        
        if(controller > 120)
        {
            controller = 120;
        }
        if(controller < -30)
        {
            controller = -30;
        }

        gear = (int)controller / 30;

        //同一のGameObjectが持つRigidbodyコンポーネントを取得
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        speed = rigidbody.velocity.magnitude;

        rigidbody.AddRelativeForce(0, 0, gear * enginePower);
        //Vector3 target = rigidbody.position;
        //target.z = target.z + 80;
        //rigidbody.AddForceAtPosition(new Vector3(h * speed * 0.01f, 0, 0), target);
        //Transform transform = GetComponent<transform>()
        transform.Rotate(0, h * speed * rotateSpeed, 0);
    }
}
