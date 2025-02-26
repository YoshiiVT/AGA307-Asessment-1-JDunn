using Unity.VisualScripting;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    //This is a reference that will be multiplied on the Mouse movement
    public float mouseSensitivity = 100f;

    //Transform is a component of a GameObject determined in inspector
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // This hides and locks the cursor to the center of the screen
    }

    void Update()
    {
        //This is a reference to a premade access inside of unity (Go to ProjectSettings.Input)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        //Time.deltaTime is the time that has gone since the last time the update function was called

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        //This will lock the virtical rotation to stop the camera going around

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        playerBody.Rotate(Vector3.up * mouseX);

    }

}
