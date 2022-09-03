using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralizedGravity : MonoBehaviour
{
    Planet attractorPlanet;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        attractorPlanet = FindObjectOfType<Planet>();
    }

    void Start()
    {
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    void FixedUpdate()
    {
        if (attractorPlanet != null)
        {
            attractorPlanet.Attract(transform);
        }
    }
}
