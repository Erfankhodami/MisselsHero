using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissleParticlesController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyParticle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DestroyParticle()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return null;
        }

        Destroy(gameObject);
    }
}
