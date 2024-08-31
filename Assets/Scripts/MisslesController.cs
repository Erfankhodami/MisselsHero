using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisslesController : MonoBehaviour
{
    private Rigidbody2D MissleRB;

    [SerializeField] private float SpeedF;
    // Start is called before the first frame update
    void Start()
    {
        MissleRB = GetComponent<Rigidbody2D>();
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
