using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabaikaScreamer : GameMonoBehaviour
{
    Animator animator;
    AudioSource s;
    void Start()
    {
        animator = GetComponent<Animator>();
        s = GetComponent<AudioSource>();
    }

    public void PlayScreamerAnim()
    {
        animator.SetBool("IsScreamer", true);
        s.Play();
    }
    public void ActivateBabaika()
    {
        gameObject.SetActive(true);
    }
}
