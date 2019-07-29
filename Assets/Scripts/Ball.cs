using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private CameraController cameraController; // link to main camera controller component

    // Start is called before the first frame update
    void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>(); // get CameraController component of main camera
    }

    // When ball collided (probably with ring)
    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().AddForce(0, 300f, 0); // bounce ball up
        cameraController.ChangeFollowFlag(collision.collider); // change follow falg, camera will stop following the ball
        cameraController.NextRing(collision.collider); // send collider to camera controller, so it can be checked if current ring should be changed
    }
}
