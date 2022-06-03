using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Ad.Example;

public class reklamgoster : MonoBehaviour
{
    private InterstitialAdExample _ad;
    

    private void Awake()
    {
        _ad = new InterstitialAdExample();
    }
    
    private void Start()
    {
        _ad.InitServices();
        _ad.SetupAd();

    }
    
    public void MyFunction()
    {
        _ad.ShowAd();
    }
}
