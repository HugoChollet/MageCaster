using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;

public class MagicGrid : MonoBehaviour
{
    public Magic[] magics;
    public GameObject cellGameObject;

    public float selectedCell = 0;
    private int roundDownSelectCell = 0;
    public int maxCells = 3;

    private int startScreenPositionX = 150;
    private int nextScreenPositionX = 90;
    private GameObject[] cells;

    void Start()
    {
        cells = new GameObject[magics.Length]; // Initialize cells as an array of GameObjects with a capacity equal to maxCells.
        for (int i = 0; i < magics.Length; i++)
        {
            InstantiateMagicCell(magics[i], startScreenPositionX, i);
            startScreenPositionX += nextScreenPositionX;
        }
        cells[roundDownSelectCell].GetComponentInChildren<Button>().Select();
    }

    void InstantiateMagicCell(Magic magic, int posX, int index)
    {
        GameObject newMagic = Instantiate(cellGameObject, new Vector3(posX, 50, 0), Quaternion.identity, transform);

        cells[index] = newMagic;
        cells[index].GetComponent<MagicCell>().magic = magic;
        cells[index].GetComponentInChildren<Text>().text = magic.name;
    }

    void FixedUpdate()
    {
        UpdateOnChangeSelect();
    }

    void UpdateOnChangeSelect()
    {
        int oldSelect = roundDownSelectCell;

        selectedCell += Input.mouseScrollDelta.y;
        roundDownSelectCell = Math.Abs((int)(selectedCell % cells.Length));

        Debug.Log(roundDownSelectCell);
        if (oldSelect != roundDownSelectCell)
        {
            SetSelectedMagics();
        }
    }


    public void SetSelectedMagics()
    {
        for (int i = 0; 0 < cells.Length; i++)
        {
            cells[i].GetComponent<MagicCell>().selected = i == roundDownSelectCell;
            cells[i].GetComponent<MagicCell>().UpdateHighLight();
        }
    }

    public Magic GetSelectedMagic()
    {
        return magics[roundDownSelectCell].GetComponent<Magic>();
    }
}