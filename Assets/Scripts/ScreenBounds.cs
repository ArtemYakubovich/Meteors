using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    public Bounds Bounds { get; private set; }
    public Bounds TresholdBounds { get; private set; } 

    private void Awake()
    {
        Camera mainCamera = FindObjectOfType<Camera>();

        Vector2 screenMin = mainCamera.ViewportToWorldPoint(Vector3.zero);
        Vector2 screenMax = mainCamera.ViewportToWorldPoint(Vector3.one);
        Vector2 center = mainCamera.transform.position;

        Bounds = CreateBounds(center, screenMin, screenMax);
        Vector2 treshold = Vector3.one;
        TresholdBounds = CreateBounds(center, screenMin - treshold, screenMax + treshold);
    }

    private Bounds CreateBounds(Vector2 center, Vector2 min, Vector2 max)
    {
        return new Bounds(center, new Vector2(max.x - min.x, max.y - min.y));
    }
}
