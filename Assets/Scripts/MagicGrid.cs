using UnityEngine;

public class MagicGrid : MonoBehaviour
{
    public Cast[] magics;
    public GameObject cellGameObject;

    public int selectedCell = 1;
    public int maxCells = 3;

    private int startPositionX = 150;
    private int nextPositionX = 90;
    private GameObject[] cells;

    void Start()
    {
        cells = new GameObject[maxCells]; // Initialize cells as an array of GameObjects with a capacity equal to maxCells.
        for (int i = 0; i < magics.Length; i++)
        {
            InstantiateMagicCell(magics[i], startPositionX, i);
            startPositionX += nextPositionX;
        }

    }

    void InstantiateMagicCell(Cast magic, int posX, int index)
    {
        GameObject newMagic = Instantiate(cellGameObject, new Vector3(posX, 50, 0), Quaternion.identity, transform);

        cells[index] = newMagic;
        cells[index].GetComponent<MagicCell>().cast = magic;
    }
}