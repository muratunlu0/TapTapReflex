using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class top : MonoBehaviour {

    public Material[] top_skins;
    public GameObject Puan;
    public GameObject Puan1;
    public GameObject Puan2;
    public GameObject bolumsonu_paneli;
    public GameObject control_paneli;
    public GameObject kameraleftright;
    public int puan;
    public Text puanText;
    public AudioClip[] sesdosyaları;
    public Text kacıncı_level_bitti_yazisi;
    public Text kacsaniyede_bitti_yazisi;
    public float baslangic_suresi;
    public float DURAKLATbaslangic_suresi;
    public float DURAKLATsuresi;
    public Text geçensure_yazisi;
    public Text bolumrekoru;
    public float bolumgecebilme_suresi = 100f;
    public GameObject topp;
    public GameObject NO_YET_tekrar_oyna_butonu;
    public GameObject next_butonu;
    public int topskin;
    public GameObject var_geri;
    public GameObject var_ileri;
    public int[] fiyat;
    public Text fiyati_yazisi;
    public int fiyat_sayi;
    public GameObject no_gold_paneli;
    
    public GameObject satın_al_tusu;
    public GameObject kullan_tusu;
    public GameObject satin_paneli;
    
    // Use this for initialization
    void Start () {

        if(PlayerPrefs.GetInt("gecici_amkk")==0)
        {
            PlayerPrefs.SetInt("satin_alindi0", 1);
            PlayerPrefs.SetInt("kusanildi0", 1);
                PlayerPrefs.SetInt("gecici_amkk", 1);
        }
        Time.timeScale = 1;
        puanText.text = (PlayerPrefs.GetInt("toplam_altin")).ToString();
        kameraleftright.SetActive(true);    
        puan = 0;
        if (Application.loadedLevelName != "market")
        {
            baslangic_suresi = Time.time;
        }
        
        for (int i = 0; i < 16; i++)
        {
            if (PlayerPrefs.GetInt("kusanildi" + i.ToString()) == 1)
            {
                topp.GetComponent<MeshRenderer>().material = top_skins[i];
            }


        }
        for (int i=1;i<51;i++)
        {
            if (Application.loadedLevelName == "level " + i.ToString())
            {
                bolumrekoru.text = PlayerPrefs.GetFloat("level" + i.ToString()+"rekor").ToString()+"s";
            }
            
        }
        if (Application.loadedLevelName == "market")
        {
            ileri();
            geri();
        }
       
    }
    public void ileri()
    {
        if(topskin<15)
        {
            topskin += 1;
           
            if (PlayerPrefs.GetInt("satin_alindi" + topskin.ToString()) == 0)
            {
                kullan_tusu.SetActive(false);
                satın_al_tusu.SetActive(true);
            }
            else
            {
                if (PlayerPrefs.GetInt("kusanildi" + topskin.ToString()) == 1)
                {
                    kullan_tusu.SetActive(false);
                   

                }
                else 
                {
                    kullan_tusu.SetActive(true);
                }
                satın_al_tusu.SetActive(false);
            }
            fiyat_sayi = fiyat[topskin];
            fiyati_yazisi.text = fiyat_sayi.ToString();
            topp.GetComponent<MeshRenderer>().material = top_skins[topskin];
            if (topskin < 15)
            {
                var_ileri.SetActive(true);
                var_geri.SetActive(true);
            }
            else
            {
                var_ileri.SetActive(false);
                var_geri.SetActive(true);
            }
            }
       
        
    }
    public void geri()
    {
        if (topskin >0)
        {
            topskin -= 1;
            if (PlayerPrefs.GetInt("satin_alindi" + topskin.ToString()) == 0)
            {
                kullan_tusu.SetActive(false);
                satın_al_tusu.SetActive(true);
            }
            else
            {
                if (PlayerPrefs.GetInt("kusanildi" + topskin.ToString()) == 1)
                {
                    kullan_tusu.SetActive(false);


                }
                else
                {
                    kullan_tusu.SetActive(true);
                }
                satın_al_tusu.SetActive(false);
            }
            fiyat_sayi = fiyat[topskin];

            fiyati_yazisi.text = fiyat_sayi.ToString();
            topp.GetComponent<MeshRenderer>().material = top_skins[topskin];
            if (topskin > 0)
            {
                var_ileri.SetActive(true);
                var_geri.SetActive(true);
            }
            else
            {
                var_ileri.SetActive(true);
                var_geri.SetActive(false);
            }
        }
    }
    public void kuşan()
    {
        kullan_tusu.SetActive(false);
        for (int i = 0; i < 16; i++)
        {
            if (i == topskin)
            {
                PlayerPrefs.SetInt("kusanildi" + i.ToString(), 1);
            }
            else
            {
                PlayerPrefs.SetInt("kusanildi" + i.ToString(), 0);
            }

        }
    }
    public void satin_all()
    {
        if(PlayerPrefs.GetInt("toplam_altin")>fiyat_sayi)
        {
            PlayerPrefs.SetInt("toplam_altin", PlayerPrefs.GetInt("toplam_altin") - fiyat_sayi);
            PlayerPrefs.SetInt("satin_alindi" + topskin.ToString(), 1);
            satin_paneli.SetActive(false);
            
            for (int i=0;i<16;i++)
            {
                if (i == topskin)
                {
                    PlayerPrefs.SetInt("kusanildi" + i.ToString(), 1);
                }
                else
                {
                    PlayerPrefs.SetInt("kusanildi" + i.ToString(), 0);
                }

            }
            kullan_tusu.SetActive(false);
            satın_al_tusu.SetActive(false);
        }
        else
        {
            no_gold_paneli.SetActive(true);
        }
    }
    void OnTriggerExit(Collider temas)
    {
        if (temas.gameObject.tag == "Engel")
        {

            Puan.SetActive(false);
            if (PlayerPrefs.GetInt("ses") == 1)
            {
                GetComponent<AudioSource>().PlayOneShot(sesdosyaları[0], 1);
            }
            Debug.Log("hehhe oldu la oldu :)");
           

            puancık();
        }
        if (temas.gameObject.tag == "Engel1")
        {
            Puan1.SetActive(false);
            if (PlayerPrefs.GetInt("ses") == 1)
            {
                GetComponent<AudioSource>().PlayOneShot(sesdosyaları[0], 1);
            }
            Debug.Log("hehhe oldu la oldu :)1");
           

            puancık();
        }
        if (temas.gameObject.tag == "Engel2")
        {
            Puan2.SetActive(false);
            if (PlayerPrefs.GetInt("ses") == 1)
            {
                GetComponent<AudioSource>().PlayOneShot(sesdosyaları[0], 1);
            }
            Debug.Log("hehhe oldu la oldu :)2");
            

            puancık();
        }
        if (temas.gameObject.tag == "Engelson")
        {
            Debug.Log("oldu");
            Oyunsonu();
            
        }
    }
    void Update()
    {
        if (Application.loadedLevelName != "market")
        {
            geçensure_yazisi.text = (bolumgecebilme_suresi - Math.Round((Time.time) - (DURAKLATsuresi + baslangic_suresi), 0)).ToString() + "s";
            if (bolumgecebilme_suresi < Math.Round((Time.time) - (DURAKLATsuresi + baslangic_suresi), 0))
            {
                no_yet();
            }
        }
    }
    public void no_yet()
    {
        Time.timeScale = 0;
        control_paneli.SetActive(false);
        bolumsonu_paneli.SetActive(true);
        kacsaniyede_bitti_yazisi.text = "NO FINISH: " + (Math.Round((Time.time) - (DURAKLATsuresi + baslangic_suresi), 2)).ToString() + "s";
        NO_YET_tekrar_oyna_butonu.SetActive(true);
        next_butonu.SetActive(false);
        for (int i = 1; i < 51; i++)
        {
            if (Application.loadedLevelName == "level " + i.ToString())
            {
                kacıncı_level_bitti_yazisi.text = "LEVEL " + i.ToString() + " NO PASSED";
                PlayerPrefs.SetInt("son_levelim", i);
                kacsaniyede_bitti_yazisi.color = Color.red;


            }

        }

    }
    public void Oyunsonu()
    {
        Time.timeScale = 0;
        control_paneli.SetActive(false);
        bolumsonu_paneli.SetActive(true);
        kacsaniyede_bitti_yazisi.text = "FINISH: " + (Math.Round((Time.time) - (DURAKLATsuresi + baslangic_suresi), 2)).ToString() + "s";
        NO_YET_tekrar_oyna_butonu.SetActive(false);
        next_butonu.SetActive(true);
        if (PlayerPrefs.GetInt("reklam_varmı") == 0)
        {

        }
           
        for (int i = 1; i < 51; i++)
        {
            if (Application.loadedLevelName == "level " + i.ToString())
            {
                kacıncı_level_bitti_yazisi.text = "LEVEL " + i.ToString() + " PASSED";
                PlayerPrefs.SetInt("son_levelim",i+1);
                kacsaniyede_bitti_yazisi.color = Color.yellow;
                if (Math.Round((Time.time) - (DURAKLATsuresi + baslangic_suresi), 2)> PlayerPrefs.GetFloat("level" + i.ToString() + "rekor"))
                {
                    float rekor = (float)Math.Round((Time.time) - (DURAKLATsuresi + baslangic_suresi), 2);
                    PlayerPrefs.SetFloat("level" + i.ToString() + "rekor", rekor);
                }
                bolumrekoru.text = PlayerPrefs.GetFloat("level" + i.ToString() + "rekor").ToString();
            }

        }
    }
    public void geridon()
    {
        
        Time.timeScale = 1;
        DURAKLATsuresi = Time.time - DURAKLATbaslangic_suresi;
       

    }
    public void duraklat()
    {
        Time.timeScale = 0;
        kacsaniyede_bitti_yazisi.text = "FINISH: " + ((Time.time) - (DURAKLATsuresi + baslangic_suresi)).ToString() + "s";
        DURAKLATbaslangic_suresi = Time.time;
       
    }
    public void puancık()
    {

        PlayerPrefs.SetInt("toplam_altin", PlayerPrefs.GetInt("toplam_altin") + 10);

        puanText.text = (PlayerPrefs.GetInt("toplam_altin")).ToString();
    }
   
}

