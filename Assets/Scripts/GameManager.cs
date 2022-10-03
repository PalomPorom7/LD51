using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Clock clock;
    public TickSpawner ticks;

    public Text counter;
    public InputManager im;
    public GameObject horizontalControls;
    public GameObject verticalControls;
    public int waveNumber;

    private void Start()
    {
        waveNumber = 0;
        StartCoroutine(Setup());
    }
    private IEnumerator Setup()
    {
        yield return StartCoroutine(clock.SpawnHand(0));
        yield return StartCoroutine(ticks.SpawnTicks());

        counter.gameObject.SetActive(true);
        horizontalControls.SetActive(true);

        StartCoroutine(StartWaves());
    }
    private IEnumerator StartWaves()
    {
        for(int i = 0; i != 6; ++i)
        {
            counter.text = ++waveNumber + "";
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
        im.verticalIsActive = true;
        verticalControls.SetActive(true);
        for(int i = 0; i != 6; ++i)
        {
            counter.text = ++waveNumber + "";
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
            counter.text = ++waveNumber + "";
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
        }while(random % 5 == 0 || ticks.ticks[random].isActive);

        return random;
    }
    private int Random2()
    {
        int random;
        do
        {
            random = Random.Range(0, 6) * 10 + 5;
        } while (ticks.ticks[random].isActive);
        return random;
    }
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
