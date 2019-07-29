using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RingController : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var rings = Resources.LoadAll("Prefabs/Rings");
        List<GameObject> ringsList = new List<GameObject>();
        foreach (var ring in rings) ringsList.Add(ring as GameObject);

        for (int i = 0; i < 31; i++)
        {
            GameObject ring = Instantiate(ringsList[Random.Range(0, ringsList.Count)]);
            ring.transform.parent = gameObject.transform;
            ring.transform.position = new Vector3(0, -2.38f * i, 0);
            ring.transform.eulerAngles = new Vector3(90, UnityEngine.Random.Range(0, 360), 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") != 0) transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + Input.GetAxis("Horizontal") * 7, transform.eulerAngles.z); // rotate rings on axis movement
    }
}
