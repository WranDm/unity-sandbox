using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private InventoryManager Inventory;
    private Transform Slot;
    private Transform Container;

    private void Awake()
    {
        Container = transform.Find("Container");

        Slot = Container.Find("Slot");
        Debug.Log(Container);
        Debug.Log(Slot);

    }

    public void SetInventory(InventoryManager inv)
    {
        this.Inventory = inv;
        Debug.Log("Is this set?");
        RefreshInv();
    }

    private void RefreshInv()
    {
        int x = 0;
        int y = 0;
        float SlotCellSize = 200f;

        Debug.Log("HEllo!");
        foreach (Craftables item in Inventory.GetInvList())
        {
            Debug.Log(x);
            RectTransform SlotRT = Instantiate(Slot, Container).GetComponent<RectTransform>();
            SlotRT.gameObject.SetActive(true);
            SlotRT.anchoredPosition = new Vector2(x * SlotCellSize, y * SlotCellSize);
            x++;
            if (x > 4)
            {
                x = 0;
                y++;
            }
        }
    }
}
