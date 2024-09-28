using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicCell : MonoBehaviour
{
    public Magic magic;
    public bool selected = false;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHighLight()
    {
        GetComponentInChildren<Text>().text = selected ? "!" : magic.name;
    }
}
