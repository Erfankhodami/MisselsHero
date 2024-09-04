using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MisslesController : MonoBehaviour
{
    private Rigidbody2D MissleRB;
    [SerializeField] private ParticleSystem ParticleSystemP;
    [SerializeField] private GameObject MissleSpriteG;
    [SerializeField] private float SpeedF;
    // Start is called before the first frame update
    void Start()
    {
        MissleRB = GetComponent<Rigidbody2D>();
        //spawn the partcile system of missle flames
        ParticleSystem particleSystemP;
        GameObject missleSpriteG;
        particleSystemP=Instantiate(ParticleSystemP, transform.position, quaternion.Euler(transform.rotation.x+90,transform.rotation.y,transform.rotation.z));
        missleSpriteG=Instantiate(MissleSpriteG, transform.position, transform.rotation);
        particleSystemP.transform.parent = gameObject.transform;
        missleSpriteG.transform.parent = gameObject.transform;
        

        StartCoroutine(DestroyMissle());
    }

    // Update is called once per frame
    void Update()
    {
        MissleRB.AddForce(transform.up*SpeedF*Time.deltaTime*10);
    }

    IEnumerator DestroyMissle()
    {
        for (int i = 0; i < 100; i++)
        {
            yield return null;
        }
        Destroy(gameObject);
    }
}
