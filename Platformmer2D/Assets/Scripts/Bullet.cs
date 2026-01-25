using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Range;
    Vector3 vStartPos;
    public Player master;
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

    void Attack()
    {
        Vector2 vPos = transform.position;
        CircleCollider2D circleCollider = this.GetComponent<CircleCollider2D>();
        int nLayer = 1 << LayerMask.NameToLayer("Player");
        Collider2D collider =
            Physics2D.OverlapCircle(vPos + circleCollider.offset, circleCollider.radius, nLayer);

        if (collider)//콜라이더가 있을때
        {
            Player me = this.GetComponent<Player>();
            Player target = collider.gameObject.GetComponent<Player>();
            SuperMode superMode = target.GetComponent<SuperMode>();
            if (superMode && superMode.isUes == false)
            {
                me.Attack(target);
                superMode.OnMode();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Player target = collision.GetComponent<Player>();
            SuperMode superMode = target.GetComponent<SuperMode>();
            if (superMode && superMode.isUes == false)
            {
                master.Attack(target);
                superMode.OnMode();
            }
        }
    }
}
