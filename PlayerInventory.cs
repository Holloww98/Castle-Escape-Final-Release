using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<ItemObject> itemsheld = new List<ItemObject>();
    
    public void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<ItemObject>();
        if (item)
        {
            itemsheld.Add(item);
            
        }
    }
}
