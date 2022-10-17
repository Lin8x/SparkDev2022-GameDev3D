using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_ai : MonoBehaviour
{
    public NavMeshAgent this_agent;
    public GameObject player;

    void Update()
    {
        this_agent.SetDestination(player.transform.position);
    }
}
