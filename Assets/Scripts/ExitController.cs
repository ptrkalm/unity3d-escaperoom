using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : EntityController
{
    public GameObject levelLoader;

    override public void _OnTriggerEnter() {
        levelLoader.GetComponent<SceneController>().End();
    }
}
