using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject ball; // link to player's ball
    private GameObject rings; // link to rings set
    private GameObject currentRing; // the ring that ball is currently bumping on
    private Transform mainCamera; // transform component of main camera
    private int childCounter = 1; // counter for getting current ring
    private bool follow = false; // should camera follow the ball
    private float offset;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("player"); // find player's ball
        rings = GameObject.FindGameObjectWithTag("rings"); // find rings set
        currentRing = rings.transform.GetChild(0).gameObject; // set first ring as current
        mainCamera = Camera.main.transform; // get main camera transform component
        offset = (mainCamera.position.y - ball.transform.position.y) * 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.y < currentRing.transform.position.y + 0.4f) // if ball is descending below current ring
        {
            ChangeFollowFlag(true); // change flag to follow ball
            if (follow) mainCamera.position = new Vector3(mainCamera.position.x, ball.transform.position.y + offset, mainCamera.position.z); // if follow is true, follow the ball :D
        }
    }

    public void ChangeFollowFlag(bool _follow) => follow = _follow; // changing follow flag status

    public void ChangeFollowFlag(Collider col) { if (col.gameObject != currentRing) follow = !follow; }

    public void NextRing(Collider ring) { if (currentRing != ring.gameObject) currentRing = ring.gameObject; } // called by Ball script when ball hit collider, change current ring to next
}
