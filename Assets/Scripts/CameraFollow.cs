using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Player; 
    public Vector3 CameraOffset;
  
    public float SmoothSpeed = .125f;
    public float RotationSpeed = 5.0f;

    void Start()
    {
        CameraOffset = transform.position - Player.position; 
    }
    void LateUpdate()
    {
        transform.position = Player.position + CameraOffset;
        Quaternion CameraTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
        CameraOffset = CameraTurnAngle * CameraOffset;
        transform.LookAt(Player); 
    }

    private void CompansateForWalls()
    {

    }

}

