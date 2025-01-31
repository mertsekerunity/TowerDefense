using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField] Node currentSearchNode;
    Vector2Int[] directions = {Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};

    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        if (gridManager != null )
        {
            grid = gridManager.Grid;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        ExploreNeighbours();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ExploreNeighbours()
    {
        List<Node> neighbours = new List<Node>();
        foreach(Vector2Int direction in directions)
        {
            Vector2Int neighbourCoordinates = currentSearchNode.coordinates + direction;

            if (grid.ContainsKey(neighbourCoordinates))
            {
                neighbours.Add(grid[neighbourCoordinates]);

                //remove after testing
                grid[neighbourCoordinates].isExplored = true;
                grid[currentSearchNode.coordinates].isPath = true;
            }
        }
    }
}
