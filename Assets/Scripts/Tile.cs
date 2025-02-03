using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] Tower towerPrefab;
    
    public Vector2Int coordinates = new Vector2Int();

    GridManager gridManager;
    Pathfinder pathfinder;

    private void Awake()
    {
        gridManager = FindObjectOfType<GridManager>();
        pathfinder = FindObjectOfType<Pathfinder>();
    }

    private void Start()
    {
        if (gridManager != null)
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if (!isPlaceable)
            {
                gridManager.BlockNode(coordinates);
            }
        }
    }

    public bool IsPlaceable
    {
        get
        {
            return isPlaceable;
        }
    }

    private void OnMouseDown()
    {
        if (gridManager.GetNode(coordinates).isWalkable && !pathfinder.WillBlockPath(coordinates))
        {
            bool isSuccussful = towerPrefab.CreateTower(towerPrefab, transform.position);
            if (isSuccussful)
            {
                gridManager.BlockNode(coordinates);
                pathfinder.NotifyReceivers();
            }
        }
    }
}
