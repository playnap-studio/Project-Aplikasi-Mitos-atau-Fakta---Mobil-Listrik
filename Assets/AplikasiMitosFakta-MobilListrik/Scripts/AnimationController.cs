using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator thisAnimator;

    void Start()
    {
        thisAnimator = GetComponent<Animator>();
    }

    public void PlayAnimationViaBoolean(string thisAnimationName)
    {
        thisAnimator.SetBool(thisAnimationName, true);
    }

    public void StopAnimationViaBoolean(string thisAnimationName)
    {
        thisAnimator.SetBool(thisAnimationName, false);
    }
}
