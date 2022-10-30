using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class contains the second, minute, and hour hands,
    their current values,
    which one is currently being controlled,
    and filters controls to the correct hand
*/
public class Clock : MonoBehaviour
{
    public Hand[] clockHands;

    public float[]  handValues;
    public float[]  maxHandValues = {60, 60, 12};

    public int selectedHandIndex;

/*
    takes horizontal movement and alters the value
    of the currently selected hand
*/
    public void MoveHand(float movement)
    {
        handValues[selectedHandIndex] += movement;
        handValues[selectedHandIndex] %= maxHandValues[selectedHandIndex];

        clockHands[selectedHandIndex].SetValue(handValues[selectedHandIndex]);
    }
    // change which hand is currently being controlled
    public bool ChangeHand(int direction)
    {
        selectedHandIndex += direction;

        if(selectedHandIndex == -1)
        {
            selectedHandIndex = 0;
            return false;
        }
        if(selectedHandIndex == clockHands.Length)
        {
            selectedHandIndex = clockHands.Length - 1;
            return false;
        }
        return true;
    }
    // coroutine for spawning the hand
    public IEnumerator SpawnHand(int handIndex)
    {
        yield return StartCoroutine(clockHands[handIndex].Spawn());
    }
}
