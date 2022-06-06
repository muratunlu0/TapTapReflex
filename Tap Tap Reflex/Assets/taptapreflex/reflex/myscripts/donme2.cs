using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donme2 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
     //   transform.Rotate(0,90 * Time.deltaTime, 0);
        transform.localScale = new Vector3(Mathf.PingPong(Time.time,1.30f), Mathf.PingPong(Time.time, 1.30f)-0.21156f, Mathf.PingPong(Time.time, 1.30f));


    }
}
