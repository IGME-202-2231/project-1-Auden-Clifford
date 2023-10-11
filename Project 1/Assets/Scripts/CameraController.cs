using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera gameViewport;

    /// <summary>
    /// Gets the viewport width in pixels
    /// </summary>
    public float ViewportPixelWidth { get { return gameViewport.pixelWidth; } }

    /// <summary>
    /// Gets the viewport height in pixels
    /// </summary>
    public float ViewportPixelHeight { get { return gameViewport.pixelHeight; } }

    // Start is called before the first frame update
    void Start()
    {
        print(ViewportPixelWidth + ", " + ViewportPixelHeight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
