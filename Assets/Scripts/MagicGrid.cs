using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

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
        cells[GetSelectedCell()].GetComponentInChildren<Button>().Select();
    }

    void InstantiateMagicCell(Magic magic, int posX, int index)
    {
        GameObject newMagic = Instantiate(cellGameObject, new Vector3(posX, 50, 0), Quaternion.identity, transform);

        cells[index] = newMagic;
        cells[index].GetComponent<MagicCell>().magic = magic;
        cells[index].GetComponent<MagicCell>().spellName = magic.name;
        cells[index].GetComponent<MagicCell>().position = index;
    }

    void FixedUpdate()
    {
        UpdateOnScroll();
        UpdateOnKeyDown();
    }

    void UpdateOnScroll()
    {
        int oldSelect = roundDownSelectCell;

        selectedCell += Input.mouseScrollDelta.y;
        roundDownSelectCell = Math.Abs((int)(selectedCell % cells.Length));

        if (oldSelect != roundDownSelectCell)
        {
            SetSelectedMagics(roundDownSelectCell);
        }
    }


    // Call Select on key press from 1 to 9
    private Dictionary<KeyCode, int> digitMap = new Dictionary<KeyCode, int>()
{
    {KeyCode.Keypad0, 0}, {KeyCode.Alpha0, 0},
    {KeyCode.Keypad1, 1}, {KeyCode.Alpha1, 1},
    {KeyCode.Keypad2, 2}, {KeyCode.Alpha2, 2},
    {KeyCode.Keypad3, 3}, {KeyCode.Alpha3, 3},
    {KeyCode.Keypad4, 4}, {KeyCode.Alpha4, 4},
    {KeyCode.Keypad5, 5}, {KeyCode.Alpha5, 5},
    {KeyCode.Keypad6, 6}, {KeyCode.Alpha6, 6},
    {KeyCode.Keypad7, 7}, {KeyCode.Alpha7, 7},
    {KeyCode.Keypad8, 8}, {KeyCode.Alpha8, 8},
    {KeyCode.Keypad9, 9}, {KeyCode.Alpha9, 9}
};

    void UpdateOnKeyDown()
    {
        if (Input.anyKey)
        {
            foreach (var key in digitMap)
            {
                if (Input.GetKey(key.Key))
                {
                    SetSelectedMagics(key.Value);
                    return;
                }
            }
        }
    }


    public void SetSelectedMagics(int selectedMagic)
    {
        for (int i = 0; i < cells.Length; i++)
        {
            cells[i].GetComponent<MagicCell>().selected = i == selectedMagic;
            cells[i].GetComponent<MagicCell>().UpdateHighLight();
            selectedCell = selectedMagic;
        }
    }

    public int GetSelectedCell()
    {
        return Math.Abs((int)(selectedCell % cells.Length));
    }

    public Magic GetSelectedMagic()
    {
        return magics[GetSelectedCell()].GetComponent<Magic>();
    }
}