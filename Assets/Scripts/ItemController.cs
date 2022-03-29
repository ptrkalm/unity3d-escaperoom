using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public string itemName;
    public bool inInventory = false;
    public AudioSource pickupAudio;
    public AudioSource successfulUseAudio;
    public AudioSource unsuccesfulUseAudio;
    
    public PlayerController player;
    void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void onClick() {
        if (!inInventory) {
            pickupAudio.Play();
            player.addItem(gameObject);
        } else {
            if (player.isTriggering) {
                player.trigger.GetComponent<EntityController>()._OnItemInteractionEnter(this);
            } else {
                unsuccesfulUseAudio.Play();
            }
        }
    }
}
