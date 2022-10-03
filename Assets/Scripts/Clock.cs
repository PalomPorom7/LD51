using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public bool[] handsActive;
    public Hand[] clockHands;

    public float[]  handValues;
    public float[]  maxHandValues = {60, 60, 12};

    public int selectedHandIndex;

    public void MoveHand(float movement)
    {
        handValues[selectedHandIndex] += movement;
        handValues[selectedHandIndex] %= maxHandValues[selectedHandIndex];

        clockHands[selectedHandIndex].SetValue(handValues[selectedHandIndex]);
    }
    public void ChangeHand(int direction)
    {
        
        selectedHandIndex += direction;

        if(selectedHandIndex == -1)
        {
            selectedHandIndex = 0;
        }
        if(selectedHandIndex == clockHands.Length)
        {
            selectedHandIndex = clockHands.Length - 1;
        }
        if(!handsActive[selectedHandIndex])
        {
            selectedHandIndex -= direction;
        }
    }
    public IEnumerator SpawnHand(int handIndex)
    {
        yield return StartCoroutine(clockHands[handIndex].Spawn());
        handsActive[handIndex] = true;
    }
}
