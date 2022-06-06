using UnityEngine;
using System.Collections;

public class CheckUptade : MonoBehaviour {
    public string Package;
    public float AvailableVersion;


    public void CheckUptadeButton()
    {
        StartCoroutine( Control () );
    }


    IEnumerator Control()
    {
        WWW www;
        www = new WWW("https://play.google.com/store/apps/details?id=" + Package);
        yield return www;

        if(www.error !=null)
        {
            Debug.Log("internet yok");
        }
        else
        {
            string index = www.text;
           
        }

    }


	
}
