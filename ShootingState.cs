using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingState : StateMachineBehaviour
{
    Agent_AI ai;
    GameObject Goal;
    Rigidbody ball;
    NavMeshAgent agent;
    NavMeshAgent agent2;
    float DistanceGoal;
    Animator fsm;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Goal = GameObject.FindGameObjectWithTag("goalRed");
        ball = GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody>();
        agent = GameObject.FindGameObjectWithTag("agentRed").GetComponent<NavMeshAgent>();
        agent2 = GameObject.FindGameObjectWithTag("agent2Red").GetComponent<NavMeshAgent>();



        if (GameObject.FindGameObjectWithTag("agentRed").GetComponent<Animator>().GetFloat("DistanceGoal") <= 9.0f)
        {
            Debug.Log("BOOOMCTJACKALACKA");
            ball.AddForce(0, 0, -10.0f, ForceMode.Impulse);
        }
        if (GameObject.FindGameObjectWithTag("agent2Red").GetComponent<Animator>().GetFloat("DistanceGoal") <= 9.0f)
        {
            //ai.HasBall2 = false;
            Debug.Log("BOOOMCTJACKALACKA");
            ball.AddForce(0, 0, -10.0f, ForceMode.Impulse);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

}
