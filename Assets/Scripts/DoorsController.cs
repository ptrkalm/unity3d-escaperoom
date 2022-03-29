using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorsController : EntityController
{
    public Animator animator;

    private AudioSource lockedAudio;
    private AudioSource unlockAudio;
    private AudioSource openAudio;

    public string keyName;

    new void Start() {
        base.Start();
        lockedAudio = audioSources[0];
        unlockAudio = audioSources[1];
        openAudio = audioSources[2];
    }

    override public void _OnItemInteractionEnter(ItemController item) {
        if (item.itemName == keyName) {
            StartCoroutine(doorUnlocking());
            Destroy(item.gameObject);
        }
    }

    override public void _OnSpaceInteractionEnter() {
        if (isAccessible) {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            _OnTriggerExit();
            AnimateOpening();
            openAudio.Play();
        } else {
            lockedAudio.Play();
        }
    }

    IEnumerator doorUnlocking() {
        player.isInteracting = true;
        unlockAudio.Play();
        yield return new WaitWhile (() => unlockAudio.isPlaying);
        player.isInteracting = false;
        isAccessible = true;
        ShowOutline();
    }

    private void AnimateOpening() {
        animator.Play("DoorsOpen");
    }

    override public bool ValidateItem(ItemController item) {
        return item.itemName == keyName;
    }
}
