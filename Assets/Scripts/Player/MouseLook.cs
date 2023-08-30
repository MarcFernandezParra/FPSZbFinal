using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseLook : MonoBehaviour
{
    public float lookSensitivity = 1f, lookSmoothDamp =.0f;

    [HideInInspector]
    public float yRot , xRot;
    [HideInInspector]
    public float currentY , currentX;
    [HideInInspector]
    public float yRotationV , xRotationV;
    
    void LateUpdate()
    {
        yRot += Input.GetAxis("Mouse X") * lookSensitivity;
        xRot += Input.GetAxis("Mouse Y") * lookSensitivity;
    
        currentX = Mathf.SmoothDamp(currentX, xRot, ref xRotationV, lookSmoothDamp);
        currentY = Mathf.SmoothDamp(currentY, yRot, ref yRotationV, lookSmoothDamp);

        xRot = Mathf.Clamp(xRot, -80, 80);

        transform.rotation = Quaternion.Euler(-currentX, currentY, 0);       
    
    }
}
