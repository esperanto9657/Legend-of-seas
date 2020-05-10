using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontTurretController : MonoBehaviour
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
        if (target > 180)
        {
            target -= 360;
        }
        if (target < -180)
        {
            target += 360;
        }
        if (target > maxAngle)
        {
            target = maxAngle;
        }
        if (target < -maxAngle)
        {
            target = -maxAngle;
        }
        float currentAngle = transform.localEulerAngles.y;
        if (currentAngle > 180)
        {
            currentAngle -= 360;
        }
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
