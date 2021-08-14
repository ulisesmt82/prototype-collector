using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private int myItemType;
    // ENCAPSULATION
    public int ItemType { get { return myItemType; } private set { myItemType = value; } }
}
