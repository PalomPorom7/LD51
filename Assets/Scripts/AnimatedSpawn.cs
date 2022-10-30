using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    inherited class to spawn various things
    on screen by lerping their scale
*/
public class AnimatedSpawn : MonoBehaviour
{
    public Vector3  startScale,
                    currentScale,
                    endScale;
    
    public float animationSpeed;
    public IEnumerator Spawn()
    {
        float t = 0;
        do
        {
            t += Time.deltaTime;
            transform.localScale = Vector3.LerpUnclamped(startScale, endScale, t);
            yield return null;
        }while(t < 1);
    }
}
