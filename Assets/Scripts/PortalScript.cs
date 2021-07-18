using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public PortalScript otherPortal;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        otherPortal.camera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        GetComponent<MeshRenderer>().sharedMaterial.mainTexture = otherPortal.camera.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        float zPos = transform.worldToLocalMatrix.MultiplyPoint3x4(other.transform.position).z;

        if (zPos < 0)
        {
            // Position
            Vector3 localPos = transform.worldToLocalMatrix.MultiplyPoint3x4(other.transform.position);
            localPos = new Vector3(-localPos.x, localPos.y, -localPos.z);
            other.transform.position = otherPortal.transform.localToWorldMatrix.MultiplyPoint3x4(localPos);

            // Rotation
            Quaternion difference = otherPortal.transform.rotation * Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 180, 0));
            other.transform.rotation = difference * other.transform.rotation;
        }
    }

    
}
