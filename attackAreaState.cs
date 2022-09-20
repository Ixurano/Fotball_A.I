using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class attackAreaState : StateMachineBehaviour
{
    NavMeshAgent agent;
    NavMeshAgent agent2;
    GameObject WP;
    GameObject[] waypoints; // attack waypoints
    int wpi = 0;    // attack waypoints index
    string lastWP = "start";

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypointsred");
        agent = GameObject.FindGameObjectWithTag("agentRed").GetComponent<NavMeshAgent>();
        agent2 = GameObject.FindGameObjectWithTag("agent2Red").GetComponent<NavMeshAgent>();
        // goes from passingstate to attack resume new path
        if (!agent.GetComponent<Animator>().GetBool("HasBall"))
        {
            agent.isStopped = false;
        }
        if (!agent2.GetComponent<Animator>().GetBool("HasBall"))
        {
            agent2.isStopped = false;
        }


        SetNextWaypoint();
    }
    void SetNextWaypoint()
    {
        do
        {
            wpi = Random.Range(1, waypoints.Length - 1);
        }
        while (lastWP.Equals(waypoints[wpi].gameObject.name));

        if (GameObject.FindGameObjectWithTag("agentRed").GetComponent<Animator>().GetBool("TeamHaveBall"))
        {
            agent.SetDestination(waypoints[wpi].transform.position);
        }
        if (GameObject.FindGameObjectWithTag("agent2Red").GetComponent<Animator>().GetBool("TeamHaveBall"))
        {
            agent2.SetDestination(waypoints[wpi].transform.position);
        }
        
        lastWP = waypoints[wpi].gameObject.name;
    }
    public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == waypoints[wpi].gameObject.name)
        {
            SetNextWaypoint();
        }
    }
}
