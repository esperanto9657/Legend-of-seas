using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunCameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float rotateSpeed = 1;
    private Vector3 offset;
    private Camera gunCamera;
    private Transform gunCameraTransform;
    private float minX = -20, maxX = 20;

    void Start()
    {
        gunCamera = GetComponent<Camera>();
        gunCameraTransform = GetComponent<Transform>();
        gunCameraTransform.position = target.position + new Vector3(0, 5.7f, 85);
        offset = gunCameraTransform.position - target.position;
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float view = gunCamera.fieldOfView - gunCamera.fieldOfView * 0.3f * scroll;
        gunCamera.fieldOfView = Mathf.Clamp(value: view, min: 0.1f, max: 60f);
        gunCameraTransform.position = target.position + offset;
        rotateCamera();
        offset = gunCameraTransform.position - target.position;
    }

    private void rotateCamera()
    {
        //Vector3でX方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        //メインカメラを回転させる
        gunCameraTransform.RotateAround(target.position, Vector3.up, angle.x);
        if (gunCameraTransform.eulerAngles.x - angle.y > minX && gunCameraTransform.eulerAngles.x - angle.y < maxX)
        {
            gunCameraTransform.Rotate(-angle.y, 0, 0);
        }
    }
}
