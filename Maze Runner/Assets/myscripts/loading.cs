using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class loading : MonoBehaviour {
    public Text altin_miktari;
    public GameObject seskapali;
    public GameObject ses_acik;
    public Text sonlevelim;
    void Start()
    {
        if (PlayerPrefs.GetInt("geciciyaaa") == 0)
        {
            PlayerPrefs.SetInt("son_levelim",1);
            PlayerPrefs.SetInt("geciciyaaa", 1);
        }
        
        if (Application.loadedLevelName == "_MainMenu")
        {
            altin_miktari.text = PlayerPrefs.GetInt("toplam_altin").ToString();
        }
        if (PlayerPrefs.GetInt("geciciya") == 0)
        {

            PlayerPrefs.SetInt("ses",1);
            PlayerPrefs.SetInt("geciciya", 1);
        }
            if (PlayerPrefs.GetInt("ses") == 0)
        {

            if (Application.loadedLevelName == "_MainMenu")
            {
                seskapali.SetActive(true);
                ses_acik.SetActive(false);
            }
        }
        else
        {
            if (Application.loadedLevelName == "_MainMenu")
            {
                seskapali.SetActive(false);
                ses_acik.SetActive(true);
            }
        }
        if (Application.loadedLevelName == "_MainMenu")
        {
            sonlevelim.text = "LEVEL " + PlayerPrefs.GetInt("son_levelim").ToString();
            Debug.Log(PlayerPrefs.GetInt("son_levelim"));
                }
    }
    public void oyunbasla()
    {
        SceneManager.LoadSceneAsync("level "+PlayerPrefs.GetInt("son_levelim").ToString());
    }
    public void ANAMENU()
    {
        SceneManager.LoadSceneAsync("_MainMenu");
    }
    public void MARKET()
    {
        SceneManager.LoadSceneAsync("market");
    }
    public void ses()
    {
        if(PlayerPrefs.GetInt("ses")==0)
        {
            PlayerPrefs.SetInt("ses", 1);
            seskapali.SetActive(false);
            ses_acik.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("ses", 0);
            seskapali.SetActive(true);
            ses_acik.SetActive(false);
        }
    }

}
