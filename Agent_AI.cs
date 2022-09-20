using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent_AI : MonoBehaviour
{
    bool FreeSight;
    NavMeshAgent agent;
    NavMeshAgent agent2;
    NavMeshAgent enemy;
    GameObject agentPlayer;
    GameObject ball;
    GameObject ballFoot;
    GameObject ballFoot2;
    GameObject Goal;
    int VisionDistance = 6, VisionAngle = 45;
    RaycastHit Hit;
    //GameObject[] waypoints; // attack waypoints

    // Start is called before the first frame update
    void Start()
    {
        Goal = GameObject.FindGameObjectWithTag("goalRed");
        agent = GameObject.FindGameObjectWithTag("agentRed").GetComponent<NavMeshAgent>();
        agent2 = GameObject.FindGameObjectWithTag("agent2Red").GetComponent<NavMeshAgent>();
        enemy = GameObject.FindGameObjectWithTag("agentBlue").GetComponent<NavMeshAgent>();
        ball = GameObject.FindGameObjectWithTag("ball");
        ballFoot = GameObject.FindGameObjectWithTag("ballFoot");
        ballFoot2 = GameObject.FindGameObjectWithTag("ballFoot2");

    }

    // Update is called once per frame
    void Update()
    {
        //updates distance to enemyPlayer
        agent.GetComponent<Animator>().SetFloat("DistancePlayer", Vector3.Distance(agent.transform.position, enemy.transform.position));
        agent2.GetComponent<Animator>().SetFloat("DistancePlayer", Vector3.Distance(agent2.transform.position, enemy.transform.position));
        agent.GetComponent<Animator>().SetFloat("DistanceGoal", Vector3.Distance(agent.transform.position, Goal.transform.position));
        agent2.GetComponent<Animator>().SetFloat("DistanceGoal", Vector3.Distance(agent2.transform.position, Goal.transform.position));
        //agent 1 have ball
        if (agent.GetComponent<Animator>().GetBool("HasBall"))
        {
            agent.GetComponent<Animator>().SetBool("HasBall", true);
            if (Vector3.Distance(transform.position, enemy.transform.position) >= VisionDistance && Vector3.Angle(transform.forward, (enemy.transform.position - transform.position)) < VisionAngle)
            {
                if (Physics.Raycast(transform.position, enemy.transform.position - transform.position, out Hit))
                {
                    if (Hit.collider.name == "SoccerPlayerBlue")
                    {
                        FreeSight = false;
                        agent.GetComponent<Animator>().SetBool("FreeSight", FreeSight);
                    }
                    else
                    {
                        FreeSight = true;
                    }

                }
            }
            if (agent.GetComponent<Animator>().GetFloat("DistanceGoal") >= 9.1f)
            {
                ball.transform.position = ballFoot.transform.position;
            }
            agent.GetComponent<Animator>().SetBool("FreeSight", FreeSight);
        }
        //team have ball
        if (agent2.GetComponent<Animator>().GetBool("HasBall"))
        {
            agent.GetComponent<Animator>().SetBool("TeamHaveBall", true);
        }
        //team does not have ball
        if (!agent2.GetComponent<Animator>().GetBool("HasBall"))
        {
            agent.GetComponent<Animator>().SetBool("TeamHaveBall", false);
        }
        //agent 2 have ball

        if (agent2.GetComponent<Animator>().GetBool("HasBall"))
        {
            agent2.GetComponent<Animator>().SetBool("HasBall", true);

            if (Vector3.Distance(transform.position, enemy.transform.position) >= VisionDistance && Vector3.Angle(transform.forward, (enemy.transform.position - transform.position)) < VisionAngle)
            {
                if (Physics.Raycast(transform.position, enemy.transform.position - transform.position, out Hit))
                {
                    if (Hit.collider.name == "SoccerPlayerBlue")
                    {
                        FreeSight = false;
                        agent2.GetComponent<Animator>().SetBool("FreeSight", FreeSight);
                    }
                    else
                    {
                        FreeSight = true;
                    }

                }
            }
            if (agent2.GetComponent<Animator>().GetFloat("DistanceGoal") >= 9.1f)
            {
                ball.transform.position = ballFoot2.transform.position;
            }
            agent2.GetComponent<Animator>().SetBool("FreeSight", FreeSight);
        }
        //team have ball
        if (agent.GetComponent<Animator>().GetBool("HasBall"))
        {
            agent2.GetComponent<Animator>().SetBool("TeamHaveBall", true);
        }
        //team does not have ball
        if (!agent.GetComponent<Animator>().GetBool("HasBall"))
        {
            agent2.GetComponent<Animator>().SetBool("TeamHaveBall", false);
        }


    }

    private void OnTriggerEnter(Collider other)
    {   //attackArea
        if (agent.GetComponent<Animator>().GetBool("TeamHaveBall") == true)
        {
            if (other.gameObject.tag == "waypointsred")
            {
                if (gameObject.tag == "agentRed")
                {
                    if (agent.GetComponent<Animator>().GetBool("HasBall") == false)
                    {
                        agent.GetComponent<Animator>().GetBehaviour<attackAreaState>().OnTriggerEnter(other);
                    }
                }
            }
        }
        if (agent2.GetComponent<Animator>().GetBool("TeamHaveBall") == true)
        {
            if (other.gameObject.tag == "waypointsred")
            {
                if (gameObject.tag == "agent2Red")
                {
                    if (agent2.GetComponent<Animator>().GetBool("HasBall") == false)
                    {
                        agent2.GetComponent<Animator>().GetBehaviour<attackAreaState>().OnTriggerEnter(other);
                    }
                }
            }
        }

        //searchState
        if (other.gameObject.tag == "ball")
        {
            if (gameObject.tag == "agentRed")
            {
                agent.GetComponent<Animator>().SetBool("HasBall", true);
                agent.GetComponent<Animator>().SetFloat("DistanceGoal", Vector3.Distance(agent.transform.position, Goal.transform.position));
                ball.transform.position = ballFoot.transform.position;

            }
            if (gameObject.tag == "agent2Red")
            {
                agent2.GetComponent<Animator>().SetBool("HasBall", true);
                agent2.GetComponent<Animator>().SetFloat("DistanceGoal", Vector3.Distance(agent.transform.position, Goal.transform.position));
                ball.transform.position = ballFoot2.transform.position;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {   //lostTheBall
        if (other.gameObject.tag == "ball")
        {
            agent.GetComponent<Animator>().SetBool("HasBall", false);
            agent2.GetComponent<Animator>().SetBool("HasBall", false);
        }
    }
}
