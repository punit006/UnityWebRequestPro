using Pathfinding.Serialization.JsonFx;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonSerialization : ISerialization
{
    public string contentType => "application/json";

    public T Deserialize<T>(string data)
    {
        try
        {
            var result = JsonReader.Deserialize<T>(data);
            return result;
        }
        catch (Exception e)
        {
            return default;
        }
    }
}
