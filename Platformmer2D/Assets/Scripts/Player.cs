using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int nHP = 10;
    public int nDemage = 10;

    public int nExp;
    public int nLv = 1;

    public void LvUp()
    {
        if(nExp >= 100)
        {
            nHP += 10;
            nDemage += 10;
            nExp -= 100;
            nLv++;
        }
    }

    public void StillExp(Player target)
    {
        Debug.Log("StillExp:"+target.gameObject.name);
        this.nExp += (target.nExp + target.nLv * 100);
    }

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
        GUI.Box(new Rect(vPos.x + (vSize.x * nDebugIdx), vPos.y + (vSize.y * nLine), vSize.x, vSize.y), "Lv/Exp:" + nLv + "/" + nExp); nLine++;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Death())
            Destroy(this.gameObject);

        LvUp();
    }
}
