using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Clock clock;

    public float horizontal;
    public float handMovementSpeed;

    public bool verticalIsActive;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        horizontal  = Input.GetAxis("Horizontal");

        if(verticalIsActive && Input.GetButtonDown("Up"))
        {
            clock.ChangeHand(1);
        }
        if(verticalIsActive && Input.GetButtonDown("Down"))
        {
            clock.ChangeHand(-1);
        }
        if(horizontal != 0)
        {
            clock.MoveHand(-horizontal * handMovementSpeed * Time.deltaTime);
        }
    }
}
