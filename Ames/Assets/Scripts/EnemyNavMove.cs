using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMove : MonoBehaviour
{
    GameObject player;
    NavMeshAgent agent;
    public float chaseDistance = 10;
    private Vector3 home;
    bool m_idle
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        home = transform.position;
        m_Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        if (direction.magnitude < chaseDistance)
        {
            agent.destination = player.transform.position;
            //this is where it is moving
        }
        else if(home != null) 
        {        
            agent.destination = home;
            //here too
        }
        if
        {
            //we're stopped, so play the idle animation
            m_idle = true;
        }
        else
        {
            m_jump = false;
        }
        if (m_idle == false)
            m_Animator.SetBool("idle", false);
        if (m_idle == true)
            m_Animator.SetBool("idle", true);
    }
}
