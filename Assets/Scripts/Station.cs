using System.Collections;
using UnityEngine;
// INHERITANCE
public class Station : Machine
{
    public int type;

    public void Fix()
    {
        RepairStatus = false;

        Robot m = MyRobot;
        if (m != null)
        {
            m.AssignAndGo();
        }
    }




}
