using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public GameManager gm;
    public float value;
    public float maxValue;

    public AnimatedSpawn circle, stem;

    private void Start()
    {
        circle = transform.GetChild(0).GetComponent<AnimatedSpawn>();
        stem = transform.GetChild(1).GetComponent<AnimatedSpawn>();
    }
    public IEnumerator Spawn()
    {
        yield return StartCoroutine(circle.Spawn());
        yield return StartCoroutine(stem.Spawn());
    }
    public void SetValue(float newValue)
    {
        value = newValue;
        transform.eulerAngles = new Vector3(0, 0, value / maxValue * 360);
    }
    private void OnCollisionEnter2D(Collision2D c)
    {
        gm.TakeDamage();
    }
}
