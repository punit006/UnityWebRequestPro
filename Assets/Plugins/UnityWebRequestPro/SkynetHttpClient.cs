using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;


public class SkynetHttpClient 
{
    public readonly ISerialization _serialization;

    public SkynetHttpClient(ISerialization serialization)
    {
        _serialization = serialization;
    }


    public async Task<T> Get<T>(string url)
    {        
        UnityWebRequest www = UnityWebRequest.Get(url);
        www.SetRequestHeader("Content-Type", _serialization.contentType);
        var operation = www.SendWebRequest();

        while (!operation.isDone)
            await Task.Yield();

        
        if (www.error == null)
        {
            Debug.Log($"failed: {www.error}");
        }

        try
        {
            var result = _serialization.Deserialize<T>(www.downloadHandler.text);
            return result;

        }
        catch (Exception e)
        {
            Debug.LogError("Unable to parse");
            return default;
        }
    }
}