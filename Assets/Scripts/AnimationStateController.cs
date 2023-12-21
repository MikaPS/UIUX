using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // bool isWalking = animator.GetBool("isWalking");
        bool forwardPressed = Input.GetKey("w");
        bool backwardPressed = Input.GetKey("s");
        bool runningPressed = Input.GetKey("left shift");

        if (forwardPressed || backwardPressed) {
            animator.SetBool("isWalking", true);
        } 
        else {
            animator.SetBool("isWalking", false);
        }

        if ((forwardPressed && runningPressed) || (backwardPressed && runningPressed)) {
            animator.SetBool("isRunning", true);
        }
        if ((!forwardPressed || !runningPressed) && (!backwardPressed || !runningPressed)) {
            animator.SetBool("isRunning", false);
        }
    }
}
