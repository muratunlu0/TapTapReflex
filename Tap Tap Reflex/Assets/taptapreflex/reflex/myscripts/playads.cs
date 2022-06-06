using UnityEngine;
using UnityEngine.Advertisements;
using System.Collections;

public class playads : MonoBehaviour {

    public void ShowAd()
    {
        if(Advertisement.IsReady())
        {
            Advertisement.Show("rewardedVideo", new ShowOptions() { resultCallback = HandleAdResult });
        }
    } 
	// Use this for initialization
	private void HandleAdResult(ShowResult result)
    {
        switch(result)
        {
            case ShowResult.Finished:
                GameObject.Find("top").GetComponent<topak>().yıldızsayısı = GameObject.Find("top").GetComponent<topak>().yıldızsayısı+ 10;
                PlayerPrefs.SetInt("yıldızsayısı", GameObject.Find("top").GetComponent<topak>().yıldızsayısı);
                Debug.Log("Player Gains +10 gems");
                break;
            case ShowResult.Skipped:
                GameObject.Find("top").GetComponent<topak>().yıldızsayısı = GameObject.Find("top").GetComponent<topak>().yıldızsayısı + 2;
                PlayerPrefs.SetInt("yıldızsayısı", GameObject.Find("top").GetComponent<topak>().yıldızsayısı);
                Debug.Log("PLayer did not fully wath the ad");
                break;
            case ShowResult.Failed:
                Debug.Log("PLayer failed to launch the ad ? Internet?");
                break;
        }
    }
}
