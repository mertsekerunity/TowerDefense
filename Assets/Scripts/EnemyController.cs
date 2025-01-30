using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //[SerializeField] List<Waypoint> path = new List<Waypoint>();
    List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0, 5)] float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        FindPath();
        StartCoroutine(FollowPath());
        //ReturnToStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint tiles in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 endPosition = tiles.transform.position;
            float travelPercent = 0;

            transform.LookAt(endPosition);

            while(travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * speed;
                transform.position = Vector3.Lerp(startPosition,endPosition,travelPercent);
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }

    void FindPath()
    {
        path.Clear();

        GameObject parent = GameObject.FindGameObjectWithTag("Path");

        foreach (Transform child in parent.transform)
        {
            Waypoint waypoint = child.GetComponent<Waypoint>();
            
           if(waypoint != null)
            {
                path.Add(waypoint);
            }
        }
    }

    void ReturnToStart()
    {
        transform.position = path[0].transform.position;
    }

    void FinishPath()
    {
        Destroy(gameObject);
    }
}
