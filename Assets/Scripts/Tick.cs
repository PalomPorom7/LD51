using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    This class handles tick health, activation, animation, etc. 
*/
public class Tick : AnimatedSpawn
{
    public GameObject explositionPrefab;
    public Coroutine currentMovement;
    public SpriteRenderer sr;
    public Vector3 originalPosition;
    public int size = 1;
    public bool isActive = false;
    public int health;

    // get reference to the sprite renderer when created
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    // get the original position for resetting purpose
    public void Initialize()
    {
        originalPosition = transform.position;
    }
/*
    Coroutine inherited from Animated Spawn,
    but with additional logic making 5 minute
    and 10 minute markers bigger
*/

    public IEnumerator Spawn(int index)
    {
        if(index % 5 == 0)
            ++size;
        if(index % 10 == 0)
            ++size;

        endScale = new Vector3(0.1f, size * 0.1f, 1);

        return base.Spawn();
    }
/*
    Activate a tick to start attacking the player
    set the initial values and start the coroutine
*/
    public void Activate()
    {
        isActive = true;
        health = size;
        sr.color = Color.red;
        currentMovement = StartCoroutine(Move(Vector3.zero, 0.1f));
    }
/*
    Upon defeat, spawn explosion, stop the coroutine,
    start new coroutine moving back
*/
    public void Deactivate()
    {
        GameObject g = Instantiate(explositionPrefab);
        g.transform.position = transform.position;

        StopCoroutine(currentMovement);
        sr.color = Color.black;
        currentMovement = StartCoroutine(Move(originalPosition, 10));
    }
    // coroutine moves the tick, used both for attack and death
    private IEnumerator Move(Vector3 endPosition, float speed)
    {
        float t = 0;
        Vector3 startPosition = transform.position;
        do
        {
            t += Time.deltaTime * speed;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return new WaitForFixedUpdate();
        }while(t < 1);
        isActive = false;
    }
    // when struck by the player, reduce health and/or die
    public void OnTriggerEnter2D(Collider2D c)
    {
        if(--health == 0)
            Deactivate();
    }
}
