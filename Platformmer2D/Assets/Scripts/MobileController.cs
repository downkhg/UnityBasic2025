using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileController : MonoBehaviour
{
    public Dynamic dynamic;

    public string horizontalAxis = "Horizontal";
    public string verticalAxis = "Vertical";
    public string jumpButton = "Jump";
    public string aButton = "A";


    // Start is called before the first frame update
    void Start()
    {
        dynamic = GetComponent<Dynamic>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputHorizontal = SimpleInput.GetAxis(horizontalAxis);
        float inputVertical = SimpleInput.GetAxis(verticalAxis);

        if(inputHorizontal > 0)
        {
            dynamic.Move(Vector3.right);
        }
        else if (inputHorizontal < 0)
        {
            dynamic.Move(Vector3.left) ;
        }

        if (SimpleInput.GetButtonDown(jumpButton))
        {
            dynamic.Jump();
            Debug.Log("SimpleInput.Jump!");
        }

        if (SimpleInput.GetButtonDown(aButton))
        {
            dynamic.Attack();
            Debug.Log("SimpleInput.Attack!");
        }
    }

    private void OnGUI()
    {
        int nWight = 50;
        int nHeight = 50;

        int nTopMagin = Screen.width - nHeight + 10;
        int nLeftMagin = 10;

        int x = 10;
        int y = 10;

        Rect rectLeft = new Rect(x, y+nTopMagin, nWight, nHeight);
        Rect rectRight = new Rect(x + nWight + nLeftMagin, y+nTopMagin, nWight, nHeight);

        if (GUI.Button(rectRight, "▶"))
        {
            dynamic.Move(Vector3.right);
        }
        
        if(GUI.Button(rectLeft, "◀"))
        {
            dynamic.Move(Vector3.left);
        }
    }
}
