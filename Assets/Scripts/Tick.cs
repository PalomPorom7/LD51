using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tick : AnimatedSpawn
{
    GameManager gm;
    public GameObject explositionPrefab;
    public Coroutine currentMovement;
    public SpriteRenderer sr;
    public Vector3 originalPosition;
    public int size = 1;
    public bool isActive = false;
    public int health;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        sr = GetComponent<SpriteRenderer>();
    }
    public void Initialize()
    {
        originalPosition = transform.position;
    }
    public IEnumerator Spawn(int index)
    {
        if(index % 5 == 0)
            ++size;
        if(index % 10 == 0)
            ++size;

        endScale = new Vector3(0.1f, size * 0.1f, 1);

        return base.Spawn();
    }
    public void Activate()
    {
        isActive = true;
        health = size;
        sr.color = Color.red;
        currentMovement = StartCoroutine(Move(Vector3.zero, 0.1f));
    }
    public void Deactivate()
    {
        GameObject g = Instantiate(explositionPrefab);
        g.transform.position = transform.position;

        StopCoroutine(currentMovement);
        sr.color = Color.black;
        currentMovement = StartCoroutine(Move(originalPosition, 10));
    }
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
    public void OnTriggerEnter2D(Collider2D c)
    {
        if(c.tag == "Player")
            gm.TakeDamage();
        else if(--health == 0)
            Deactivate();
    }
}
