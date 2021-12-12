using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform TargetPlayer;

    public Animator Animator;

    private NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();


    }

    // Update is called once per frame
    private void Update()
    {
        navMeshAgent.SetDestination(TargetPlayer.transform.position);

        Animator.SetFloat("VelocitySpeed", navMeshAgent.desiredVelocity.magnitude);
    }
}
