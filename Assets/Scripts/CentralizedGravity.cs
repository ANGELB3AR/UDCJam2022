using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralizedGravity : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] int radius = 5;
    [SerializeField] int forceAmount = 100;
    [SerializeField] float gravity = 1f;
    
    Vector3 targetDirection;
    Rigidbody rb;
    float distance;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //Physics.gravity = new Vector3(0, gravity, 0);
        
    }

    void Update()
    {
        targetDirection = target.position - transform.position;
        distance = targetDirection.magnitude;
        targetDirection = targetDirection.normalized;

        if (distance < radius)
        {
            rb.AddForce(targetDirection * forceAmount * Time.deltaTime);
        }

        Physics.gravity = new Vector3(targetDirection.x, targetDirection.y * forceAmount * Time.deltaTime, targetDirection.z);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
