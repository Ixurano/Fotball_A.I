using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PassingState : StateMachineBehaviour
{
    GameObject Goal;
    NavMeshAgent agent;
    NavMeshAgent agent2;
    int VisionDistance = 10, VisionAngle = 70;
    GameObject ballFoot;
    GameObject ballFoot2;
    GameObject ball;
    RaycastHit Hit;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Goal = GameObject.FindGameObjectWithTag("goalRed");
        agent = GameObject.FindGameObjectWithTag("agentRed").GetComponent<NavMeshAgent>();
        agent2 = GameObject.FindGameObjectWithTag("agent2Red").GetComponent<NavMeshAgent>();
        ballFoot = GameObject.FindGameObjectWithTag("ballFoot");
        ballFoot2 = GameObject.FindGameObjectWithTag("ballFoot2");
        ball = GameObject.FindGameObjectWithTag("ball");
        if (agent.GetComponent<Animator>().GetBool("HasBall"))
        {
            agent.isStopped = true;
        }
        if (agent2.GetComponent<Animator>().GetBool("HasBall"))
        {
            agent2.isStopped = true;
        }



    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Red 1 have ball
        if (agent.GetComponent<Animator>().GetBool("HasBall"))
        {
            if (Vector3.Distance(agent.transform.position, agent2.transform.position) >= VisionDistance && Vector3.Angle(agent.transform.forward, (agent2.transform.position - agent.transform.position)) < VisionAngle)
            {
                if (Physics.Raycast(agent.transform.position, agent2.transform.position - agent.transform.position, out Hit))
                {
                    if (Hit.collider.name == "SoccerPlayerRed2")
                    {
                        Debug.Log("Passing to team");
                        ball.transform.position = ballFoot2.transform.position;
                    }
                }
            }
        }
        //Red 2 have ball
        if (agent2.GetComponent<Animator>().GetBool("HasBall"))
        {
            if (Vector3.Distance(agent2.transform.position, agent.transform.position) >= VisionDistance && Vector3.Angle(agent2.transform.forward, (agent.transform.position - agent2.transform.position)) < VisionAngle)
            {
                if (Physics.Raycast(agent2.transform.position, agent.transform.position - agent2.transform.position, out Hit))
                {
                    if (Hit.collider.name == "SoccerPlayerRed")
                    {
                        Debug.Log("Passing to team");
                        ball.transform.position = ballFoot.transform.position;
                    }
                }
            }
        }
    }

}
