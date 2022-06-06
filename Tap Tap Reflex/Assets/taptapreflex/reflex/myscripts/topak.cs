using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using UnityEngine.SocialPlatforms;
public class topak : MonoBehaviour
{
    public Transform sightStart, sightEnd;
    public Transform sightStart1, sightEnd1;
    public Transform sightStart2, sightEnd2;

    public bool spotted = false;
    public bool spotted1 = false;
    public bool spotted2 = false;

    public AudioClip[] sesdosyaları;

    
    private Renderer _renderer;
    public Texture[] myTextures;

    public int puan =0;
    public int yıldızsayısı;    
    public int a;
    public int musicon = 1;
    public int yokoluş = 2;
    int sonuc;
    
    public int a0;
    public int a1;
    public int a2;
    public int a3;
    public int a4;
    public int a5;
    public int a6;
    public int a7;
    public int a8;
    public int a9;
    public int a10;
    public int a11;
    public int a12;
    public int a13;
    public int a14;
    public int a15;
    public int a16;
    public int a17;
    public int a18;
    public int a19;
    public int a20;

    public int aralık=0;
    public int hakan = 0;
    public int leaderboardrekor;
    public GameObject oyuniçiskor;
    public Text rekor;
    public Text puanText;   
    public Text scoreyıldızsayısı;
    public Text magazayıldızsayısı;
    public Text oynarkenyıldızsayısı;
    public Text oyunsonupuanı;
    public Text minikyazıcıklar;
    private Vector3 startPos;
    
    public Vector3 toppos;

    public GameObject başlatbutonu;
    public GameObject scoremenu;
    
    public GameObject kayan1;
    public GameObject kayan2;
    public GameObject kayan3;
    public GameObject kayan4;
    public GameObject kayan5;
    public GameObject kayan6;
    public GameObject kayan7;
    public GameObject kayan8;
    public GameObject kayan9;
    public GameObject kayan10;
    public GameObject kayan11;
    public GameObject kayan12;
    public GameObject kayan13;
    public GameObject kayan14;
    public GameObject kayan15;
    public GameObject kayan16;
    public GameObject kayan17;
    public GameObject kayan18;
    public GameObject kayan19;
    public GameObject kayan20;
    public GameObject yer;    
    public GameObject özelyazılar;
    public GameObject top;
    public GameObject yıldızsagüst;
    public GameObject anamenusolsüt;
    public GameObject anaekran;
    

    public GameObject soltop1_active;
    public GameObject soltop2_active;
    public GameObject soltop3_active;
    public GameObject soltop4_active;
    public GameObject soltop5_active;
    public GameObject soltop6_active;
    public GameObject soltop7_active;
    public GameObject soltop8_active;
    public GameObject soltop9_active;
    public GameObject soltop10_active;
    public GameObject soltop11_active;
    public GameObject soltop12_active;

    public GameObject[] particles;

    public float yukarıcıkmahızı=1.2f;
    public float daralmamiktarı;
    public float başlangıçtadaralma;
    public float kayanhız;
    public float artmamiktarı = 0.25f;
    public float ziplamaGucu;
    public int hangitoptakaldıkk=13;

    private Vector3 arapos;

    public int soltopp1 = 0;
    public int soltopp2 = 0;
    public int soltopp3 = 0;
    public int soltopp4 = 0;
    public int soltopp5 = 0;
    public int soltopp6 = 0;
    public int soltopp7 = 0;
    public int soltopp8 = 0;
    public int soltopp9 = 0;
    public int soltopp10 = 0;
    public int soltopp11 = 0;
    public int soltopp12 = 0;

    public GameObject toptik1;
    public GameObject toptik2;
    public GameObject toptik3;
    public GameObject toptik4;
    public GameObject toptik5;
    public GameObject toptik6;
    public GameObject toptik7;
    public GameObject toptik8;
    public GameObject toptik9;
    public GameObject toptik10;
    public GameObject toptik11;
    public GameObject toptik12;
    public GameObject bilgikutusu;

    public GameObject marketgöz;
    
    public GameObject ANAEKRAN;
    public GameObject MAGAZA;

    public int başlangıctopu = 0;
    public Sprite marketgo1;
    public Sprite marketgo2;
    public Sprite marketgo3;
    public Sprite marketgo4;
    public Sprite marketgo5;
    public Sprite marketgo6;
    public Sprite marketgo7;
    public Sprite marketgo8;
    public Sprite marketgo9;
    public Sprite marketgo10;
    public Sprite marketgo11;
    public Sprite marketgo12;
    public Sprite marketgo13;
    Rigidbody2D rb;
    public Color particlerandomclr;
    public int i, j = 0, k;
    public GameObject anabaslik;
    public GameObject altdortlu;

