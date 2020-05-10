using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFireController : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private float speed;
    [SerializeField] private int muzzleNumber;
    [SerializeField] private float reloadTime;
    private float nextShot;
    private Aim aim;
    public Vector3 impactPoint;
    public float elevation = 0;
    public float distance;
    private List<Transform> muzzles = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < muzzleNumber; i++)
        {
            muzzles.Add(transform.GetChild(0).Find("Muzzle" + i.ToString()));
        }
        aim = GameObject.Find("Main Camera").GetComponent<Aim>();
    }

    // Update is called once per frame
    void Update()
    {
        Elevate();
        if (Input.GetMouseButtonDown(0) && Time.time > nextShot)
        {
            Shot();
            nextShot = Time.time + reloadTime;
        }
    }

    void Shot()
    {
        for(int i = 0; i < muzzleNumber; i++)
        {
            GameObject bulletInstance = GameObject.Instantiate(bullet, muzzles[i].position, Quaternion.Euler(muzzles[i].eulerAngles.x, muzzles[i].eulerAngles.y, muzzles[i].eulerAngles.z + 90)) as GameObject;
            //bulletInstance.GetComponent<Rigidbody>().AddForce(muzzles[i].forward * speed);
            bulletInstance.GetComponent<Rigidbody>().velocity = muzzles[i].forward * speed;
        }
    }

    void Elevate()
    {
        impactPoint = aim.hit.point;
        distance = Vector2.Distance(new Vector2(impactPoint.x, impactPoint.z), new Vector2(transform.position.x, transform.position.z));
        elevation = Mathf.Asin(-Physics.gravity.y * distance / Mathf.Pow(speed, 2)) * Mathf.Rad2Deg / 2;
        Transform cannon = transform.GetChild(0);
        cannon.localEulerAngles = new Vector3(-elevation, 0, 0);
    }
}
