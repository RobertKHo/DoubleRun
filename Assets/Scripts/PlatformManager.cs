using UnityEngine;
using System.Collections.Generic;

public class PlatformManager : MonoBehaviour {
    //instead of platforms make a "road" with holes
    //that players have to avoid.
    //high end goal is that road panels of the same color
    //as a runner is solid for that runner but not the others
    //example: red floor is safe for red runner but not blue runner

    public Transform prefab;
    public int numberOfObjects;
    public float recycleOffset;
    public Vector3 startPosition;
    public Vector3 minSize, maxSize, minGap, maxGap;
    public float minX, maxX;

    private Vector3 nextPosition;
    private Queue<Transform> objectQueue;

	// Use this for initialization
	void Start () {
        objectQueue = new Queue<Transform>(numberOfObjects);
        for(int i = 0; i < numberOfObjects; i++)
        {
            objectQueue.Enqueue((Transform)Instantiate(prefab));
        }
        nextPosition = startPosition;
        for(int i = 0; i < numberOfObjects; i++)
        {
            Recycle();
        }
	
	}
	
	// Update is called once per frame
	void Update () {
        if (objectQueue.Peek().localPosition.z + recycleOffset < Runner.distanceTraveled)
        {
            Recycle();
        }
    }

    private void Recycle()
    {
        Vector3 scale = new Vector3(
            Random.Range(minSize.x, maxSize.x),
            Random.Range(minSize.y, maxSize.y),
            Random.Range(minSize.z, maxSize.z));

        Vector3 position = nextPosition;
        position.x += scale.x * 0.5f;
        position.z += scale.z * 0.5f;

        Transform o = objectQueue.Dequeue();
        o.localScale = scale;
        o.localPosition = position;
        objectQueue.Enqueue(o);

        nextPosition += new Vector3(
            Random.Range(minGap.x, maxGap.x),
            Random.Range(minGap.y, maxGap.y),
            Random.Range(minGap.z, maxGap.z)+ scale.z);

        if(nextPosition.x < minX)
        {
            nextPosition.x = minX + maxGap.x;
        }
        else if(nextPosition.x > maxX)
        {
            nextPosition.x = maxX - maxGap.x;
        }
    }
}