    void Start()
    {

        k = PlayerPrefs.GetInt("tekrarbasla");

        if (k == 1)
        {
            anabaslik.SetActive(false);
            altdortlu.SetActive(false);

            yıldızsagüst.SetActive(true);
            anamenusolsüt.SetActive(true);
            k = 0;
            PlayerPrefs.SetInt("tekrarbasla", k);

        }

        hakan =PlayerPrefs.GetInt("hakanus");
        Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        Color particlerandomclr = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        particles[0].SetActive(false);
        particles[1].SetActive(false);

        particles[0].GetComponent<ParticleSystem>().startColor = particlerandomclr;

        particles[1].GetComponent<ParticleSystem>().startColor = particlerandomclr;

        particles[0].SetActive(true);
        particles[1].SetActive(true);
        arapos = new Vector3(0, 6.07f, 0);

        yer.GetComponent<Renderer>().material.color = newColor;
       

        başlangıctopu = PlayerPrefs.GetInt("ilktopxxx");


        if(hakan==0)
        {
            yıldızsayısı = PlayerPrefs.GetInt("yıldızsayısı");

            yıldızsayısı = yıldızsayısı + PlayerPrefs.GetInt("Rekorrr");

            puan = 0;
            PlayerPrefs.SetInt("Rekorrr", puan);
            hakan = 1;
            PlayerPrefs.SetInt("hakanus", hakan);
        }



        _renderer = GetComponent<Renderer>();

        if (başlangıctopu == 0)
        {
            hangitoptakaldıkk = 12;
           
            başlangıctopu = 1;
            PlayerPrefs.SetInt("ilktopxxx", başlangıctopu);
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
        }
        hangitoptakaldıkk = PlayerPrefs.GetInt("hangitopxxx");

        if(hangitoptakaldıkk ==  0)
        {
            marketgöz.GetComponent<Image>().sprite = marketgo1;
        }
        if (hangitoptakaldıkk == 1)
        {
            marketgöz.GetComponent<Image>().sprite = marketgo2;
        }
        if (hangitoptakaldıkk == 2)
        {
            marketgöz.GetComponent<Image>().sprite = marketgo3;
        }
        if (hangitoptakaldıkk == 3)
        {
            marketgöz.GetComponent<Image>().sprite = marketgo4;
        }
        if (hangitoptakaldıkk == 4)
        {
            marketgöz.GetComponent<Image>().sprite = marketgo5;
        }
        if (hangitoptakaldıkk == 5)
        {
            marketgöz.GetComponent<Image>().sprite = marketgo6;
        }
        if (hangitoptakaldıkk == 6)
        {
            marketgöz.GetComponent<Image>().sprite = marketgo7;
        }
        if (hangitoptakaldıkk == 7)
        {
            marketgöz.GetComponent<Image>().sprite = marketgo8;
        }
        if (hangitoptakaldıkk == 8)
        {
            marketgöz.GetComponent<Image>().sprite = marketgo9;
        }
        if (hangitoptakaldıkk == 9)
        {
            marketgöz.GetComponent<Image>().sprite = marketgo10;
        }
        if (hangitoptakaldıkk == 10)
        {
            marketgöz.GetComponent<Image>().sprite = marketgo11;
        }
        if (hangitoptakaldıkk == 11)
        {
            marketgöz.GetComponent<Image>().sprite = marketgo12;
        }
        //if (hangitoptakaldıkk == 12)
        //{
        //    marketgöz.GetComponent<Image>().sprite = marketgo13;
        //}




        _renderer.material.mainTexture = myTextures[hangitoptakaldıkk];

        soltopp1 = PlayerPrefs.GetInt("satın1");
        soltopp2 = PlayerPrefs.GetInt("satın2");
        soltopp3 = PlayerPrefs.GetInt("satın3");
        soltopp4 = PlayerPrefs.GetInt("satın4");
        soltopp5 = PlayerPrefs.GetInt("satın5");
        soltopp6 = PlayerPrefs.GetInt("satın6");
        soltopp7 = PlayerPrefs.GetInt("satın7");
        soltopp8 = PlayerPrefs.GetInt("satın8");
        soltopp9 = PlayerPrefs.GetInt("satın9");
        soltopp10 = PlayerPrefs.GetInt("satın10");
        soltopp11 = PlayerPrefs.GetInt("satın11");
        soltopp12 = PlayerPrefs.GetInt("satın12");


        
        if (soltopp1 == 1)
        {
            soltop1_active.GetComponent<Image>().color = Color.blue;
            toptik1.SetActive(true);
        }
        if (soltopp2 == 1)
        {
            soltop2_active.GetComponent<Image>().color = Color.blue;
            toptik2.SetActive(true);
        }
        if (soltopp3 == 1)
        {
            soltop3_active.GetComponent<Image>().color = Color.blue;
            toptik3.SetActive(true);
        }
        if (soltopp4 == 1)
        {
            soltop4_active.GetComponent<Image>().color = Color.blue;
            toptik4.SetActive(true);
        }
        if (soltopp5 == 1)
        {
            soltop5_active.GetComponent<Image>().color = Color.blue;
            toptik5.SetActive(true);
        }
        if (soltopp6 == 1)
        {
            soltop6_active.GetComponent<Image>().color = Color.blue;
            toptik6.SetActive(true);
        }


        if (soltopp7 == 1)
        {
            soltop7_active.GetComponent<Image>().color = Color.blue;
            toptik7.SetActive(true);
        }
        if (soltopp8 == 1)
        {
            soltop8_active.GetComponent<Image>().color = Color.blue;
            toptik8.SetActive(true);
        }
        if (soltopp9 == 1)
        {
            soltop9_active.GetComponent<Image>().color = Color.blue;
            toptik9.SetActive(true);
        }
        if (soltopp10 == 1)
        {
            soltop10_active.GetComponent<Image>().color = Color.blue;
            toptik10.SetActive(true);
        }
        if (soltopp11 == 1)
        {
            soltop11_active.GetComponent<Image>().color = Color.blue;
            toptik11.SetActive(true);
        }
        if (soltopp12 == 1)
        {
            soltop12_active.GetComponent<Image>().color = Color.blue;
            toptik12.SetActive(true);
        }

        startPos = transform.position;

        GameObject.Find("kayan1").GetComponent<kayantaban1>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan2").GetComponent<kayantaban2>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan3").GetComponent<kayantaban3>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan4").GetComponent<kayantaban4>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan5").GetComponent<kayantaban5>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan6").GetComponent<kayantaban6>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan7").GetComponent<kayantaban7>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan8").GetComponent<kayantaban8>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan9").GetComponent<kayantaban9>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan10").GetComponent<kayantaban10>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan11").GetComponent<kayantaban11>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan12").GetComponent<kayantaban12>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan13").GetComponent<kayantaban13>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan14").GetComponent<kayantaban14>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan15").GetComponent<kayantaban15>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan16").GetComponent<kayantaban16>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan17").GetComponent<kayantaban17>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan18").GetComponent<kayantaban18>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan19").GetComponent<kayantaban19>().daralma = başlangıçtadaralma; ;
        GameObject.Find("kayan20").GetComponent<kayantaban20>().daralma = başlangıçtadaralma; ;
        
     
            
        toppos = transform.position;
        oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
        yıldızsayısı = PlayerPrefs.GetInt("yıldızsayısı");
        
        puan = 0;
        musicon =  PlayerPrefs.GetInt("müzikvarmı");
        GameObject.Find("kayan1").GetComponent<kayantaban1>().yokolma = yokoluş; ;
        GameObject.Find("kayan2").GetComponent<kayantaban2>().yokolma = yokoluş; ;
        GameObject.Find("kayan3").GetComponent<kayantaban3>().yokolma = yokoluş; ;
        GameObject.Find("kayan4").GetComponent<kayantaban4>().yokolma = yokoluş; ;
        GameObject.Find("kayan5").GetComponent<kayantaban5>().yokolma = yokoluş; ;
        GameObject.Find("kayan6").GetComponent<kayantaban6>().yokolma = yokoluş; ;
        GameObject.Find("kayan7").GetComponent<kayantaban7>().yokolma = yokoluş; ;
        GameObject.Find("kayan8").GetComponent<kayantaban8>().yokolma = yokoluş; ;
        GameObject.Find("kayan9").GetComponent<kayantaban9>().yokolma = yokoluş; ;
        GameObject.Find("kayan10").GetComponent<kayantaban10>().yokolma = yokoluş; ;
        GameObject.Find("kayan11").GetComponent<kayantaban11>().yokolma = yokoluş; ;
        GameObject.Find("kayan12").GetComponent<kayantaban12>().yokolma = yokoluş; ;
        GameObject.Find("kayan13").GetComponent<kayantaban13>().yokolma = yokoluş; ;
        GameObject.Find("kayan14").GetComponent<kayantaban14>().yokolma = yokoluş; ;
        GameObject.Find("kayan15").GetComponent<kayantaban15>().yokolma = yokoluş; ;
        GameObject.Find("kayan16").GetComponent<kayantaban16>().yokolma = yokoluş; ;
        GameObject.Find("kayan17").GetComponent<kayantaban17>().yokolma = yokoluş; ;
        GameObject.Find("kayan18").GetComponent<kayantaban18>().yokolma = yokoluş; ;
        GameObject.Find("kayan19").GetComponent<kayantaban19>().yokolma = yokoluş; ;
        GameObject.Find("kayan20").GetComponent<kayantaban20>().yokolma = yokoluş; ;

        
    }
    void Update()
    {
        Raycasting();
        
        Behaviours();
        
    }

    void Raycasting()
    {
        Debug.DrawLine(sightStart.position, sightEnd.position, Color.green);
        Debug.DrawLine(sightStart1.position, sightEnd1.position, Color.green);
        Debug.DrawLine(sightStart2.position, sightEnd2.position, Color.green);

        spotted = Physics2D.Linecast(sightStart.position, sightEnd.position, 1 << LayerMask.NameToLayer("Player"));
        spotted1 = Physics2D.Linecast(sightStart1.position, sightEnd1.position, 1 << LayerMask.NameToLayer("Player"));
        spotted2 = Physics2D.Linecast(sightStart2.position, sightEnd2.position, 1 << LayerMask.NameToLayer("Player"));

        

    }
    void Behaviours()
    {

    }

    public void sol1()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        if (soltopp1 == 0)
        {
            if (50 <= yıldızsayısı)
            {

                _renderer.material.mainTexture = myTextures[0];
                hangitoptakaldıkk = 0;
                PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
                yıldızsayısı = yıldızsayısı - 50;


                soltop1_active.GetComponent<Image>().color = Color.blue;
                toptik1.SetActive(true);

                soltopp1 = 1;
                PlayerPrefs.SetInt("satın1", soltopp1);
                marketgöz.GetComponent<Image>().sprite = marketgo1;
                puancık();
            }
        }
        else
        {
            _renderer.material.mainTexture = myTextures[0];
            hangitoptakaldıkk = 0;
            toptik1.SetActive(true);
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            soltop1_active.GetComponent<Image>().color = Color.blue;
            marketgöz.GetComponent<Image>().sprite = marketgo1;

        }
    }
    public void sol2()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        if (soltopp2 == 0)
        {
            if (100 <= yıldızsayısı)
        {
               
                _renderer.material.mainTexture = myTextures[1];
            hangitoptakaldıkk = 1;

            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
                soltop2_active.GetComponent<Image>().color = Color.blue;
                yıldızsayısı = yıldızsayısı - 100;
                toptik2.SetActive(true);
                soltopp2 = 1;
                PlayerPrefs.SetInt("satın2", soltopp2);
                marketgöz.GetComponent<Image>().sprite = marketgo2;
                puancık();
            }
        }
        else
        {
            _renderer.material.mainTexture = myTextures[1];
            hangitoptakaldıkk = 1;
            soltop2_active.GetComponent<Image>().color = Color.blue;
            toptik2.SetActive(true);
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            marketgöz.GetComponent<Image>().sprite = marketgo2;
        }
    }
    public void sol3()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        if (soltopp3 == 0)
        {
            if (150 <= yıldızsayısı)
        {
                
                _renderer.material.mainTexture = myTextures[2];
        hangitoptakaldıkk = 2;

        PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            yıldızsayısı = yıldızsayısı - 150;
                soltop3_active.GetComponent<Image>().color = Color.blue;
                toptik3.SetActive(true);
                soltopp3 = 1;
                PlayerPrefs.SetInt("satın3", soltopp3);
                marketgöz.GetComponent<Image>().sprite = marketgo3;
                puancık();
            }
        }
        else
        {
            _renderer.material.mainTexture = myTextures[2];
            hangitoptakaldıkk = 2;
            soltop3_active.GetComponent<Image>().color = Color.blue;
            toptik3.SetActive(true);
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            marketgöz.GetComponent<Image>().sprite = marketgo3;
        }
    }
    public void sol4()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        if (soltopp4 == 0)
        {
            if (200 <= yıldızsayısı)
        {
                
                _renderer.material.mainTexture = myTextures[3];
        hangitoptakaldıkk = 3;

        PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            yıldızsayısı = yıldızsayısı - 200;
                soltop4_active.GetComponent<Image>().color = Color.blue;
                toptik4.SetActive(true);
                soltopp4 = 1;
                PlayerPrefs.SetInt("satın4", soltopp4);
                marketgöz.GetComponent<Image>().sprite = marketgo4;
                puancık();
            }
        }
        else
        {
            _renderer.material.mainTexture = myTextures[3];
            hangitoptakaldıkk = 3;
            soltop4_active.GetComponent<Image>().color = Color.blue;
            toptik4.SetActive(true);
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            marketgöz.GetComponent<Image>().sprite = marketgo4;
        }
    }
    public void sol5()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        if (soltopp5 == 0)
        {
            if (250 <= yıldızsayısı)
        {
                
                _renderer.material.mainTexture = myTextures[4];
        hangitoptakaldıkk = 4;

        PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            yıldızsayısı = yıldızsayısı - 250;
                toptik5.SetActive(true);
                soltop5_active.GetComponent<Image>().color = Color.blue;
                soltopp5 = 1;
                PlayerPrefs.SetInt("satın5", soltopp5);
                marketgöz.GetComponent<Image>().sprite = marketgo5;
                puancık();
            }
        }
        else
        {
            _renderer.material.mainTexture = myTextures[4];
            hangitoptakaldıkk = 4;
            soltop5_active.GetComponent<Image>().color = Color.blue;
            toptik5.SetActive(true);
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            marketgöz.GetComponent<Image>().sprite = marketgo5;
        }
    }
    public void sol6()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        if (soltopp6 == 0)
        {
            if (300 <= yıldızsayısı)
        {
                
                _renderer.material.mainTexture = myTextures[5];
        hangitoptakaldıkk = 5;

        PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            yıldızsayısı = yıldızsayısı - 300;
                toptik6.SetActive(true);
                soltop6_active.GetComponent<Image>().color = Color.blue;
                soltopp6 = 1;
                PlayerPrefs.SetInt("satın6", soltopp6);
                marketgöz.GetComponent<Image>().sprite = marketgo6;
                puancık();
            }
        }
        else
        {
            _renderer.material.mainTexture = myTextures[5];
            hangitoptakaldıkk = 5;
            soltop6_active.GetComponent<Image>().color = Color.blue;
            toptik6.SetActive(true);
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            marketgöz.GetComponent<Image>().sprite = marketgo6;
        }
    }


    public void sag1()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        if (soltopp7 == 0)
        {
            if (50 <= yıldızsayısı)
        {
               
                _renderer.material.mainTexture = myTextures[6];
        hangitoptakaldıkk = 6;

        PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);

            yıldızsayısı = yıldızsayısı - 50;
                soltop7_active.GetComponent<Image>().color = Color.blue;
                toptik7.SetActive(true);
                soltopp7 = 1;
                PlayerPrefs.SetInt("satın7", soltopp7);
                marketgöz.GetComponent<Image>().sprite = marketgo7;
                puancık();

            }
        }
        else
        {
            _renderer.material.mainTexture = myTextures[6];
            hangitoptakaldıkk = 6;
            soltop7_active.GetComponent<Image>().color = Color.blue;
            toptik7.SetActive(true);
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            marketgöz.GetComponent<Image>().sprite = marketgo7;
        }
    }
    public void sag2()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        if (soltopp8 == 0)
        {
            if (100 <= yıldızsayısı)
        {
                
                _renderer.material.mainTexture = myTextures[7];
        hangitoptakaldıkk = 7;

        PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            yıldızsayısı = yıldızsayısı - 100;
                toptik8.SetActive(true);
                soltop8_active.GetComponent<Image>().color = Color.blue;
                soltopp8 = 1;
                PlayerPrefs.SetInt("satın8", soltopp8);
                marketgöz.GetComponent<Image>().sprite = marketgo8;
                puancık();
            }
        }
        else
        {
            _renderer.material.mainTexture = myTextures[7];
            hangitoptakaldıkk = 7;
            soltop8_active.GetComponent<Image>().color = Color.blue;
            toptik8.SetActive(true);
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            marketgöz.GetComponent<Image>().sprite = marketgo8;
        }

    }
    public void sag3()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        if (soltopp9 == 0)
        {
            if (150 <= yıldızsayısı)
        {
               
                _renderer.material.mainTexture = myTextures[8];
        hangitoptakaldıkk = 8;

        PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            yıldızsayısı = yıldızsayısı - 150;
                soltop9_active.GetComponent<Image>().color = Color.blue;
                toptik9.SetActive(true);
                soltopp9 = 1;
                PlayerPrefs.SetInt("satın9", soltopp9);
                marketgöz.GetComponent<Image>().sprite = marketgo9;
                puancık();
            }
        }
        else
        {
            _renderer.material.mainTexture = myTextures[8];
            hangitoptakaldıkk= 8;
            soltop9_active.GetComponent<Image>().color = Color.blue;
            toptik9.SetActive(true);
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            marketgöz.GetComponent<Image>().sprite = marketgo9;
        }

    }
    public void sag4()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        if (soltopp10 == 0)
        {
            if (200 <= yıldızsayısı)
        {
                
                _renderer.material.mainTexture = myTextures[9];
        hangitoptakaldıkk = 9;

        PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            yıldızsayısı = yıldızsayısı - 200;
                toptik10.SetActive(true);
                soltop10_active.GetComponent<Image>().color = Color.blue;
                soltopp10 = 1;
                PlayerPrefs.SetInt("satın10", soltopp10);
                marketgöz.GetComponent<Image>().sprite = marketgo10;
                puancık();
            }
        }
        else
        {
            _renderer.material.mainTexture = myTextures[9];
            hangitoptakaldıkk= 9;
            toptik10.SetActive(true);
            soltop10_active.GetComponent<Image>().color = Color.blue;
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            marketgöz.GetComponent<Image>().sprite = marketgo10;
        }
    }
    public void sag5()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        if (soltopp11 == 0)
        {
            if (250 <= yıldızsayısı)
        {
               
                _renderer.material.mainTexture = myTextures[10];
        hangitoptakaldıkk = 10;
                soltop11_active.GetComponent<Image>().color = Color.blue;

                PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            yıldızsayısı = yıldızsayısı - 250;
                toptik11.SetActive(true);
                soltopp11 = 1;
                PlayerPrefs.SetInt("satın11", soltopp11);
                marketgöz.GetComponent<Image>().sprite = marketgo11;
                puancık();
            }
        }
        else
        {
            _renderer.material.mainTexture = myTextures[10];
            hangitoptakaldıkk = 10;
            toptik11.SetActive(true);
            soltop11_active.GetComponent<Image>().color = Color.blue;
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            marketgöz.GetComponent<Image>().sprite = marketgo11;
        }
    }
    public void sag6()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        if (soltopp12 == 0)
        {
            if (300 <= yıldızsayısı)
        {
                
                _renderer.material.mainTexture = myTextures[11];
        hangitoptakaldıkk = 11;

        PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            yıldızsayısı = yıldızsayısı - 300;
                toptik12.SetActive(true);
                soltop12_active.GetComponent<Image>().color = Color.blue;
                soltopp12 = 1;
                PlayerPrefs.SetInt("satın12", soltopp12);
                marketgöz.GetComponent<Image>().sprite = marketgo12;
                puancık();
            }
        }
        else
        {
            _renderer.material.mainTexture = myTextures[11];
            hangitoptakaldıkk = 11;
            soltop12_active.GetComponent<Image>().color = Color.blue;
            toptik12.SetActive(true);
            PlayerPrefs.SetInt("hangitopxxx", hangitoptakaldıkk);
            marketgöz.GetComponent<Image>().sprite = marketgo12;
        }
    }

    
    void FixedUpdate()
    {
        particlerandomclr = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
        for (j = 0; j < 7; j = j + 2)
        {
            if (transform.position.y > particles[j].transform.position.y + arapos.y)
            {
                particles[j].SetActive(false);
                particles[j + 1].SetActive(false);
                particles[j].transform.position = particles[j].transform.position + new Vector3(0, 24.28f, 0);
                particles[j + 1].transform.position = particles[j + 1].transform.position + new Vector3(0, 24.28f, 0);
                particles[j].GetComponent<ParticleSystem>().startColor = particlerandomclr;
                particles[j + 1].GetComponent<ParticleSystem>().startColor = particlerandomclr;
                //  particles[j].GetComponent<ParticleSystem>().startColor = particlerandomclr;
                // particles[j+1].GetComponent<ParticleSystem>().startColor = particlerandomclr;
                particles[j].SetActive(true);
                particles[j + 1].SetActive(true);


            }

        }


        toppos = transform.position;

        
    }  
    
    void OnCollisionEnter2D(Collision2D temas)
    {


        if (temas.gameObject.tag == "sonucsensoru")
        {
            
            
            puancık();
            
            scoremenu.SetActive(true);
            
            

            if (musicon==1)
            {
                GetComponent<AudioSource>().PlayOneShot(sesdosyaları[0], 1);
            }

            
        }
        if (temas.gameObject.tag == "kayan")
        {
            if (a == 0)
            {
                puan = 0;
                a = 1;

               
            }
            else
            {
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[0], 1);
                }          
                puancık();
                scoremenu.SetActive(true);
                
            }
        }


        if (temas.gameObject.tag == "kayan1")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                 GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                Debug.Log("mallllll");
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }

            }
            if (aralık == 1)
            {
                GameObject.Find("kayan3").GetComponent<kayantaban3>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız= Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan2").GetComponent<kayantaban2>().hiz = -kayanhız; ;

            
           

           


            GameObject kayan2 = GameObject.Find("kayan2");
                kayantaban2 kayann2 = kayan2.GetComponent<kayantaban2>();
                kayann2.hiz = -kayanhız;
                          
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                puancık();
            
                                            
        }
        if (temas.gameObject.tag == "kayan2")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan4").GetComponent<kayantaban4>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan3").GetComponent<kayantaban3>().hiz = kayanhız; ;
            yer.SetActive(false);
            GameObject kayan3 = GameObject.Find("kayan3");
                kayantaban3 kayann3 = kayan3.GetComponent<kayantaban3>();
                kayann3.hiz = kayanhız;
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();              
                Invoke("kayaan2", 5f);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
            
        }
        if (temas.gameObject.tag == "kayan3")
        {

            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan5").GetComponent<kayantaban5>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan4").GetComponent<kayantaban4>().hiz = -kayanhız; ;
                GameObject kayan4 = GameObject.Find("kayan4");
                kayantaban4 kayann4 = kayan4.GetComponent<kayantaban4>();
                kayann4.hiz = -kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();
            Invoke("kayaan3", 5f);  
            
                        
        }
        if (temas.gameObject.tag == "kayan4")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan6").GetComponent<kayantaban6>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan5").GetComponent<kayantaban5>().hiz = kayanhız; ;
                GameObject kayan5 = GameObject.Find("kayan5");
                kayantaban5 kayann5 = kayan5.GetComponent<kayantaban5>();
                kayann5.hiz = kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();
            
            Invoke("kayaan4", 5f);                    
        }
        if (temas.gameObject.tag == "kayan5")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan7").GetComponent<kayantaban7>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan6").GetComponent<kayantaban6>().hiz = kayanhız; ;
                GameObject kayan6 = GameObject.Find("kayan6");
                kayantaban6 kayann6 = kayan6.GetComponent<kayantaban6>();
                kayann6.hiz = kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
            renkdegistirme();

            puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();               
                Invoke("kayaan5", 5f);                    
        }
        if (temas.gameObject.tag == "kayan6")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan8").GetComponent<kayantaban8>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan7").GetComponent<kayantaban7>().hiz = -kayanhız; ;
                GameObject kayan7 = GameObject.Find("kayan7");
                kayantaban7 kayann7 = kayan7.GetComponent<kayantaban7>();
                kayann7.hiz = -kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();
            
            Invoke("kayaan6", 5f);                   
        }
        if (temas.gameObject.tag == "kayan7")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan9").GetComponent<kayantaban9>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan8").GetComponent<kayantaban8>().hiz = -kayanhız; ;
                GameObject kayan8 = GameObject.Find("kayan8");
                kayantaban8 kayann8 = kayan8.GetComponent<kayantaban8>();
                kayann8.hiz = -kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
           
            puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();            
                Invoke("kayaan7", 5f);                     
        }
        if (temas.gameObject.tag == "kayan8")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan10").GetComponent<kayantaban10>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan9").GetComponent<kayantaban9>().hiz = kayanhız; ;
                GameObject kayan9 = GameObject.Find("kayan9");
                kayantaban9 kayann9 = kayan9.GetComponent<kayantaban9>();
                kayann9.hiz = kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
            
            puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();              
                Invoke("kayaan8", 5f);                     
        }
        if (temas.gameObject.tag == "kayan9")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan11").GetComponent<kayantaban11>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan10").GetComponent<kayantaban10>().hiz = kayanhız; ;
                GameObject kayan10 = GameObject.Find("kayan10");
                kayantaban10 kayann10 = kayan10.GetComponent<kayantaban10>();
                kayann10.hiz = kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
            
            oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();          
                Invoke("kayaan9", 5f);                     
        }
        if (temas.gameObject.tag == "kayan10")
        {
           
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan12").GetComponent<kayantaban12>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan11").GetComponent<kayantaban11>().hiz = kayanhız; ;
                GameObject kayan11 = GameObject.Find("kayan11");
                kayantaban11 kayann11 = kayan11.GetComponent<kayantaban11>();
                kayann11.hiz = kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
            
            puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();
            renkdegistirme();


            Invoke("kayaan10", 5f);                     
        }
        if (temas.gameObject.tag == "kayan11")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan13").GetComponent<kayantaban13>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan12").GetComponent<kayantaban12>().hiz = -kayanhız; ;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                GameObject kayan12 = GameObject.Find("kayan12");
                kayantaban12 kayann12 = kayan12.GetComponent<kayantaban12>();
                kayann12.hiz = -kayanhız;
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
            
            puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();          
                Invoke("kayaan11", 5f);                    
        }
        if (temas.gameObject.tag == "kayan12")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan14").GetComponent<kayantaban14>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan13").GetComponent<kayantaban13>().hiz = kayanhız; ;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject kayan13 = GameObject.Find("kayan13");
                kayantaban13 kayann13 = kayan13.GetComponent<kayantaban13>();
                kayann13.hiz = kayanhız;
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
            
            puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();              
                Invoke("kayaan12", 5f);                   
        }
        if (temas.gameObject.tag == "kayan13")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan15").GetComponent<kayantaban15>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }

            GameObject.Find("kayan14").GetComponent<kayantaban14>().hiz = -kayanhız; ;
                GameObject kayan14 = GameObject.Find("kayan14");
                kayantaban14 kayann14 = kayan14.GetComponent<kayantaban14>();
                kayann14.hiz = -kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
            
            puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();             
                Invoke("kayaan13", 5f);                   
        }
        if (temas.gameObject.tag == "kayan14")
        {
           
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan16").GetComponent<kayantaban16>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan15").GetComponent<kayantaban15>().hiz = kayanhız; ;
                GameObject kayan15 = GameObject.Find("kayan15");
                kayantaban15 kayann15 = kayan15.GetComponent<kayantaban15>();
                kayann15.hiz = kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
            
            puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();           
                Invoke("kayaan14", 5f);                  
        }
        if (temas.gameObject.tag == "kayan15")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan17").GetComponent<kayantaban17>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan16").GetComponent<kayantaban16>().hiz = kayanhız; ;
                GameObject kayan16 = GameObject.Find("kayan16");
                kayantaban16 kayann16 = kayan16.GetComponent<kayantaban16>();
                kayann16.hiz = kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
            renkdegistirme();

            puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();           
                Invoke("kayaan15", 5f);                   
        }
        if (temas.gameObject.tag == "kayan16")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan18").GetComponent<kayantaban18>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan17").GetComponent<kayantaban17>().hiz = -kayanhız; ;
                GameObject kayan17 = GameObject.Find("kayan17");
                kayantaban17 kayann17 = kayan17.GetComponent<kayantaban17>();
                kayann17.hiz = -kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();
            
            Invoke("kayaan16", 5f);                                
        }
        if (temas.gameObject.tag == "kayan17")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan19").GetComponent<kayantaban19>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan18").GetComponent<kayantaban18>().hiz = -kayanhız; ;
                GameObject kayan18 = GameObject.Find("kayan18");
                kayantaban18 kayann18 = kayan18.GetComponent<kayantaban18>();
                kayann18.hiz = -kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
           
            puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();            
                Invoke("kayaan17", 5f);                   
        }
        if (temas.gameObject.tag == "kayan18")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan20").GetComponent<kayantaban20>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan19").GetComponent<kayantaban19>().hiz = kayanhız; ;
                GameObject kayan19 = GameObject.Find("kayan19");
                kayantaban19 kayann19 = kayan19.GetComponent<kayantaban19>();
                kayann19.hiz = kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
           
            puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();         
                Invoke("kayaan18", 5f);        
        }
        if (temas.gameObject.tag == "kayan19")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan1").GetComponent<kayantaban1>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan20").GetComponent<kayantaban20>().hiz = kayanhız; ;
                GameObject kayan20 = GameObject.Find("kayan20");
                kayantaban20 kayann20 = kayan20.GetComponent<kayantaban20>();
                kayann20.hiz = kayanhız;
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
            
            puan = puan + 1;
                kayanhız = kayanhız + artmamiktarı;
                puancık();            
                Invoke("kayaan19", 5f);                    
        }
        if (temas.gameObject.tag == "kayan20")
        {
            
            if (spotted == true || spotted1 == true || spotted2 == true)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
                if (musicon == 1)
                {
                    GetComponent<AudioSource>().PlayOneShot(sesdosyaları[1], 1);
                }
            }
            if (aralık == 1)
            {
                GameObject.Find("kayan2").GetComponent<kayantaban2>().daralma = Random.Range(0.16f, 0.26f);
                kayanhız = Random.Range(5.8f, 7f);
            }
            GameObject.Find("kayan1").GetComponent<kayantaban1>().hiz = kayanhız; ;
                GameObject kayan1 = GameObject.Find("kayan1");
                kayantaban1 kayann1 = kayan1.GetComponent<kayantaban1>();
                kayann1.hiz = kayanhız;
                GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma = GameObject.Find("sonucsensor").GetComponent<finish>().yukarıcıkma + yukarıcıkmahızı;
                Invoke("daralmaşeysi", 0.01f);
                PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
                puan = puan + 1;
                oynarkenyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
                puancık();
            renkdegistirme();


            Invoke("kayaan20", 5f);                     
        }



    }
    public void puancık()
    {

        if (puan > PlayerPrefs.GetInt("Rekorrr"))

        {
            PlayerPrefs.SetInt("Rekorrr", puan);
        }

        PlayerPrefs.SetInt("yıldızsayısı", yıldızsayısı);
        puanText.text = (puan).ToString();
        rekor.text = PlayerPrefs.GetInt("Rekorrr").ToString();
        
        scorekaydetamk();
        oyunsonupuanı.text = (puan).ToString();
        scoreyıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
        magazayıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
    }
    public void scorekaydetamk()
    {
        Social.ReportScore(15, "CgkI6dTVk7sIEAIQCw", (bool success) => {
            // handle success or failure
        });
    }
    public void startts()
    {
        
        anaekran.SetActive(false);
        yıldızsagüst.SetActive(true);
        anamenusolsüt.SetActive(true);
        oyuniçiskor.SetActive(true);
        özelyazılar.SetActive(false);
        başlatbutonu.SetActive(false);    
        GameObject kayan1 = GameObject.Find("kayan1");
        kayantaban1 kayann1 = kayan1.GetComponent<kayantaban1>();
        kayann1.hiz = kayanhız;
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * ziplamaGucu);
        GameObject.Find("kayan1").GetComponent<kayantaban1>().hiz = kayanhız; ;      
    }

    void daralmaşeysi()
    {
        if (aralık == 0)
        {


            if (GameObject.Find("kayan1").GetComponent<kayantaban1>().daralma >= 0.18f)
            {
                GameObject.Find("kayan1").GetComponent<kayantaban1>().daralma = GameObject.Find("kayan1").GetComponent<kayantaban1>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan2").GetComponent<kayantaban2>().daralma = GameObject.Find("kayan2").GetComponent<kayantaban2>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan3").GetComponent<kayantaban3>().daralma = GameObject.Find("kayan3").GetComponent<kayantaban3>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan4").GetComponent<kayantaban4>().daralma = GameObject.Find("kayan4").GetComponent<kayantaban4>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan5").GetComponent<kayantaban5>().daralma = GameObject.Find("kayan5").GetComponent<kayantaban5>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan6").GetComponent<kayantaban6>().daralma = GameObject.Find("kayan6").GetComponent<kayantaban6>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan7").GetComponent<kayantaban7>().daralma = GameObject.Find("kayan7").GetComponent<kayantaban7>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan8").GetComponent<kayantaban8>().daralma = GameObject.Find("kayan8").GetComponent<kayantaban8>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan9").GetComponent<kayantaban9>().daralma = GameObject.Find("kayan9").GetComponent<kayantaban9>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan10").GetComponent<kayantaban10>().daralma = GameObject.Find("kayan10").GetComponent<kayantaban10>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan11").GetComponent<kayantaban11>().daralma = GameObject.Find("kayan11").GetComponent<kayantaban11>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan12").GetComponent<kayantaban12>().daralma = GameObject.Find("kayan12").GetComponent<kayantaban12>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan13").GetComponent<kayantaban13>().daralma = GameObject.Find("kayan13").GetComponent<kayantaban13>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan14").GetComponent<kayantaban14>().daralma = GameObject.Find("kayan14").GetComponent<kayantaban14>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan15").GetComponent<kayantaban15>().daralma = GameObject.Find("kayan15").GetComponent<kayantaban15>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan16").GetComponent<kayantaban16>().daralma = GameObject.Find("kayan16").GetComponent<kayantaban16>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan17").GetComponent<kayantaban17>().daralma = GameObject.Find("kayan17").GetComponent<kayantaban17>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan18").GetComponent<kayantaban18>().daralma = GameObject.Find("kayan18").GetComponent<kayantaban18>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan19").GetComponent<kayantaban19>().daralma = GameObject.Find("kayan19").GetComponent<kayantaban19>().daralma - daralmamiktarı; ;
                GameObject.Find("kayan20").GetComponent<kayantaban20>().daralma = GameObject.Find("kayan20").GetComponent<kayantaban20>().daralma - daralmamiktarı; ;
            }
            else
            {
                aralık = 1;
            }
        }
        else
        {
            
            GameObject.Find("kayan2").GetComponent<kayantaban2>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan3").GetComponent<kayantaban3>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan4").GetComponent<kayantaban4>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan5").GetComponent<kayantaban5>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan6").GetComponent<kayantaban6>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan7").GetComponent<kayantaban7>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan8").GetComponent<kayantaban8>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan9").GetComponent<kayantaban9>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan10").GetComponent<kayantaban10>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan11").GetComponent<kayantaban11>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan12").GetComponent<kayantaban12>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan13").GetComponent<kayantaban13>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan14").GetComponent<kayantaban14>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan15").GetComponent<kayantaban15>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan16").GetComponent<kayantaban16>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan17").GetComponent<kayantaban17>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan18").GetComponent<kayantaban18>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan19").GetComponent<kayantaban19>().daralma = Random.Range(0.18f, 0.31f);
            GameObject.Find("kayan20").GetComponent<kayantaban20>().daralma = Random.Range(0.18f, 0.31f);
        }
    } 
    void renkdegistirme()
    {
        Color newColor = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);

        // apply it on current object's material

        kayan1.GetComponent<Renderer>().material.color = newColor;
        kayan2.GetComponent<Renderer>().material.color = newColor;
        kayan3.GetComponent<Renderer>().material.color = newColor;
        kayan4.GetComponent<Renderer>().material.color = newColor;
        kayan5.GetComponent<Renderer>().material.color = newColor;
        kayan6.GetComponent<Renderer>().material.color = newColor;
        kayan7.GetComponent<Renderer>().material.color = newColor;
        kayan8.GetComponent<Renderer>().material.color = newColor;
        kayan9.GetComponent<Renderer>().material.color = newColor;
        kayan10.GetComponent<Renderer>().material.color = newColor;
        kayan11.GetComponent<Renderer>().material.color = newColor;
        kayan12.GetComponent<Renderer>().material.color = newColor;
        kayan13.GetComponent<Renderer>().material.color = newColor;
        kayan14.GetComponent<Renderer>().material.color = newColor;
        kayan15.GetComponent<Renderer>().material.color = newColor;
        kayan16.GetComponent<Renderer>().material.color = newColor;
        kayan17.GetComponent<Renderer>().material.color = newColor;
        kayan18.GetComponent<Renderer>().material.color = newColor;
        kayan19.GetComponent<Renderer>().material.color = newColor;
        kayan20.GetComponent<Renderer>().material.color = newColor;
    }
    public void magazaekranınageçiş()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        ANAEKRAN.SetActive(false);
        MAGAZA.SetActive(true);
        magazayıldızsayısı.text = PlayerPrefs.GetInt("yıldızsayısı").ToString();
        

    }
    public void anaekranadonus()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        MAGAZA.SetActive(false);
        ANAEKRAN.SetActive(true);
    }
    public void bilgikutusula()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        bilgikutusu.SetActive(true);
    }

    public void kapabilgiyi()
    {
        if (musicon == 1)
        {
            GetComponent<AudioSource>().PlayOneShot(sesdosyaları[2], 1);
        }
        bilgikutusu.SetActive(false);
    }
    public void duplicatebasla()
    {
        k = 1;
        PlayerPrefs.SetInt("tekrarbasla", k);
    }
}