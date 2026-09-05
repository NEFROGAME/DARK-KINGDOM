using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocialMediaManager : MonoBehaviour
{
    [Header("Social Media URLs")]
    [SerializeField] private string instagramURL;
    [SerializeField] private string xURL;
    [SerializeField] private string youtubeURL;
    [SerializeField] private string facebookURL;
    [SerializeField] private string NEFROGAMEURL;

    public void OpenInstagram()
    {
        Application.OpenURL(instagramURL);
    }

    public void OpenX()
    {
        Application.OpenURL(xURL);
    }

    public void OpenYouTube()
    {
        Application.OpenURL(youtubeURL);
    }

    public void OpenFacebook()
    {
        Application.OpenURL(facebookURL);
    }

    public void OpenNEFROGAME()
    {
        Application.OpenURL(NEFROGAMEURL);
    }
}
