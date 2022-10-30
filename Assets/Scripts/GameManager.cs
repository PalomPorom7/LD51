using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class controls the game flow
    including the animations at the start,
    unlocking access to each clock hand,
    and launching the attack waves
*/
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
        // spawn second hand
        yield return StartCoroutine(clock.SpawnHand(0));
        // spawn clock ticks
        yield return StartCoroutine(ticks.SpawnTicks());
        // start waves
        StartCoroutine(StartWaves());
    }
    private IEnumerator StartWaves()
    {
        // first 6 waves
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
        // spawn minute hand
        StartCoroutine(clock.SpawnHand(1));
        // next 6 waves
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
        // spawn hour hand
        StartCoroutine(clock.SpawnHand(2));
        // last 6 waves
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
    // pick a random tick that isn't a 5 or 10 minute marker
    private int Random1()
    {
        int random;
        do
        {
            random = Random.Range(0, 60);
        }while(random % 5 == 0 || ticks.ticks[random].isActive);

        return random;
    }
    // pick a random 5 minute marker
    private int Random2()
    {
        int random;
        do
        {
            random = Random.Range(0, 6) * 10 + 5;
        } while (ticks.ticks[random].isActive);
        return random;
    }
    // pick a random 10 minute marker
    private int Random3()
    {
        int random;
        do
        {
            random = Random.Range(0, 6) * 10;
        } while (ticks.ticks[random].isActive);
        return random;
    }
}
