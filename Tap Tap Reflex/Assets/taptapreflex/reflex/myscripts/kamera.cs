using UnityEngine;
using System.Collections;

public class kamera : MonoBehaviour {

   
    public Vector3 campos;
    
   
	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        campos = transform.position;



        if (GameObject.Find("top").GetComponent<topak>().toppos.y > campos.y)
        {
            transform.position = new Vector3(campos.x, GameObject.Find("top").GetComponent<topak>().toppos.y, campos.z);

            

            //  campos.y = GameObject.Find("top").GetComponent<adfgdfsagd>().toppos.y; ;
        }

       

    }
}
