using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float m_leftAlign = 8.885282f; //x position of left side of the camera
    private float m_orthographicWidth;
    private void Start()
    {
        m_orthographicWidth = Camera.main.aspect * Camera.main.orthographicSize;
        transform.position = new Vector3(m_orthographicWidth - m_leftAlign, transform.position.y, transform.position.z);
    }

}
