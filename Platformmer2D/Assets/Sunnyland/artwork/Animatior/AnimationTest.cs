using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
       if( GUI.Button(new Rect(0,0,100,20),"hurt"))
       {
            animator.SetTrigger("hurt");
       }
    } 
}
