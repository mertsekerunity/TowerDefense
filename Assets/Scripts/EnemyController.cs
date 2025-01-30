using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] List<Transform> path = new List<Transform>();
    [SerializeField][Range(0, 5)] float speed = 1f;

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
        foreach (Transform tiles in path)
        {
            Debug.Log(tiles.name);
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
    }
}
