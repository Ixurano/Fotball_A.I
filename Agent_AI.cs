using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent_AI : MonoBehaviour
{
    bool HasBall;
    bool HasBall2;
    bool TeamHaveBall;
    bool Red2HaveBall;
    NavMeshAgent agent;
    NavMeshAgent agent2;
    GameObject agentPlayer;
    GameObject ball;
    Animator fsm;
    GameObject ballFoot;
    GameObject ballFoot2;
    GameObject[] waypoints; // attack waypoints

    // Start is called before the first frame update
    void Start()
    {
        fsm = GetComponent<Animator>();
        //agent = GetComponent<NavMeshAgent>();
        agent = GameObject.FindGameObjectWithTag("agentRed").GetComponent<NavMeshAgent>();
        agent2 = GameObject.FindGameObjectWithTag("agent2Red").GetComponent<NavMeshAgent>();
        ball = GameObject.FindGameObjectWithTag("ball");
        ballFoot = GameObject.FindGameObjectWithTag("ballFoot");
        ballFoot2 = GameObject.FindGameObjectWithTag("ballFoot2");
        HasBall = false;
        HasBall2 = false;
        TeamHaveBall = false;
        Red2HaveBall = false;
        waypoints = GameObject.FindGameObjectsWithTag("waypointsred");
        

    }

    // Update is called once per frame
    void Update()
    {
        //agent 1 have ball
        if (agent)
        {
            if (HasBall == true)
            {
                //fsm.SetBool("HasBall", true);
                agent.GetComponent<Animator>().SetBool("HasBall", true);
                ball.transform.position = ballFoot.transform.position;
            }
            //team have ball
            if (HasBall2 == true)
            {
                //Debug.Log("Team have ball");
                agent.GetComponent<Animator>().SetBool("TeamHaveBall", true);
            }
            //team does not have ball
            if (HasBall2 == false)
            {
                agent.GetComponent<Animator>().SetBool("TeamHaveBall", false);
            }
        }
        //agent 2 have ball
        if (agent2)
        {
            if(HasBall2 == true)
            {
                //fsm.SetBool("HasBall", true);
                agent2.GetComponent<Animator>().SetBool("HasBall", true);
                ball.transform.position = ballFoot2.transform.position;
            }
            //team have ball
            if (HasBall == true)
            {
                agent2.GetComponent<Animator>().SetBool("TeamHaveBall", true);
            }
            //team does not have ball
            if (HasBall == false)
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
                    if (agent.GetComponent<Animator>().GetBool("HasBall") == false)
                    {
                        agent.GetComponent<Animator>().GetBehaviour<attackAreaState>().OnTriggerEnter(other);
                    }
                }
            }
        }
        //if (other.gameObject.tag == "waypointsred")
        //{
        //    if (gameObject.tag == "agentRed")
        //    {
        //        if (agent.GetComponent<Animator>().GetBool("HasBall") == false)
        //        {
        //            agent.GetComponent<Animator>().GetBehaviour<attackAreaState>().OnTriggerEnter(other);
        //        }
        //    }
        //    if (gameObject.tag == "agent2Red")
        //    {
        //        if (agent2.GetComponent<Animator>().GetBool("HasBall") == false)
        //        {
        //            agent2.GetComponent<Animator>().GetBehaviour<attackAreaState>().OnTriggerEnter(other);
        //        }
        //    }
        //    //fsm.GetBehaviour<attackAreaState>().OnTriggerEnter(other);
        //};
        //searchState
        if (other.gameObject.tag == "ball")
        {
            if(gameObject.tag == "agentRed")
            {
                agent.GetComponent<Animator>().SetBool("HasBall", true);
                //agent.GetComponent<Animator>().GetBehaviour<SearchState>().OnTriggerEnter(other);
                //fsm.SetBool("HasBall", true);
                //fsm.GetBehaviour<SearchState>().OnTriggerEnter(other);

                HasBall = true;
                
            }
            if(gameObject.tag == "agent2Red")
            {
                agent2.GetComponent<Animator>().SetBool("HasBall", true);
                //agent2.GetComponent<Animator>().GetBehaviour<SearchState>().OnTriggerEnter(other);
                //fsm.SetBool("HasBall", true);
                //fsm.GetBehaviour<SearchState>().OnTriggerEnter(other);

                HasBall2 = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {   //lostTheBall
        if(other.gameObject.tag == "ball")
        {
            HasBall = false;
            HasBall2 = false;
            fsm.SetBool("HasBall", false);
        }
    }
}
        