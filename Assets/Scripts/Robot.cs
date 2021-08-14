using System;
using UnityEngine;

// INHERITANCE
public class Robot : Agent
{
    public int robotType;
    [SerializeField]
    private Station myStation;
    public SpawnManager spawnManager;

    // POLYMORPHISM
    public override void AssignAndGo() {

        foreach (var item in spawnManager.ItemList)
        {
            //Debug.Log("Robot:" + robotType + " list: " + item.transform.position);
            GoTo(item);
            spawnManager.RemoveItem(item);
            break;
        }
        
        
    }
    // POLYMORPHISM
    protected override void DeliverItem() {

        Item item = m_Target.GetComponent<Item>();
        Destroy(m_Target);
        GoTo(myStation, item.ItemType);
        myStation.MyRobot = this;
    }


}
