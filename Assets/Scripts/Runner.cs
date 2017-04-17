using UnityEngine;

public class Runner : MonoBehaviour {
    //controls for both runners

    public static float distanceTraveled;

    void Update()
    {
        transform.Translate(0f, 0f, 5f * Time.deltaTime);
        distanceTraveled = transform.localPosition.z;
    }
}
