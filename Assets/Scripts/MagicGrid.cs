using UnityEngine;

public class MagicGrid : MonoBehaviour
{
    public Cast[] magics;
    public GameObject cell;

    public int selectedCell = 1;
    public int maxCells = 3;

    private int startPositionX = 150;
    private int nextPositionX = 90;

    void Start()
    {
        foreach (Cast magic in magics)
        {
            InstantiateMagicCell(magic, startPositionX);
            startPositionX += nextPositionX;
        }
    }

    void InstantiateMagicCell(Cast magic, int posX)
    {
        GameObject newMagic = Instantiate(cell, new Vector3(posX, 50, 0), Quaternion.identity, transform);
        newMagic.GetComponent<MagicCell>().cast = magic;
    }
}