using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    float size = 0;
    float alpha = 1;
    Color color;
    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<SpriteRenderer>().color;
        StartCoroutine(Explode());
    }

    IEnumerator Explode()
    {
        float time = 0;
        float totalTime = 0.25f;
        do
        {
            size = Mathf.Lerp(0, 1, time/totalTime);
            alpha = Mathf.Lerp(1, 0, time/totalTime);

            color.a = alpha;
            GetComponent<SpriteRenderer>().color = color;
            transform.localScale = new Vector3(size, size, size);

            yield return new WaitForFixedUpdate();
            
            time += Time.deltaTime;
        } while (time < totalTime);

        Destroy(gameObject);
    }
}
