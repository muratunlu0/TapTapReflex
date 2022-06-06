using UnityEngine;
using System.Collections;

public class yıldız : MonoBehaviour
{
    
    public GameObject yıldızz;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {




    }
    void OnTriggerExit2D(Collider2D temas)
    {
        if (temas.gameObject.tag == "topak")
        {
            yıldızz.SetActive(false);

            GameObject.Find("top").GetComponent<topak>().yıldızsayısı = GameObject.Find("top").GetComponent<topak>().yıldızsayısı +1;
            Debug.Log(GameObject.Find("top").GetComponent<topak>().yıldızsayısı);
        }
    }
}
