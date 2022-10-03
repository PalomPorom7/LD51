using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Clock clock;
    public TickSpawner ticks;

    private void Start()
    {
        StartCoroutine(Setup());
    }
    private IEnumerator Setup()
    {
        yield return StartCoroutine(clock.SpawnHand(0));
        yield return StartCoroutine(ticks.SpawnTicks());

        StartCoroutine(StartWaves());
    }
    private IEnumerator StartWaves()
    {
        for(int i = 0; i != 6; ++i)
        {
            ticks.ticks[Random1()].Activate();
            yield return new WaitForSeconds(1);
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random1()].Activate();
            yield return new WaitForSeconds(1);
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random1()].Activate();
            yield return new WaitForSeconds(1);
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random1()].Activate();
            yield return new WaitForSeconds(7);
        }
        StartCoroutine(clock.SpawnHand(1));
        for(int i = 0; i != 6; ++i)
        {
            ticks.ticks[Random2()].Activate();
            yield return new WaitForSeconds(1);
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random2()].Activate();
            yield return new WaitForSeconds(1);
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random2()].Activate();
            yield return new WaitForSeconds(1);
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random2()].Activate();
            yield return new WaitForSeconds(7);
        }
        StartCoroutine(clock.SpawnHand(2));
        for(int i = 0; i != 6; ++i)
        {
            ticks.ticks[Random3()].Activate();
            yield return new WaitForSeconds(1);
            ticks.ticks[Random2()].Activate();
            ticks.ticks[Random3()].Activate();
            yield return new WaitForSeconds(1);
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random2()].Activate();
            ticks.ticks[Random3()].Activate();
            yield return new WaitForSeconds(1);
            ticks.ticks[Random1()].Activate();
            ticks.ticks[Random2()].Activate();
            ticks.ticks[Random3()].Activate();
            ticks.ticks[Random3()].Activate();
            yield return new WaitForSeconds(7);
        }
    }
    private int Random1()
    {
        int random;
        do
        {
            random = Random.Range(0, 60);
        }while(random % 5 == 0);

        return random;
    }
    private int Random2()
    {
        return Random.Range(0, 6) * 10 + 5;
    }
    private int Random3()
    {
        return Random.Range(0, 6) * 10;
    }
}
