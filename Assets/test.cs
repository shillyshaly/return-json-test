using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;

public class test : MonoBehaviour
{
    string shodanApiKey = "RuXZv3lAQbt49eglVdD9XRQItQ9wRH9p";
    [SerializeField] private TextMeshProUGUI textMesh;
    void Start()
    {
        string url = "https://api.shodan.io/shodan/host/211.23.69.235?key=" + shodanApiKey;
        StartCoroutine(Get(url)); 
    }

    private IEnumerator Get(string url)
    {
        using (UnityWebRequest unityWebRequest = UnityWebRequest.Get(url))
        {
            yield return unityWebRequest.SendWebRequest();

            if(unityWebRequest.isNetworkError || unityWebRequest.isHttpError)
            {
                Debug.Log("error: " + unityWebRequest.error);
                textMesh.SetText("error: " + unityWebRequest.error);
            }
            else
            {
                Debug.Log("recv: " + unityWebRequest.downloadHandler.text);
                textMesh.SetText(unityWebRequest.downloadHandler.text);
            }
        }
    }

    void Update()
    {
        
    }
}
