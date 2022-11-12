using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class adsManager : MonoBehaviour, IUnityAdsListener
{
    private int reward = 10;
    string placement = "rewardedVideo";
    public GameObject warning;
    public GameObject shop;

    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize("3731371", false);  //3702567  3731371  3702567
    }

    public void adShow(string p)
    {
        Advertisement.Show(p);
    }
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (Application.internetReachability != NetworkReachability.NotReachable) 
        {
            e_information inventory = GameObject.Find("gameManager").GetComponent<e_information>();
            inventory.parasayisi += reward;
            FindObjectOfType<AudioManager>().Play("item");
        }
        else
        {
            Instantiate(warning, new Vector2(0, 0), Quaternion.identity, shop.transform);
        }
    }
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
    public void OnUnityAdsDidStart(string placementId)
    {
    }

    public void OnUnityAdsReady(string placementId)
    {
    }
    public void OnUnityAdsDidError(string message)
    {

    }

}
