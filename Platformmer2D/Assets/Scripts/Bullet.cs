using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Range;
    Vector3 vStartPos;
    // Start is called before the first frame update
    void Start()
    {
        vStartPos = transform.position;
        //Destroy(this.gameObject, 1);//속도에 따라 삭제거리가 달라진다.
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vPos = transform.position;
        //Vector3 vDist = vPos - vStartPos;
        //float fDist = vDist.magnitude;
        float fDist = Vector3.Distance(vPos, vStartPos);
        if (fDist > Range)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster")
            Destroy(collision.gameObject);
    }
}
