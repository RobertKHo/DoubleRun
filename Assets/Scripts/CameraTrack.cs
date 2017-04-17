using UnityEngine;

public class CameraTrack : MonoBehaviour {

    void Update()
    {
        transform.Translate(0f, 0f, 5f * Time.deltaTime);
    }
}
