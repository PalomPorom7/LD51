using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class mathematically lays out and spawns
    the 60 ticks around the outside of the clock face
*/
public class TickSpawner : MonoBehaviour
{
    public Vector3  spawnDistance,
                    spawnRotation;

    public GameObject tickPrefab;

    public Tick[] ticks;

    public float staggerTime;

    // when the scene starts, use maths to lay out the 60 ticks in a circle
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
/*
    This is called during the starting animation sequence
    to spawn the ticks in a pretty staggered fashion
*/
    public IEnumerator SpawnTicks()
    {
        for(int i = 0; i != 60; ++i)
        {
            StartCoroutine(ticks[i].Spawn(i));
            yield return new WaitForSeconds(staggerTime);
        }
    }
}
