using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : MonoBehaviour
{
    public string name;
    public int pointWorth;
    void OnTriggerEnter(Collider other)
    {
        ScoreSystem.theScore += pointWorth;
        InventoryUI.theInventory = this.GetName();
        Destroy(gameObject);
    }

    public string GetName()
    {
        return this.name;
    }
}
