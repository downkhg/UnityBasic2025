using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int nHP = 100;
    public int nDemage = 10;

    public void Attack(Player target)
    {
        target.nHP = target.nHP - this.nDemage;
    }
    public bool Death()
    {
        if (nHP > 0)
            return false;
        else
            return true;
    }

    public int nDebugIdx;
    private void OnGUI()
    {
        Vector2 vPos = Vector2.zero;
        Vector2 vSize = new Vector2(100, 20);
        int nLine = 0;
        GUI.Box(new Rect(vPos.x + (vSize.x * nDebugIdx), vPos.y + (vSize.y * nLine), vSize.x, vSize.y), "Name:" + gameObject.name); nLine++;
        GUI.Box(new Rect(vPos.x + (vSize.x * nDebugIdx), vPos.y + (vSize.y*nLine) , vSize.x, vSize.y), "HP:" + nHP); nLine++;
        GUI.Box(new Rect(vPos.x + (vSize.x * nDebugIdx), vPos.y + (vSize.y * nLine), vSize.x, vSize.y), "Demage:" + nDemage); nLine++;
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
