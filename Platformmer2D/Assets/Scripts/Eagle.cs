using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    public GameObject objTarget;
    public float Speed = 1;
    public float Site = 0.5f;
    public GameObject objResponPoint;

    // Update is called once per frame
    void Update()
    {
        if (objTarget)
        {
            Vector3 vTargetPos = objTarget.transform.position;
            Vector3 vPos = this.transform.position;
            Vector3 vDist = vTargetPos - vPos;
            Vector3 vDir = vDist.normalized;
            float fDist = vDist.magnitude;

            if (fDist > Speed * Time.deltaTime)
                transform.position += vDir * Speed * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        //UpdateFindTargetLayer();
        UpdateFindTargetLayerAll();

        if (objTarget == null)
            objTarget = objResponPoint;
    }

    void UpdateFindTargetLayer()
    {
        int nLayer = 1 << LayerMask.NameToLayer("Player");
        Collider2D collider = 
            Physics2D.OverlapCircle(this.transform.position, Site, nLayer);

        if (collider)
        {
            objTarget = collider.gameObject;
            Debug.Log("FindTarget:" + collider.gameObject.name);
        }
    }

    void UpdateFindTargetLayerAll()
    {
        Collider2D[] colliders =
            Physics2D.OverlapCircleAll(this.transform.position, Site);

        for(int i = 0; i < colliders.Length; i++)
        { 
            Collider2D collider = colliders[i];
            if (collider.tag == "Player")
            {
                objTarget = collider.gameObject;
                Debug.Log("FindTarget:" + collider.gameObject.name);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, Site);
    }

//    p rivate void OnTriggerEnter2D(Collider2D collision)
//    {
//        if(collision.gameObject.tag == "Player")
//            objTarget = collision.gameObject;
//    }
}
