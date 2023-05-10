using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePointer : MonoBehaviour
{
    [SerializeField] GameObject markerPrefab;
    public int lastMarker;

    public int jumpCount = 0;
    void Start()
    {
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // input mouse down
        if (markerPrefab != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                jumpCount += 1;
                Instantiate(markerPrefab, transform.position, Quaternion.identity);
            }
        }
    }
}
