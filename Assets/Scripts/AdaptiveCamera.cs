using UnityEngine;

public class AdaptiveCamera : MonoBehaviour
{
    public float targetWidth = 1080f; // Độ rộng chuẩn mong muốn
    public float targetHeight = 1920f; // Độ cao chuẩn mong muốn
    public float pixelsPerUnit = 100f; // Pixels per unit của game

    void Start()
    {
        AdjustCamera();
    }

    void AdjustCamera()
    {
        float targetAspect = targetWidth / targetHeight;
        float screenAspect = (float)Screen.width / Screen.height;
        float difference = screenAspect / targetAspect;

        Camera.main.orthographicSize = targetHeight / (2f * pixelsPerUnit);
        
        if (difference < 1f) // Màn hình cao hơn so với tỷ lệ mong muốn
        {
            Camera.main.orthographicSize /= difference;
        }
    }
}
