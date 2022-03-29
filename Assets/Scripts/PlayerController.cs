using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    public CharacterController controller;
    public Animator animator;
    public AudioSource footsteps;
    public float velocity = 5;

    public GameObject trigger = null;
    public bool isTriggering = false;
    public bool isInteracting = false;

    public GameObject inventoryObj;
    public InventoryController inventory;

    Vector2 input;

    void OnTriggerEnter(Collider entity) {
        entity.transform.gameObject.GetComponent<EntityController>()._OnTriggerEnter();
    }

    void OnTriggerExit(Collider entity) {
        entity.transform.gameObject.GetComponent<EntityController>()._OnTriggerExit();
    }

    void Update() {
        if (isInteracting) {
            AnimateIdle();
            if (Input.GetKeyDown(KeyCode.Escape)) {
                trigger.GetComponent<EntityController>()._OnInteractionExit();
            }
            return;
        }

        if (!controller.isGrounded) {
            controller.SimpleMove(Vector3.zero);
            return;
        }

        if (GetXYInput()) {
            AnimateRun();
            Rotate();
            Move();
            PlayFootSteps();
        } else {
            AnimateIdle();
        }

        if (Input.GetKeyDown("space") && isTriggering) {
            trigger.GetComponent<EntityController>()._OnSpaceInteractionEnter();
            return;
        }
    }

    bool GetXYInput() {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        return Mathf.Abs(input.x) >= 1 || Mathf.Abs(input.y) >= 1;
    }

    float CalculateAngle() {
        float angle = Mathf.Atan2(input.x, input.y);
        angle = Mathf.Rad2Deg * angle + 45;
        return angle;   
    }

    void Rotate() {
        transform.rotation = Quaternion.Euler(0, CalculateAngle(), 0);
    }

    void Move() {
        controller.SimpleMove(transform.forward * velocity);
    }

    void AnimateRun() {
        animator.SetBool("isRunning", true);
    }

    void AnimateIdle() {
        animator.SetBool("isRunning", false);
    }

    void PlayFootSteps() {
        if (!footsteps.isPlaying) {
            footsteps.Play();
        }
    }

    public void addItem(GameObject item) {
        item.GetComponent<ItemController>().inInventory = true;
        inventory.AddItem(item);
    }
}
