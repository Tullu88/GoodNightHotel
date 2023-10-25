using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterMovement : MonoBehaviour
{
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetDestination(Vector3 destinationPosition)
    {
        NavMeshPath navMeshPath = new NavMeshPath();
        if (agent.CalculatePath(destinationPosition, navMeshPath) && navMeshPath.status == NavMeshPathStatus.PathComplete)
        {
            agent.SetDestination(destinationPosition);
            print("Valid");
        }
    }
}
