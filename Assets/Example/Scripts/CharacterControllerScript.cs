using System;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float mouseSensitivity;
    private Transform cam;
    private CharacterController _controllerScript;
    Vector3 move = Vector3.zero;
    Vector2 rot = Vector2.zero;
    private void Awake()
    {
        cam = GetComponentInChildren<Camera>().transform;
        _controllerScript = GetComponent<CharacterController>();
    }

    void Update()
    {
        move.x = Input.GetAxisRaw("Horizontal");
        move.z = Input.GetAxisRaw("Vertical");
        
        if (_controllerScript.isGrounded && move.y < 0) move.y = 0f;
            
        if (_controllerScript.isGrounded && Input.GetKey(KeyCode.Space))
            move.y += MathF.Sqrt(jumpSpeed * -3f * Physics.gravity.y);
        move.y += Physics.gravity.y * 0.5f * Time.deltaTime;
      
        _controllerScript.Move(transform.TransformDirection(move) * speed * Time.deltaTime);
        CameraLook();
    }

    void CameraLook()
    {
        rot.x -= Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        rot.y += Input.GetAxisRaw("Mouse X") * mouseSensitivity;
        rot.x = Mathf.Clamp(rot.x, -90, 90);
        cam.localRotation = Quaternion.Euler(new Vector3(rot.x, 0, 0));
        transform.localRotation = Quaternion.Euler(new Vector3(0, rot.y, 0));
    }
}
