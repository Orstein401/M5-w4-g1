using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    private PlayerController controller;
    private Animator animator;
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
    }

    public void GetAndSetParametres()
    {
        animator.SetFloat("Horizontal", controller.Horizontal);
        animator.SetFloat("Vertical", controller.Vertical);
        animator.SetBool("IsRunning", controller.Run);
    }

    private void Update()
    {
        if (controller.Velocity != Vector3.zero)
        {
            GetAndSetParametres();
        }
    }
}
