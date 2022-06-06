using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using System;
using UnityEngine.UI;
public class Purchaser : MonoBehaviour,IStoreListener {

    IStoreController controller;
    string[] Products = new string[] {"remove_ads","1000_gold","5000_gold", "10000gold"};
    public GameObject altin_1000_eklendi;
    public GameObject altin_5000_eklendi;
    public Text altin_miktari;

    void Start()
    {
        var module = StandardPurchasingModule.Instance();
        ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);
        foreach(string s in Products)
        {
            if (s.Contains("ads"))
            {
                builder.AddProduct(s, ProductType.NonConsumable);
            }
            else
            {
                builder.AddProduct(s, ProductType.Consumable);
            }
            builder.AddProduct(s,ProductType.Consumable);
        }
        UnityPurchasing.Initialize(this,builder);

        if(PlayerPrefs.GetInt("reklam_varmı")==1)
        {
           // reklamları_kaldır_butonu.interactable = false;
            
        }
    }
    public void BuyProduct(string ProductId)
    {
        if (ProductId.Contains("ads"))
        {
            Product product0 = controller.products.WithID(ProductId);
            if(product0.hasReceipt)
            {
                PlayerPrefs.SetInt("remove_ads", 1);                
                //reklamları_kaldır_butonu.interactable = false;
                PlayerPrefs.SetInt("reklam_varmı",1);
            }
            else
            {
                buyProduct(ProductId);
            }
        }
        else
        {
            buyProduct(ProductId);
        }
        
    }
    void buyProduct(string ProductId)
    {
        Product product = controller.products.WithID(ProductId);

        if(product!= null && product.availableToPurchase)
        {
            Debug.Log("Ürün satın alınıyor...");
            controller.InitiatePurchase(product);
        }
        else
        {
            Debug.Log("Ürün bulunamadı ya da satın alınabilir değil");
        }
    }
    public void OnInitialized(IStoreController controller,IExtensionProvider provider)
    {
        this.controller = controller;
        Product product0 = controller.products.WithID("remove_ads");
        
        if (product0.hasReceipt)
        {
            PlayerPrefs.SetInt("remove_ads", 1);
        }
        else
        {
            PlayerPrefs.SetInt("remove_ads", 0);
        }
        Debug.Log("Sistem Hazır.");
    }
    public void OnInitializeFailed(InitializationFailureReason reason)
    {
        Debug.Log("Yükleme Hatası: "+reason.ToString());
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
              
        if (string.Equals(args.purchasedProduct.definition.id, Products[0], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("remove_ads", 1);

          //  reklamlar_kaldırıldı.SetActive(true);
        }
       
        if (string.Equals(args.purchasedProduct.definition.id, Products[1], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("toplam_altin", PlayerPrefs.GetInt("toplam_altin") + 1000);
            altin_1000_eklendi.SetActive(true);
            altin_miktari.text = PlayerPrefs.GetInt("toplam_altin").ToString();
        }
        if (string.Equals(args.purchasedProduct.definition.id, Products[2], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("toplam_altin", PlayerPrefs.GetInt("toplam_altin") + 5000);
            altin_5000_eklendi.SetActive(true);
            altin_miktari.text = PlayerPrefs.GetInt("toplam_altin").ToString();
        }
        if (string.Equals(args.purchasedProduct.definition.id, Products[3], StringComparison.Ordinal))
        {
            PlayerPrefs.SetInt("toplam_altin", PlayerPrefs.GetInt("toplam_altin") + 10000);
            altin_5000_eklendi.SetActive(true);
            altin_miktari.text = PlayerPrefs.GetInt("toplam_altin").ToString();
        }
        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product,PurchaseFailureReason reason)
    {
        Debug.Log("Bu ürün satın alınamadı: "+product.ToString());
    }

}
