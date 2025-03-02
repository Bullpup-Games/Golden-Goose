using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GooseMovement : MonoBehaviour
{

    //this should be the cursor, unless something else is more urgent
    //such as food, water, a toy, etc. 
    public Transform target; 
    
    NavMeshAgent _agent;
    
   
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    
    void Update()
    {
        _agent.SetDestination(target.position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("You Died");
    }
}
