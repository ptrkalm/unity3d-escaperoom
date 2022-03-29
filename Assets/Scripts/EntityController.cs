using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityController : MonoBehaviour
{
    public Color accessibleColor;
    public Color unaccessibleColor;

    public AudioSource openUIAudio;
    public AudioSource closeUIAudio;

    public List<AudioSource> audioSources;

    public GameObject body;
    public GameObject interaction;
    public GameObject UI;
    public bool isAccessible = false;

    [HideInInspector] 
    public PlayerController player;

    public void Start() {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public virtual void _OnTriggerEnter() {
        ShowOutline();
        ShowInteractionIcon();
        player.trigger = gameObject;
        player.isTriggering = true;
    }

    public virtual void _OnTriggerExit() {
        HideOutline();
        HideInteractionIcon();
        player.trigger = null;
        player.isTriggering = false;
    }

    public virtual void _OnItemInteractionEnter(ItemController item) {
        ValidateItemUse(item);
    }

    public virtual void _OnSpaceInteractionEnter() {
        openUIAudio.Play();
        if (isAccessible) {
            UI.SetActive(true);
            player.isInteracting = true;
        }
    }
    
    public virtual void _OnInteractionExit() {
        closeUIAudio.Play();
        UI.SetActive(false);
        player.isInteracting = false;
    }

    public bool ValidateItemUse(ItemController item) {
        if (ValidateItem(item)) {
            item.successfulUseAudio.Play();
            return true;
        } else {
            item.unsuccesfulUseAudio.Play();
            return false;
        }
    }

    public virtual bool ValidateItem(ItemController item) {
        return false;
    }

    public void ShowOutline() {
        if (isAccessible) {
            body.GetComponent<Outline>().OutlineColor = accessibleColor;
        } else {
            body.GetComponent<Outline>().OutlineColor = unaccessibleColor;
        }

        body.GetComponent<Outline>().enabled = true;
    }

    void HideOutline() {
        body.GetComponent<Outline>().enabled = false;
    }

    void ShowInteractionIcon() {
        interaction.GetComponent<SpriteRenderer>().enabled = true;
    }

    void HideInteractionIcon() {
        interaction.GetComponent<SpriteRenderer>().enabled = false;
    }
}
