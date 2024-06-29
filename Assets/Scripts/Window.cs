using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : Interactable
{
    [SerializeField] 
    private GameObject barrier; // Reference to the barrier GameObject
    [SerializeField] 
    private Animator windowAnimator; // Reference to the Animator component

    private bool barrierChecked = false;

    private void Update()
    {
        if (!barrierChecked && barrier != null && !barrier.activeSelf)
        {
            PlayWindowAnimation();
            barrierChecked = true; // Ensure the animation is only played once
        }
    }

    private void PlayWindowAnimation()
    {
        if (windowAnimator != null)
        {
            windowAnimator.SetTrigger("OpenWindow");
        }
        else
        {
            Debug.LogWarning("Animator component is not assigned.");
        }
    }
}
