using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorGateController : EntityController
{
    public Animator animator;
    
    private AudioSource lockedAudio;
    private AudioSource unlockAudio;
    private AudioSource openAudio;

    new void Start() {
        base.Start();
        lockedAudio = audioSources[0];
        unlockAudio = audioSources[1];
        openAudio = audioSources[2];
    }

    override public void _OnSpaceInteractionEnter() {
        lockedAudio.Play();
    }

    public void _TriggerInteractionEnter() {
        StartCoroutine(doorOpening());
    }

    IEnumerator doorOpening() {
        gameObject.GetComponent<BoxCollider>().enabled = false;
        unlockAudio.Play();
        yield return new WaitWhile (() => unlockAudio.isPlaying);
        AnimateOpening();
        openAudio.Play();
    }

    private void AnimateOpening() {
        animator.Play("DoorGateOpen");
    }
}
