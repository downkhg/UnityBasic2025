using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraTracker cameraTracker;

    public Responner responnerPlayer;
    public Responner responnerOpossum;

    public float DeathZoneY = -1;

    public void DeathZoneGizmo()
    {
        Vector3 vStartPos = new Vector3(-9999999999, DeathZoneY, 0);
        Vector3 vEndPos = new Vector3(9999999999, DeathZoneY, 0);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(vStartPos, vEndPos);
    }

    //싱글톤: 게임관리자를 어떤객체든 쉽게 접근하게 만들수있다.
    static GameManager instance;
    public static GameManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(cameraTracker.objTarget == null)
            cameraTracker.objTarget = responnerPlayer.objPlayer;
    }

    private void OnDrawGizmos()
    {
        DeathZoneGizmo();
    }
}
