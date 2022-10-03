using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickSpawner : MonoBehaviour
{
    public Vector3  spawnDistance,
                    spawnRotation;

    public GameObject tickPrefab;

    public Tick[] ticks;

    public float staggerTime;

    private void Start()
    {
        ticks = new Tick[60];
        int angle = 0;

        for(int i = 0; i != 60; ++i)
        {
            ticks[i] = Instantiate(tickPrefab, transform).GetComponent<Tick>();
            ticks[i].transform.position = spawnDistance;
            ticks[i].transform.RotateAround(transform.position, Vector3.back, angle);
            ticks[i].Initialize();
            angle += 6;
        }
    }
    public IEnumerator SpawnTicks()
    {
        for(int i = 0; i != 60; ++i)
        {
            StartCoroutine(ticks[i].Spawn(i));
            yield return new WaitForSeconds(staggerTime);
        }
    }
}
