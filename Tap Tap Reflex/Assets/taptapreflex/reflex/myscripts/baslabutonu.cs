using UnityEngine;

using System.Collections.Generic;
using System;

public class baslabutonu : MonoBehaviour {
    
    public AudioClip[] sesdosyaları;

    public GameObject musiconsimgesi;
    public GameObject musicoffsimgesi;
    public int reklamsayacıı = 0;
    public int gecicireklamsayacı;

    // Use this for initialization
    void Start () {
        reklamsayacıı = PlayerPrefs.GetInt("kackereoynamıssss");
        GameObject.Find("top").GetComponent<topak>().musicon = PlayerPrefs.GetInt("müzikvarmı");

        if (GameObject.Find("top").GetComponent<topak>().musicon == 1)
        {
            musiconsimgesi.SetActive(true);
            musicoffsimgesi.SetActive(false);
            GameObject.Find("top").GetComponent<topak>().musicon = 1;
            PlayerPrefs.SetInt("müzikvarmı", GameObject.Find("top").GetComponent<topak>().musicon = 1);
        }
        else if (GameObject.Find("top").GetComponent<topak>().musicon == 0)
        {
            musiconsimgesi.SetActive(false);
            musicoffsimgesi.SetActive(true);
            GameObject.Find("top").GetComponent<topak>().musicon = 0;
            PlayerPrefs.SetInt("müzikvarmı", GameObject.Find("top").GetComponent<topak>().musicon = 0);
        }


    }
	
	// Update is called once per frame
	void Update () {
	
	}
    //void reklamcagırma()
    //{
    //    reklamsayacıı = reklamsayacıı + 1;
    //    PlayerPrefs.SetInt("kackereoynamıssss", reklamsayacıı);
    //    gecicireklamsayacı = reklamsayacıı;
    //    if (reklamsayacıı == 3)
    //    {


    //        reklamsayacıı = 0;
    //        PlayerPrefs.SetInt("kackereoynamıssss", reklamsayacıı);


    //    }


    //    if (gecicireklamsayacı == 3)
    //    {
            
    //    }
    //}
    public void basla()
    {
      //  reklamcagırma();
        //AdManager.Instance.ShowVideo();
        Application.LoadLevel("asdf");

        Time.timeScale = 1;
        

    }
    public void anabolum()
    {

        Application.LoadLevel("girismenusu");
        Time.timeScale = 1;

        

    }
    

    

    
    
    public void TUŞsesi()
    {
        GetComponent<AudioSource>().PlayOneShot(sesdosyaları[0], 1);
    }


    public void musicacık()
    {
        if (GameObject.Find("top").GetComponent<topak>().musicon == 1)
        {
            musiconsimgesi.SetActive(false);
            musicoffsimgesi.SetActive(true);
            GameObject.Find("top").GetComponent<topak>().musicon = 0;
            PlayerPrefs.SetInt("müzikvarmı", GameObject.Find("top").GetComponent<topak>().musicon = 0);
        }

        else
        {
            musiconsimgesi.SetActive(true);
            musicoffsimgesi.SetActive(false);
            GameObject.Find("top").GetComponent<topak>().musicon = 1;
            PlayerPrefs.SetInt("müzikvarmı", GameObject.Find("top").GetComponent<topak>().musicon = 1);
        }
    }


}
