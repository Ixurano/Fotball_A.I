using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchState : StateMachineBehaviour
{

    bool HasBall;
    bool HasBall2;
    NavMeshAgent agent;
    NavMeshAgent agent2;
    GameObject ballFoot;
    GameObject ballFoot2;
    GameObject ball;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent = animator.gameObject.GetComponent<NavMeshAgent>();
        agent = GameObject.FindGameObjectWithTag("agentRed").GetComponent<NavMeshAgent>();
        agent2 = GameObject.FindGameObjectWithTag("agent2Red").GetComponent<NavMeshAgent>();
        ballFoot = GameObject.FindGameObjectWithTag("ballFoot");
        ballFoot2 = GameObject.FindGameObjectWithTag("ballFoot2");
        ball = GameObject.FindGameObjectWithTag("ball");

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.GetComponent<Animator>().GetBool("HasBall") == false && agent.GetComponent<Animator>().GetBool("TeamHaveBall") == false)
        {
            agent.SetDestination(ball.transform.position);
        }

        if(agent2.GetComponent<Animator>().GetBool("HasBall") == false && agent2.GetComponent<Animator>().GetBool("TeamHaveBall") == false)
        {
            agent2.SetDestination(ball.transform.position);
        }
    }
}
