using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class takes input and sends it
    to the appropriate class and function
*/
public class InputManager : MonoBehaviour
{
    public Clock clock;
    private float horizontal;
    public float handMovementSpeed;

    private void Update()
    {
        horizontal  = Input.GetAxis("Horizontal");

        // switch which hand is controlled
        if(Input.GetButtonDown("Up"))
        {
            clock.ChangeHand(1);
        }
        if(Input.GetButtonDown("Down"))
        {
            clock.ChangeHand(-1);
        }
        // rotate the currently controlled hand
        if(horizontal != 0)
        {
            clock.MoveHand(-horizontal * handMovementSpeed * Time.deltaTime);
        }
    }
}
