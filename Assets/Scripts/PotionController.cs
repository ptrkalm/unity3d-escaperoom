using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionController : EntityController
{
    override public void _OnSpaceInteractionEnter() {
        if (isAccessible) {
            gameObject.transform.Find("Potion Item").GetComponent<ItemController>().onClick();
            _OnTriggerExit();
            Destroy(gameObject);
        }
    }


}
