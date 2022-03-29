using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronController : EntityController
{
    private string current;
    public GameObject exitWall;
    public GameObject cameraPivot;

    new void Start() {
        base.Start();
        current = "White";
        Show(current);
    }

    override public void _OnItemInteractionEnter(ItemController item) {
        base._OnItemInteractionEnter(item);
        string itemName = item.itemName;
        if (current == "White") {
            if (itemName == "yellowPotion") {
                Show("Yellow");
            } else if (itemName == "greenPotion") {
                Show("Green");
            } else if (itemName == "bluePotion") {
                Show("Blue");
            } else if (itemName == "redPotion") {
                Show("Red");
            }
        } else if (current == "Yellow") {
            if (itemName == "yellowPotion") {
                Show("Yellow");
            } else if (itemName == "redPotion") {
                Show("Orange");
            } else {
                Show("White");
            }
        } else if (current == "Red") {
            if (itemName == "redPotion") {
                Show("Red");
            } else if (itemName == "yellowPotion") {
                Show("Orange");
            } else {
                Show("White");
            }
        } else if (current == "Orange") {
            if (itemName == "bluePotion") {
                Show("Purple");
            } else {
                Show("White");
            }
        } else if (current == "Purple") {
            if (itemName == "greenPotion") {
                Show("Turq");
                UnlockExit();
            } else {
                Show("White");
            }
        } else {
            Show("White");
        }
    }

    override public void _OnSpaceInteractionEnter() {
        
    }

    override public bool ValidateItem(ItemController item) {
        Debug.Log(item.itemName.EndsWith("Potion"));
        return item.itemName.EndsWith("Potion");
    }

    private void Show(string color) {
        current = color;
        HideAll();
        GameObject cauldron = gameObject.transform.Find("Body").Find(color).gameObject;
        Color rgbColor = cauldron.GetComponent<CauldronColor>().color;
        cauldron.SetActive(true);

        foreach (GameObject torch in GameObject.FindGameObjectsWithTag("Torch")) {
            torch.transform.Find("Fire").gameObject.GetComponent<ParticleSystem>().startColor = rgbColor;
            torch.transform.Find("Point Light").gameObject.GetComponent<Light>().color = rgbColor;
        }
    }

    private void HideAll() {
        Transform body = gameObject.transform.Find("Body");
        foreach (GameObject cauldron in GameObject.FindGameObjectsWithTag("Cauldron")) {
            cauldron.SetActive(false);
        }
    }

    private void UnlockExit() {
        exitWall.GetComponent<ExitWallController>()._TriggerInteractionEnter();
        cameraPivot.GetComponent<ShakeController>().StartShake(8f, 0.5f);
    }
}
