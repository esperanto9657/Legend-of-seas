﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    public Image aimImage;
    public RaycastHit hit;

    void Update()
    {
        // レーザー（ray）を飛ばす「起点」と「方向」
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out hit, 100000))
        {
            string hitName = hit.transform.gameObject.tag;

            if (hitName == "Enemy")
            {
                // 照準器の色を「赤」に変える（色は自由に変更してください。）
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            else
            {
                // 照準器の色を「水色」（色は自由に変更してください。）
                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        else
        {
            // 照準器の色を「水色」（色は自由に変更してください。）
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
