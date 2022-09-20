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

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Goal = GameObject.FindGameObjectWithTag("goalRed");
        agent = GameObject.FindGameObjectWithTag("agentRed").GetComponent<NavMeshAgent>();
        agent2 = GameObject.FindGameObjectWithTag("agent2Red").GetComponent<NavMeshAgent>();
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent.GetComponent<Animator>().GetBool("HasBall"))
        {
            if (agent.GetComponent<Animator>().GetFloat("DistancePlayer") >= 2.1){
                agent.SetDestination(Goal.transform.position);
                DistanceGoal = Vector3.Distance(agent.transform.position, Goal.transform.position);
                animator.SetFloat("DistanceGoal", DistanceGoal);
            }
        }
        if(agent2.GetComponent<Animator>().GetBool("HasBall"))
        {
            if (agent2.GetComponent<Animator>().GetFloat("DistancePlayer") >= 2.1)
            {
                agent2.SetDestination(Goal.transform.position);
                DistanceGoal = Vector3.Distance(agent2.transform.position, Goal.transform.position);
                animator.SetFloat("DistanceGoal", DistanceGoal);
            }   
        }
    }
}
