using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraController : MonoBehaviour
{
    [SerializeField] private Transform target; //ターゲットへの参照
    [SerializeField] private float rotateSpeed = 1;
    private Vector3 offset;
    private Transform mainCamera;
    private float minX = 0.1f, maxX = 89.9f;
    private Camera cam;

    void Start()
    {
        //自分自身とtargetとの相対距離を求める
        mainCamera = GetComponent<Transform>();
        offset = mainCamera.position - target.position;
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float view = cam.fieldOfView - cam.fieldOfView * scroll;
        cam.fieldOfView = Mathf.Clamp(value: view, min: 0.1f, max: 60f);
        mainCamera.position = target.position + offset;
        rotateCamera();
        offset = mainCamera.position - target.position;
    }

    private void rotateCamera()
    {
        //Vector3でX方向の回転の度合いを定義
        Vector3 angle = new Vector3(Input.GetAxis("Mouse X") * rotateSpeed, Input.GetAxis("Mouse Y") * rotateSpeed, 0);

        //メインカメラを回転させる
        mainCamera.RotateAround(target.position, Vector3.up, angle.x);
        if (mainCamera.eulerAngles.x - angle.y > minX && mainCamera.eulerAngles.x - angle.y < maxX)
        {
            mainCamera.Rotate(-angle.y, 0, 0);
        }
    }
}
