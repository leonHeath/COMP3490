using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenMap : MonoBehaviour {

    public int sizeX, sizeY, sizeZ;
    public int mapSize;

    public string seed;

    public Transform floor;

    public Transform ceiling;

    public Transform[] walls = new Transform[2];

    public Transform monster;

    private int xCoord = 0, zCoord = 0;

    private bool justWentLeft = false;
    private bool justWentRight = false;

    private List<int> currentRow = new List<int>();
    private List<int> previousRow = new List<int>();

    private System.Random pseudoRandom;

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

        pseudoRandom = new System.Random(seed.GetHashCode());
        placeTile(0, 0);

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
                //If initial row
                if (zCoord == 0) 
                {
                    addInitialWalls();
                }
                addTileForward();
                justWentRight = false;
                justWentLeft = false;
            }
            if(x > 5)
            {
                spawnMonster(xCoord, zCoord);
            }
        }
        addEndWalls();
    }

    void addTileRight()
    {
        xCoord += sizeX;
        placeTile(xCoord, zCoord);
        
    }

    void addTileLeft()
    {
        xCoord -= sizeX;
        placeTile(xCoord, zCoord);
    }

    void addTileForward()
    {
        addHorizWalls();
        updateRows();
        zCoord += sizeZ;
        placeTile(xCoord, zCoord);
        addVertWalls();

    }

    void updateRows()
    {
        previousRow.Clear();
        previousRow.AddRange(currentRow);
        currentRow.Clear();
    }

    //Add initial walls to start of map
    void addInitialWalls()
    {
        for (int i = currentRow[0]; i <= currentRow[currentRow.Count - 1]; i += sizeX)
        {
            placeWall(i, zCoord - sizeZ / 2, 0);
        }
    }

    //This adds the horizontal walls that go left to right
    void addHorizWalls()
    {
        if (currentRow.Count > 0 && previousRow.Count > 0)
        {
            currentRow.Sort();
            previousRow.Sort();

            if (previousRow[0] < currentRow[0])
            {
                for (int i = previousRow[0]; i < currentRow[0]; i += sizeX)
                {
                    placeWall(i, zCoord - sizeZ / 2, 180);
                }
            }
            else if (previousRow[0] > currentRow[0])
            {
                for (int i = currentRow[0]; i < previousRow[0]; i += sizeX)
                {
                    placeWall(i, zCoord - sizeZ / 2, 0);
                }
            }
            if (previousRow[previousRow.Count - 1] < currentRow[currentRow.Count - 1])
            {
                for (int i = currentRow[currentRow.Count - 1]; i > previousRow[previousRow.Count - 1]; i -= sizeX)
                {
                    placeWall(i, zCoord - sizeZ / 2, 0);
                }
            }
            else if (previousRow[previousRow.Count - 1] > currentRow[currentRow.Count - 1])
            {
                for (int i = previousRow[previousRow.Count - 1]; i > currentRow[currentRow.Count - 1]; i -= sizeX)
                {
                    placeWall(i, zCoord - sizeZ / 2, 180);
                }
            }
        }
    }


    void addVertWalls()
    {
        int x;
        if (previousRow.Count > 0) {
            //Sort these lists
            previousRow.Sort();

            //Add wall to the left side of pathway
            x = previousRow[0];
            placeWall(x - sizeX / 2, zCoord - sizeZ, 90);

            //Add wall to the right side of pathway
            x = previousRow[previousRow.Count - 1];
            placeWall(x + sizeX / 2, zCoord - sizeZ, 270);
        }
        
    }

    void addFinalWalls()
    {
        int x;
        if (previousRow.Count > 0)
        {
            //Sort these lists
            previousRow.Sort();

            //Add wall to the left side of pathway
            x = previousRow[0];
            placeWall(x - sizeX / 2, zCoord, 90);

            //Add wall to the right side of pathway
            x = previousRow[previousRow.Count - 1];
            placeWall(x + sizeX / 2, zCoord, 90);

            for (int i = previousRow[0]; i <= previousRow[previousRow.Count - 1]; i += sizeX)
            {
                //Instantiate(wall, new Vector3(i, sizeY / 2, zCoord + sizeZ / 2), Quaternion.identity);
                placeWall(i, zCoord + sizeZ / 2, 0);
            }
        }
    }

    void addEndWalls()
    {
        addHorizWalls();
        updateRows();
        addFinalWalls();
    }

    void placeTile(int x, int z)
    {
        currentRow.Add(xCoord);
        Instantiate(floor, new Vector3(x, 0, z), Quaternion.identity);

        Instantiate(ceiling, new Vector3(x, 8, z), Quaternion.Euler(0, 0, 180));
    }

    void placeWall(int x, int z, int rotation)
    {
        int i;
        int tempRand = pseudoRandom.Next(0, 100);
        if (tempRand > 92)
            i = 0;
        else
            i = 1;

        Instantiate(walls[i], new Vector3(x, sizeY / 2, z), Quaternion.Euler(0, rotation, 0));
    }

    void spawnMonster(int x, int z)
    {
        int tempRand = pseudoRandom.Next(0, 100);
        if (tempRand > 80)
            Instantiate(monster, new Vector3(x, 0, z), Quaternion.Euler(0, 180, 0));
    }

}
