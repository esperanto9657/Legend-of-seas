using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearTurretController : MonoBehaviour
{
    public float rotateSpeed;
    public float maxAngle;
    private Transform mainCamera;
    private GameObject ship;
    public float target;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main.transform;
        ship = transform.parent.gameObject;
        Mathf.Clamp(maxAngle, 0, 180);
    }

    // Update is called once per frame
    void Update()
    {
        target = mainCamera.eulerAngles.y - ship.transform.eulerAngles.y;
        if (target < 0)
        {
            target += 360;
        }
        if (target < 180 - maxAngle)
        {
            target = 180 - maxAngle;
        }
        if (target > 180 + maxAngle)
        {
            target = 180 + maxAngle;
        }
        float currentAngle = transform.localEulerAngles.y;
        if (Mathf.Abs(target - currentAngle) > 0.1f)
        {
            if (target > currentAngle)
            {
                transform.Rotate(0, Time.deltaTime * rotateSpeed, 0);
            }
            if (target < currentAngle)
            {
                transform.Rotate(0, -Time.deltaTime * rotateSpeed, 0);
            }
        }
    }
}
