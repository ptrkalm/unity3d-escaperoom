using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera cam;
    private GameObject player;
    // Update is called once per frame

    void Start() {
        player = GameObject.Find("Player");
        cam.transform.LookAt(player.transform);
    }

    void LateUpdate() {
        float distance = 30;
        transform.position = Vector3.Lerp(transform.position, player.transform.position + new Vector3(-distance, distance, -distance), 0.5f * Time.deltaTime);
        cam.transform.LookAt(player.transform);
    }
}
