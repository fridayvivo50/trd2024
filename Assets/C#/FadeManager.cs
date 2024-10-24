using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeManager : MonoBehaviour
{
    public static FadeManager InstanceF;
    private Animator myAnimator;

    private void Awake()
    {
        if(InstanceF == null) { InstanceF = this; }
    }
    private void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void FadeIn()
    {
        myAnimator.SetTrigger("FadeIn");
    }

    public void FadeOut()
    {
        myAnimator.SetTrigger("FadeOut");
    }

}
