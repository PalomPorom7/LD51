using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
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
    public IEnumerator SpawnHand(int handIndex)
    {
        yield return StartCoroutine(clockHands[handIndex].Spawn());
    }
}
