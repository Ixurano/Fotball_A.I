using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SearchState : StateMachineBehaviour
{
    Agent_AI ai;
    bool HasBall;
    NavMeshAgent agent;
    NavMeshAgent agent2;
    GameObject ballFoot;
    GameObject ballFoot2;
    GameObject ball;

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ai = animator.gameObject.GetComponent<Agent_AI>();
        //agent = animator.gameObject.GetComponent<NavMeshAgent>();
        agent = GameObject.FindGameObjectWithTag("agentRed").GetComponent<NavMeshAgent>();
        agent2 = GameObject.FindGameObjectWithTag("agent2Red").GetComponent<NavMeshAgent>();
        ballFoot = GameObject.FindGameObjectWithTag("ballFoot");
        ballFoot2 = GameObject.FindGameObjectWithTag("ballFoot2");
        ball = GameObject.FindGameObjectWithTag("ball");
        HasBall = false;
        //GameObject.FindGameObjectWithTag("agentRed").GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(HasBall == false)
        {
            agent.SetDestination(ball.transform.position);
            agent2.SetDestination(ball.transform.position);
        }
    }
    public void OnTriggerEnter(Collider c)
    {
        if(agent)
        {
            if (c.gameObject.name == "ball")
            {
                ball.transform.position = ballFoot.transform.position;
            }
        }
        if (agent2)
        {
            if (c.gameObject.name == "ball")
            {
                ball.transform.position = ballFoot2.transform.position;
            }
        }

    }
}
