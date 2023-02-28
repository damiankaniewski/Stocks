using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

[Serializable]
public struct Stock
{
    [Header("Info")]
    public string companyName;
    public float stockPrice;
    [Space]
    [Header("Debug")]
    public float oldStockValue;
    public float stockValueChange;
}