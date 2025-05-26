using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabaikaScreamer : GameMonoBehaviour
{
    Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PlayScreamerAnim()
    {
        animator.SetBool("IsScreamer", true);
    }
    public void ActivateBabaika()
    {
        gameObject.SetActive(true);
    }
}
