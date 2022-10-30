using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class is used by the 3 clock hands
    to spawn when they are unlocked
    and to rotate
*/
public class Hand : MonoBehaviour
{
    public float value;
    public float maxValue;

    public AnimatedSpawn circle, stem;

    // get references to the parts of the hand
    private void Start()
    {
        circle = transform.GetChild(0).GetComponent<AnimatedSpawn>();
        stem = transform.GetChild(1).GetComponent<AnimatedSpawn>();
    }
    // start coroutines to spawn the parts of the hand
    public IEnumerator Spawn()
    {
        yield return StartCoroutine(circle.Spawn());
        yield return StartCoroutine(stem.Spawn());
    }
    // rotate the hand to the specified value
    public void SetValue(float newValue)
    {
        value = newValue;
        transform.eulerAngles = new Vector3(0, 0, value / maxValue * 360);
    }
}
