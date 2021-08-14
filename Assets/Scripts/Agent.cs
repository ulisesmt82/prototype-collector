using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Agent : MonoBehaviour
{

    private float Speed = 4.0f;
    protected NavMeshAgent m_Agent;
    protected Station m_Station;
    protected GameObject m_Target;
    private int m_CargoType;
    //private int itemInstanceId;
    private Vector3 newPosition;
    protected bool moveTo = false;


    protected void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Agent.speed = Speed;
        m_Agent.acceleration = 999;
        m_Agent.angularSpeed = 999;
        m_Agent.stoppingDistance = 0;
        m_Agent.isStopped = true;

    }

    private void Update()
    {
        // ABSTRACTION
        MoveObjects();
    }


    private void MoveObjects() {
        /* QA Movement - REMOVE THIS
        if (Input.GetMouseButtonDown(0))

        {
            SetDestinationToMousePosition();
        }*/
        if (m_Target != null)
        {
            newPosition = m_Target.transform.position;
            moveTo = true;
        }
        else if (m_Station != null)
        {
            newPosition = m_Station.transform.position;
            moveTo = true;
        }
        else
        {
            moveTo = false;
        }
        if (moveTo)
        {
            float distance = Vector3.Distance(newPosition, transform.position);
            if (distance < 2.0f)
            {
                m_Agent.isStopped = true;
                if (m_Station != null)
                {
                    if (m_Station.type != m_CargoType)
                    {
                        //Debug.Log("Repair:" + m_Station.type+ " -> " + m_CargoType);
                        m_Station.RepairStatus = true;
                        m_Agent.isStopped = true;
                    }
                    else
                    {
                        moveTo = false;
                        m_Station = null;
                    }
                }
                else
                {
                    DeliverItem();
                }

            }
        }
        else
        {
            AssignAndGo();
        }
    }
    public virtual void GoTo(GameObject target) {
        m_Target = target;
        m_Station = null;
        if (m_Target != null) {
            m_Agent.destination = m_Target.transform.position;
            m_Agent.SetDestination(new Vector3(m_Target.transform.position.x, 0, m_Target.transform.position.z));
            m_Agent.isStopped = false;
        }

    }

    public virtual void GoTo(Vector3 position) {
        //m_Target = null;
        m_Agent.SetDestination(position);
        m_Agent.isStopped = false;
    }

    public virtual void GoTo(Station myStation, int cargoType)
    {
        m_Target = null;
        m_Station = myStation;
        m_CargoType = cargoType;
        m_Agent.SetDestination(m_Station.transform.position);
        m_Agent.isStopped = false;
    }

    protected abstract void DeliverItem();
    public abstract void AssignAndGo();

    /*void SetDestinationToMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.point);
            m_Agent.SetDestination(hit.point);
        }
    }*/
}
