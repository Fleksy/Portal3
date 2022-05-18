using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public PortalScript otherPortal;
    [HideInInspector]
    public  Camera camera;
    [HideInInspector]
    public GameObject wall;

    private void Awake()
    {
        camera = transform.GetChild(0).GetComponent<Camera>();
        wall = transform.GetChild(1).gameObject;
        otherPortal.camera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        GetComponent<MeshRenderer>().sharedMaterial.mainTexture = otherPortal.camera.targetTexture;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<ObjectScript>().EnterPortal(this, otherPortal, wall);
    }

    private void OnTriggerExit(Collider other)
    {
        other.GetComponent<ObjectScript>().ExitPortal(wall);
        if (transform.InverseTransformPoint(other.transform.position).z > 0)
            other.GetComponent<ObjectScript>().Warp();
    }


}
