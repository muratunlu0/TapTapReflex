using UnityEngine;
using System.Collections;

public class kayantaban12 : MonoBehaviour {

    public float hiz;
    private Vector3 startPos;
    public float smooth = 2.0F;
    public int yokolma;
    public float daralma;
    // Use this for initialization
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * hiz * Time.deltaTime);

        transform.localScale = new Vector3(daralma, 0.3441324f, 1f);
        if (Input.GetKeyDown(KeyCode.W))
            {
                hiz = 0;

          

        }


        for (var i = 0; i < Input.touchCount; ++i)
        {


            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                hiz = 0;

               


            }





        }
        
    }
    void OnCollisionEnter2D(Collision2D temas)
    {
        if (temas.gameObject.tag == "topak")
        {
            if (hiz == 0)
            {
                if (transform.position == startPos)
                {

                }
                else
                {
                    Invoke("kayaan12", yokolma);

                }
            }
        }
    }
    public void döndür()
    {
        Quaternion target = Quaternion.Euler(0, 0, -180);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, 3f);
    }
    public void kayaan12()
    {
        transform.position = startPos + new Vector3(0, 24, 0);
        startPos = startPos + new Vector3(0, 24, 0);
        GameObject.Find("top").GetComponent<topak>().a11 = 0;
    }
}
