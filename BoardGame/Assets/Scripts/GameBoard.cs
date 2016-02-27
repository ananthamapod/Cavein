using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using CoherentNoise;
using CoherentNoise.Generation;

public class GameBoard : MonoBehaviour {

    public GameObject background;
    public GameObject tilePrefab;
    public GameObject tileHolder;
    public GameObject cubeHolder;

    private List<List<GameObject>> cubeGrid;
    public int gridHeight;
    public int gridWidth;

    private Generator heightMap;
    private float threshold;

    private List<List<GameObject>> boardMap = new List<List<GameObject>>();

	// Use this for initialization
	void Start () {
        cubeGrid = GetComponent<RandomizedGrid>().PopulateGrid(gridHeight, gridWidth);
        heightMap = GetComponent<RandomizedGrid>().CreateGenerator();
        threshold = GetComponent<RandomizedGrid>().threshold;
        GenerateBoardMap();
        ConsolidateElements();
    }

    void GenerateBoardMap()
    {
        background = Instantiate(background);
        background.name = "Background";
        background.transform.localScale = new Vector3(((float)gridHeight * 1.05f) / 10, 0, ((float)gridWidth * 1.05f) / 10);
        background.transform.position = new Vector3(.5f, 0, .5f);

        for (int x = 0; x < gridHeight; x += 2)
        {
            List<GameObject> sublist = new List<GameObject>();
            for (int y = 0; y < gridWidth; y += 2)
            {
                if (TestLocation(x,y))
                {
                    Debug.Log(x + " " + y);
                    GameObject tile = Instantiate(tilePrefab);
                    sublist.Add(tile);
                    tile.transform.position = new Vector3(gridHeight / 2 - x - .5f, 3, gridWidth / 2 - y - .5f);
                }
            }
            boardMap.Add(sublist);
        }
    }

    void ConsolidateElements()
    {
        foreach (List<GameObject> row in cubeGrid)
        {
            foreach (GameObject cube in row)
            {
                cube.transform.SetParent(cubeHolder.transform);
            }
        }

        foreach (List<GameObject> row in boardMap)
        {
            foreach (GameObject tile in row)
            {
                tile.transform.SetParent(tileHolder.transform);
            }
        }
    }

    bool TestLocation(int x, int y)
    {
        return (heightMap.GetValue(x, y, 0) < threshold) && (heightMap.GetValue(x + 1, y, 0) < threshold) && (heightMap.GetValue(x, y + 1, 0) < threshold) && (heightMap.GetValue(x + 1, y + 1, 0) < threshold);
    }

/*    public class Board
    {
        public class Tile
        {
            public bool occupied;
            GameObject Character;
        }

        List<List<Tile>> tileMap = new List<List<Tile>>();

    }
*/

    // Update is called once per frame
    void Update () {
	
	}
}
