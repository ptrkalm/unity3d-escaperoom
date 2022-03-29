using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitWallController : EntityController
{
    public AudioSource wallHideAudio;
    public Animator animator;

    override public void _OnTriggerEnter() {
        //do nothing
    }

    override public void _OnTriggerExit() {
        //do nothing
    }

    override public void _OnItemInteractionEnter(ItemController item) {
        //do nothing
    }

    override public void _OnSpaceInteractionEnter() {
        //do nothing
    }
    
    public void _TriggerInteractionEnter() {
        wallHideAudio.Play();
        AnimateHiding();
    }

    private void AnimateHiding() {
        animator.Play("ExitWallHiding");
    }
}
