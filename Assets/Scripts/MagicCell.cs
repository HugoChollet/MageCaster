using System;
using UnityEngine;
using UnityEngine.UI;

public class MagicCell : MonoBehaviour
{
    public Magic magic;
    public string spellName;
    public int position;
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
        GetComponentInChildren<Text>().text = selected ? spellName : position.ToString() + "  " + spellName;
    }
}
