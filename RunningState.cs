using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunningState : StateMachineBehaviour
{
    GameObject Goal;
    Agent_AI ai;
    bool HasBall;
    NavMeshAgent agent;
    GameObject ballFoot;
    GameObject ball;
    float DistanceGoal;
    Animator fsm;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Goal = GameObject.FindGameObjectWithTag("goalRed");
        ai = animator.gameObject.GetComponent<Agent_AI>();
        agent = animator.gameObject.GetComponent<NavMeshAgent>();
        ballFoot = GameObject.FindGameObjectWithTag("ballFoot");
        ball = GameObject.FindGameObjectWithTag("ball");
        HasBall = true;
        
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (HasBall == true)
        {
            agent.SetDestination(Goal.transform.position);
            DistanceGoal = Vector3.Distance(agent.transform.position, Goal.transform.position);
            animator.SetFloat("DistanceGoal", DistanceGoal);
            if (DistanceGoal < 6.2f) 
            {
                
            }
        }
    }

    //OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}
}
