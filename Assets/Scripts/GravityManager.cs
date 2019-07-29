using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -20f, 0); // INCRESE THE GRAVITY! (so the ball bounce faster)
    }
}
