using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public PortalScript portal;
    public PortalScript otherPortal;
   
    void Update()
    {
      
        Vector3 position = otherPortal.transform.worldToLocalMatrix.MultiplyPoint3x4(Camera.main.transform.position);
        transform.localPosition = new Vector3(-position.x, position.y, -position.z);

        Quaternion difference = portal.transform.rotation * Quaternion.Inverse(otherPortal.transform.rotation * Quaternion.Euler(0, 180, 0));
        transform.rotation = difference * Camera.main.transform.rotation;


        Plane plane = new Plane(-portal.transform.forward, portal.transform.position);
        Vector4 clipPlaneWorldSpace = new Vector4(plane.normal.x, plane.normal.y, plane.normal.z, plane.distance);
        Vector4 clipPlaneCameraSpace = Matrix4x4.Transpose(Matrix4x4.Inverse(GetComponent<Camera>().worldToCameraMatrix)) * clipPlaneWorldSpace;
        GetComponent<Camera>().projectionMatrix = Camera.main.CalculateObliqueMatrix(clipPlaneCameraSpace);


    }
}
