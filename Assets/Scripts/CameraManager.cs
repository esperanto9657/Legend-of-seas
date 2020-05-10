using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    //　メインカメラ
    [SerializeField] private GameObject mainCamera;
    //　切り替える他のカメラ
    [SerializeField] private GameObject gunCamera;
    [SerializeField] private float yRotation;

    // Update is called once per frame
    void Update()
    {
        //　1キーを押したらカメラの切り替えをする
        if (Input.GetKeyDown("1"))
        {
            if (mainCamera.activeSelf)
            {
                yRotation = mainCamera.GetComponent<Transform>().eulerAngles.y;

            }
            if (gunCamera.activeSelf)
            {
                yRotation = gunCamera.GetComponent<Transform>().eulerAngles.y;
            }
            mainCamera.SetActive(!mainCamera.activeSelf);
            gunCamera.SetActive(!gunCamera.activeSelf);
        }
    }
}
