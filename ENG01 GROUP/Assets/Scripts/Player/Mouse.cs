using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    [SerializeField] private Transform PB;

    [SerializeField] private float sensitivity;

    private float mouseX;
    private float mouseY;

    private float rotateX = 0f;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update() {
        this.ViewOrientation();


    }

    void ViewOrientation() {
        this.mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        this.mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        this.rotateX -= this.mouseY;
        this.rotateX = Mathf.Clamp(this.rotateX, -90f, 90f); //this is to set the rotation to stop at a certain angle in Y

        transform.localRotation = Quaternion.Euler(this.rotateX, 0f, 0f);
        PB.Rotate(Vector3.up * this.mouseX);
    }
}
