using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunningState : StateMachineBehaviour
{
    GameObject Goal;
    NavMeshAgent agent;
    NavMeshAgent agent2;
    float DistanceGoal;
    Animator fsm;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Goal = GameObject.FindGameObjectWithTag("goalRed");
        //agent = animator.gameObject.GetComponent<NavMeshAgent>();
        agent = GameObject.FindGameObjectWithTag("agentRed").GetComponent<NavMeshAgent>();
        agent2 = GameObject.FindGameObjectWithTag("agent2Red").GetComponent<NavMeshAgent>();

        
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (GameObject.FindGameObjectWithTag("agentRed").GetComponent<Animator>().GetBool("HasBall"))
        {
            agent.SetDestination(Goal.transform.position);
            DistanceGoal = Vector3.Distance(agent.transform.position, Goal.transform.position);
            animator.SetFloat("DistanceGoal", DistanceGoal);
            if (DistanceGoal <= 9.0f) 
            {
                
            }
        }
        if (GameObject.FindGameObjectWithTag("agent2Red").GetComponent<Animator>().GetBool("HasBall"))
        {
            agent2.SetDestination(Goal.transform.position);
            DistanceGoal = Vector3.Distance(agent2.transform.position, Goal.transform.position);
            animator.SetFloat("DistanceGoal", DistanceGoal);
            if (DistanceGoal <= 9.0f)
            {
                //agent2.ResetPath();
            }
        }
    }
}
