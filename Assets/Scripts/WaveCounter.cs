using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveCounter : MonoBehaviour
{
    public Transform timer;
    private Vector3 eulers;

    public Text counterText;

    private int counter;
    private float time;

    private void Start()
    {
        eulers = Vector3.zero;
        counter = 0;
        time = 0;
    }
    public IEnumerator Spawn()
    {
        yield return null;
    }
    public void StartCounter()
    {
        StartCoroutine(Every10Seconds());
    }
    public IEnumerator Every10Seconds()
    {
        do
        {
            time = 0;
            counterText.text = ++counter + "";
            do
            {
                time += Time.deltaTime;
                eulers.z = time * 36;
                timer.eulerAngles = eulers;
                yield return null;
            }
            while(time < 10);
        }
        while(true);
    }
}
