using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using TMPro;

public class jsonDataController : MonoBehaviour
{
    private string city;
    private string url;
    private string regionCode;
    private string shodanApiKey= "RuXZv3lAQbt49eglVdD9XRQItQ9wRH9p";

    private string ip;
    [SerializeField] public TextMeshProUGUI myText;
    private InputField myInput;

    public void getQuery()
    {
        url = "https://api.shodan.io/shodan/host/211.23.69.235?key=" + shodanApiKey;
        StartCoroutine(makeRequest(url));
    }

    private IEnumerator makeRequest(string url)
    {
        
        UnityWebRequest request = UnityWebRequest.Get(url);
        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            var data_json = JsonConvert.DeserializeObject<jsonDataClass>(request.downloadHandler.text);
            myText.SetText(data_json.city);
            myText.SetText(request.downloadHandler.text);
        }
    }
}
