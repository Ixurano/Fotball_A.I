using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent_AI : MonoBehaviour
{
    public bool HasBall;
    public bool HasBall2;
    NavMeshAgent agent;
    NavMeshAgent agent2;
    GameObject agentPlayer;
    GameObject ball;
    GameObject ballFoot;
    GameObject ballFoot2;
    GameObject[] waypoints; // attack waypoints

    // Start is called before the first frame update
    void Start()
    {
        agent = GameObject.FindGameObjectWithTag("agentRed").GetComponent<NavMeshAgent>();
        agent2 = GameObject.FindGameObjectWithTag("agent2Red").GetComponent<NavMeshAgent>();
        ball = GameObject.FindGameObjectWithTag("ball");
        ballFoot = GameObject.FindGameObjectWithTag("ballFoot");
        ballFoot2 = GameObject.FindGameObjectWithTag("ballFoot2");
        HasBall = false;
        HasBall2 = false;
        waypoints = GameObject.FindGameObjectsWithTag("waypointsred");
        

    }

    // Update is called once per frame
    void Update()
    {
        //agent 1 have ball
        if (agent)
        {
            if (agent.GetComponent<Animator>().GetBool("HasBall"))
            {
                agent.GetComponent<Animator>().SetBool("HasBall", true);
                ball.transform.position = ballFoot.transform.position;
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
        }
        //agent 2 have ball
        if (agent2)
        {
            if (agent2.GetComponent<Animator>().GetBool("HasBall"))
            {
                agent2.GetComponent<Animator>().SetBool("HasBall", true);
                ball.transform.position = ballFoot2.transform.position;

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


    }

    private void OnTriggerEnter(Collider other)
    {   //attackArea
        if(agent.GetComponent<Animator>().GetBool("TeamHaveBall") == true)
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
            if(gameObject.tag == "agentRed")
            {
                agent.GetComponent<Animator>().SetBool("HasBall", true);
                //HasBall = true;
                
            }
            if(gameObject.tag == "agent2Red")
            {
                agent2.GetComponent<Animator>().SetBool("HasBall", true);
                //HasBall2 = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {   //lostTheBall
        if(other.gameObject.tag == "ball")
        {
            //HasBall = false;
            //HasBall2 = false;
            agent.GetComponent<Animator>().SetBool("HasBall", false);
            agent2.GetComponent<Animator>().SetBool("HasBall", false);
        }
    }
}
        