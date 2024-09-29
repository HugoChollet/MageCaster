using UnityEngine;
using UnityEngine.UI;

public class MagicCell : MonoBehaviour
{
    public Magic magic;
    public string spellName;
    public int position;
    public bool selected = false;

    public Sprite hoverSprite;
    public Sprite idleSprite;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHighLight()
    {
        if (selected)
        {
            GetComponentInChildren<Image>().sprite = hoverSprite;
            GetComponentInChildren<Text>().text = spellName;
        }
        else
        {
            GetComponentInChildren<Image>().sprite = idleSprite;
            GetComponentInChildren<Text>().text = position.ToString() + "  " + spellName;
        }
    }
}
