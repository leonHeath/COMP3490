using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMap : MonoBehaviour {

    public int sizeX, sizeZ;
    public int mapSize;

    public string seed;

    public Transform floor;

    private int xCoord = 0, zCoord = 0;

    private enum direction {Left, Forward, Right, Backward};

    private bool justWentLeft = false;
    private bool justWentRight = false;

    private List<int> currentRow = new List<int>();
    private List<int> previousRow = new List<int>();

    void Start()
    {
        GenerateMap();
    }

    void Update()
    {

    }

    void GenerateMap()
    {
        
        Debug.Log("Generating map");
        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < mapSize; x++)
        {
            
            int tempRand = pseudoRandom.Next(0, 100);
            if (tempRand > 75)
            {
                if (justWentLeft)
                {
                    addTileLeft();
                }
                else
                {
                    addTileRight();
                    justWentRight = true;
                }
                
            }
            else if (tempRand > 50)
            {
                if (justWentRight)
                {
                    addTileRight();
                }
                else
                {
                    addTileLeft();
                    justWentLeft = true;
                }
            }
            else
            {
                addTileForward();
                justWentRight = false;
                justWentLeft = false;
            }

        }
    }

    void addTileRight()
    {
        xCoord += sizeX;
        placeTile(xCoord, zCoord);
        currentRow.Add(xCoord);
    }

    void addTileLeft()
    {
        xCoord -= sizeX;
        placeTile(xCoord, zCoord);
        currentRow.Add(xCoord);
    }

    void addTileForward()
    {
        zCoord += sizeX;
        placeTile(xCoord, zCoord);
        addWalls();
        previousRow.Clear();
        previousRow.AddRange(currentRow);
        currentRow.Clear();
    }

    void addWalls()
    {
        //Make comparisons between previous row and current row which determine where to place walls
    }

    void placeTile(int x, int z)
    {
        Debug.Log("Coords:" + x + " " + z);
        Instantiate(floor, new Vector3(x, 0, z), Quaternion.identity);
    }
}
