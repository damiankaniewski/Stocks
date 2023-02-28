using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DateTime : MonoBehaviour
{
    private TextMeshProUGUI currentDateTime;

    private void Start()
    {
        currentDateTime = GetComponent<TextMeshProUGUI>();
    }

    
    void Update()
    {
        currentDateTime.SetText(System.DateTime.Now.ToString("hh:mm:ss"));
    }
}