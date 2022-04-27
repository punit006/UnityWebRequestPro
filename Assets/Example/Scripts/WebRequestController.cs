using Pathfinding.Serialization.JsonFx;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static Model;

public class WebRequestController : MonoBehaviour
{
    [ContextMenu("Test Get")]
    public async Task Get()
    {
        var skynetHttpClient = new SkynetHttpClient(new JsonSerialization());
        var result = await skynetHttpClient.Get<User>("http://jsonplaceholder.typicode.com/todos/1");
        Debug.Log($"UserId: {result.userId}");
    }
}
