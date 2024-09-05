using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private Rigidbody2D Rb;
    private Vector2 ForceDirV2;
    
    [SerializeField] private float ForceMultiplerF;
    [SerializeField] private float RotationSpeedF;
    [SerializeField] private GameObject MissleG;

    // Start is called before the first frame update
    void Start()
    {
        Rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //applying force to player
        float force;
        Vector2 mousePosv2;
        mousePosv2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ForceDirV2 = (Vector2)transform.position - mousePosv2;
        force = ForceMultiplerF - Rb.velocity.magnitude;
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (force > 0)
            {
                Rb.AddForce(ForceDirV2.normalized * (force * Time.deltaTime * 100), ForceMode2D.Force);
            }
        }

        //player looks the mouse
        if (CheckOnGround())
        {
            float rotation = Vector3.Cross(ForceDirV2, -transform.up).z;
            Rb.angularVelocity = rotation * RotationSpeedF;
        }
        
        //spawning the missle
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(MissleG, transform.position, transform.rotation);
        }
    }

    private bool CheckOnGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1.1f);
        if (colliders.Length == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
