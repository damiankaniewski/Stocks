using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct RandomEvent
{
    [Header("Info")] public string name;
    public string text;
    public int priceChange;
    public int priceSet;
}