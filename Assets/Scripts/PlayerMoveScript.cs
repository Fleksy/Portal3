using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float move_Speed = 5f;
    public float rotation_Speed = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    void FixedUpdate()
    {
    
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * move_Speed * Time.fixedDeltaTime);

        transform.Rotate(0, Input.GetAxis("Mouse X") * rotation_Speed,0);
        transform.GetChild(0).Rotate(-Input.GetAxis("Mouse Y") * rotation_Speed, 0, 0);
        /*if (transform.GetChild(0).localRotation.eulerAngles.y != 0)
        {
            transform.GetChild(0).Rotate(Input.GetAxis("Mouse Y") * rotation_Speed, 0, 0);
        }*/

        if (transform.rotation.x !=0 )
        {
            transform.eulerAngles = new Vector3(0, transform.rotation.y, 0);
        }
        
    }
}
