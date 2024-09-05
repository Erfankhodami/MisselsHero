using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MisslesController : MonoBehaviour
{
    private Rigidbody2D MissleRB;
    [SerializeField] private GameObject ParticlesG;
    [SerializeField] private GameObject MissleSpriteG;

    [SerializeField] private float SpeedF;

    [SerializeField] private float ParticlesForceMultiplierF=100;
    // Start is called before the first frame update
    void Start()
    {
        MissleRB = GetComponent<Rigidbody2D>();
        //spawn the partcile system of missle flames
        GameObject missleSpriteG;
        missleSpriteG = Instantiate(MissleSpriteG, transform.position, transform.rotation);
        missleSpriteG.transform.parent = gameObject.transform;


        StartCoroutine(DestroyMissle());
        StartCoroutine(SpawnParticles());
    }

    // Update is called once per frame
    void Update()
    {
        MissleRB.AddForce(transform.up * SpeedF * Time.deltaTime * 10);
    }

    IEnumerator DestroyMissle()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return null;
        }

        Destroy(gameObject);
    }

    IEnumerator SpawnParticles()
    {
        for (int i = 0; i < 100; i++)
        {
            if (i % 5 == 0)
            {
                GameObject particlesG;
                particlesG=Instantiate(ParticlesG, transform.position, transform.rotation);
                particlesG.GetComponent<Rigidbody2D>().AddForce(-transform.up*ParticlesForceMultiplierF);
            }
            yield return null;
        }
    }
}
