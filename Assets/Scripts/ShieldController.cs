using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ShieldController : EntityController
{
    private List<string> secret = new List<string> { "left", "right", "right", "left", "right", "left" };
    private List<string> attempt = new List<string> { "none", "none", "none", "none", "none", "none" };

    public GameObject doorGate;

    public void addMove(string move) {
        attempt.RemoveAt(0);
        attempt.Add(move);

        if (secret.SequenceEqual(attempt)) {
            OpenDoorGate();
        }
    }

    private void OpenDoorGate() {
        doorGate.GetComponent<DoorGateController>()._TriggerInteractionEnter();
    }
}
