using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveScript : MonoBehaviour
{
    public float move_Speed = 5f;
    public float rotation_Speed = 0.8f;
    private Transform camera;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * move_Speed *
                                Time.fixedDeltaTime);
            transform.Rotate(0, Input.GetAxis("Mouse X") * rotation_Speed, 0);
        }
    }
}