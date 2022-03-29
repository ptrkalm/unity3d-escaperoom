using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryController : MonoBehaviour
{
    public List<GameObject> slots;
    public PlayerController player;

    void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void AddItem(GameObject item) {
        for (int i = 0; i < slots.Count; i++) {
            Transform slot = slots[i].transform.Find("Slot");
            if (slot.transform.childCount == 0) {
                item.transform.SetParent(slot, false);
            }
        }
    }

    public bool Contains(string name) {
        for (int i = 0; i < slots.Count; i++) {
            Transform slot = slots[i].transform.Find("Slot");
            if (slot.transform.childCount != 0) {
                if (slot.GetChild(0).GetComponent<ItemController>().itemName == name) {
                    return true;
                }
            }
        }

        return false;
    }
}
