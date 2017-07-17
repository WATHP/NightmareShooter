using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour {

    private NavMeshAgent agent;
    private Transform player;
    private Animator anim;
    public float distance = 0.05f;

	// Use this for initialization
	void Awake () {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
	}

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }

    // Update is called once per frame
    void Update () {
        if (Vector3.Distance(transform.position, player.position) < distance)   
        {
            agent.isStopped = true;
            anim.SetBool("Move", false);
        }
        else
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            anim.SetBool("Move", true);
        }

	}
}
