using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour {
    MouseInput mouseInput;

    private void Awake() {
        mouseInput = new MouseInput();
    }

    private void OnEnable() {
        mouseInput.Enable();
    }

    private void onDisable() {
        mouseInput.Disable();
    }

    void Start() {
        mouseInput.Player.MouseClick.performed += _ => MouseClick();
    }

    private void MouseClick() {
        Vector2 mousePosition = mouseInput.Player.MousePosition.ReadValue<Vector2>();
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            Debug.Log("Clicked on " + hit.transform.name);
        } else {
            Debug.Log("Nothing hit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
