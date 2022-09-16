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

    }

    // Update is called once per frame
    void Update()
    {
        if(HasBall == false)
        {
            fsm.SetBool("HasBall", false);
        }
        //agent 1 have ball
        if (agent)
        {
            if (HasBall == true)
            {
                ball.transform.position = ballFoot.transform.position;
                //Debug.Log("agent 1 have ball");
            }
            //team have ball
            if (HasBall2 == true)
            {
                fsm.SetBool("TeamHaveBall", true);
            }
            //team does not have ball
            if (HasBall2 == false)
            {
                fsm.SetBool("TeamHaveBall", false);
            }
        }
        //agent 2 have ball
        if (agent2)
        {
            if(HasBall2 == true)
            {
                ball.transform.position = ballFoot2.transform.position;
                //Debug.Log("agent 2 have ball");
            }
            //team have ball
            if (HasBall == true)
            {
                fsm.SetBool("TeamHaveBall", true);
            }
            //team does not have ball
            if (HasBall == false)
            {
                fsm.SetBool("TeamHaveBall", false);
            }
        }


    }

    private void OnTriggerEnter(Collider other)
    {   //attackArea
        if (other.gameObject.tag == "waypointsred")
        {
            fsm.GetBehaviour<attackAreaState>().OnTriggerEnter(other);
        };
        //searchState
        if(other.gameObject.tag == "ball")
        {
            if(gameObject.tag == "agentRed")
            {
                Debug.Log("fel hit");
                fsm.GetBehaviour<SearchState>().OnTriggerEnter(other);
                HasBall = true;
                fsm.SetBool("HasBall", true);
            }
            if(gameObject.tag == "agent2Red")
            {
                Debug.Log("rätt hit");
                fsm.GetBehaviour<SearchState>().OnTriggerEnter(other);
                HasBall2 = true;
                fsm.SetBool("HasBall", true);
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
        