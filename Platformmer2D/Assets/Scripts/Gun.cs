using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject objBullet;
    public Transform trMozzle;
    public float ShotPower;

    public void Shot(Vector3 dir)
    {
        GameObject objCopyBullet = Instantiate(objBullet);
        objCopyBullet.transform.position = trMozzle.position;
        Rigidbody2D rigidbody = objCopyBullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(dir * ShotPower);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
