using UnityEngine;
using System.Collections;

public abstract class Machine : MonoBehaviour
{
    Color lerpedColor = Color.white;
    [SerializeField]
    private bool m_repair = false;
    private Robot m_robot;
    public Color MyColor;

    private void Update()
    {
        // ABSTRACTION
        SetAlert();

    }

    private void LerpColor()
    {
        lerpedColor = Color.Lerp(Color.white, Color.red, Mathf.PingPong(Time.time, 1));
    }

    public virtual void SetAlert()
    {
        if (m_repair)
        {
            LerpColor();
            var machineRender = GetComponent<Renderer>();
            machineRender.material.SetColor("_Color", lerpedColor);
        }
        else
        {
            var machineRender = GetComponent<Renderer>();
            machineRender.material.SetColor("_Color", MyColor);

        }
    }

    // ENCAPSULATION
    public bool RepairStatus {
        get { return m_repair; }
        set { m_repair = value; }
    }
    // ENCAPSULATION
    public Robot MyRobot {
        get { return m_robot; }
        set { m_robot = value; }
    }

    
}

