using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sonucugoster :MonoBehaviour {

    public float yukarıcıkma = -72.62f;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position = new Vector3(-229.51f, yukarıcıkma, 864.6504f);

    }
}