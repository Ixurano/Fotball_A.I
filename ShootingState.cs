using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ShootingState : StateMachineBehaviour
{
    Rigidbody ball;
    NavMeshAgent agent;
    NavMeshAgent agent2;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ball = GameObject.FindGameObjectWithTag("ball").GetComponent<Rigidbody>();
        agent = GameObject.FindGameObjectWithTag("agentRed").GetComponent<NavMeshAgent>();
        agent2 = GameObject.FindGameObjectWithTag("agent2Red").GetComponent<NavMeshAgent>();



        if (agent.GetComponent<Animator>().GetFloat("DistanceGoal") <= 9.0f)
        {
            ball.AddForce(0, 0, -10.0f, ForceMode.Impulse);
            //Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
        if (agent2.GetComponent<Animator>().GetFloat("DistanceGoal") <= 9.0f)
        {
            ball.AddForce(0, 0, -10.0f, ForceMode.Impulse);
            //Application.Quit();
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }
}
