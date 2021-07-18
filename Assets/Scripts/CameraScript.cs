using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public PortalScript portal;
    public PortalScript otherPortal;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookerPosition = otherPortal.transform.worldToLocalMatrix.MultiplyPoint3x4(Camera.main.transform.position);
        lookerPosition = new Vector3(-lookerPosition.x, lookerPosition.y, -lookerPosition.z);

        transform.localPosition = lookerPosition;

        Quaternion difference = portal.transform.rotation * Quaternion.Inverse(otherPortal.transform.rotation * Quaternion.Euler(0, 180, 0));
        transform.rotation = difference * Camera.main.transform.rotation;

        //gameObject.GetComponent<Camera>().nearClipPlane   = lookerPosition.magnitude +1 ;

        //Plane p = new Plane(-otherPortal.transform.forward, otherPortal.transform.position);
        //Vector4 clipPlane = new Vector4(p.normal.x, p.normal.y, p.normal.z, p.distance);
        //Vector4 clipPlaneCameraSpace = Matrix4x4.Transpose(
        //                                   Matrix4x4.Inverse(GetComponent<Camera>().worldToCameraMatrix)) * clipPlane;
        //var newMatrix = Camera.main.CalculateObliqueMatrix(clipPlaneCameraSpace);
        //GetComponent<Camera>().projectionMatrix = newMatrix;

    }
}
