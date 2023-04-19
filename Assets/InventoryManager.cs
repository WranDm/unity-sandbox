using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager
{
    private List<Craftables> invArr;

    public InventoryManager()
    {
        invArr = new List<Craftables>();

        AddItem(new Craftables { itemType = Craftables.ItemType.Shui, amount = 1 });
        AddItem(new Craftables { itemType = Craftables.ItemType.Shui, amount = 1 });
        AddItem(new Craftables { itemType = Craftables.ItemType.Shui, amount = 1 });
        Debug.Log("inventory");
        Debug.Log(invArr.Count);
        Debug.Log(invArr[1]);
    }
    
    public void AddItem(Craftables item)
    {
        invArr.Add(item);
        Debug.Log("Added!");
    }

    public void RemoveItem(Craftables item)
    {

    }

    public void UseItem(Craftables item)
    {

    }

    public List<Craftables> GetInvList()
    {
        return invArr;
    }
}
