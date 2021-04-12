using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager Instance;
    public GameObject tile;
    public GameObject[,] grid;

    int row = 10;
    int col = 10;
    // Start is called before the first frame update
    void Start()
    {
        int offset = 1;
        CreateGrid(offset, offset);
    }

    private void CreateGrid(float offsetX, float offsetY)
    {
        grid = new GameObject[col, row];
        for (int x = 0; x < col; x++)
        {
            for (int y = 0; y < row; y++)
            {
                GameObject newTile = (Instantiate(tile, new Vector3((offsetX * x), (offsetY * y), 0), Quaternion.Euler(0, 0, 180)));
                //int randomDirection = Random.Range(0, 4);
                //if (randomDirection == 0)
                //{
                //    newTile.GetComponent<TileScript>().direction = Direction.UP;
                //}
                //else if (randomDirection == 1)
                //{
                //    newTile.GetComponent<TileScript>().direction = Direction.RIGHT;
                //    newTile.gameObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                //}
                //else if (randomDirection == 2)
                //{
                //    newTile.GetComponent<TileScript>().direction = Direction.DOWN;
                //    newTile.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                //}
                //else if (randomDirection == 3)
                //{
                //    newTile.GetComponent<TileScript>().direction = Direction.LEFT;
                //    newTile.gameObject.transform.rotation = Quaternion.Euler(0, 0, -90);
                //}
                grid[x, y] = newTile;
                //newTile.transform.parent = transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
