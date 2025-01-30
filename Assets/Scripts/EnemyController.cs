using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Transform> path = new List<Transform>();
    [SerializeField] float waitTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FollowPath()
    {
        foreach(Transform tiles in path)
        {
            Debug.Log(tiles.name);
            transform.position = tiles.transform.position;
            yield return new WaitForSeconds(waitTime);
        }
    }
}
