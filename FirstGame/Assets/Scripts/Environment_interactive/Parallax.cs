using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform Cam;
    public float MoveRate;
    private float StartPointX,StartPointY,Cam_StartPointX;
    public bool LockY;

    void Start()
    {
        StartPointX= transform.position.x;
        StartPointY = transform.position.y;
        Cam_StartPointX = Cam.position.x;
    }
    void Update()
    {
        if (LockY)
        {
            transform.position = new Vector2(StartPointX + (Cam.position.x - Cam_StartPointX) * MoveRate, StartPointY);
        }
        else
        {
            transform.position = new Vector2(StartPointX + (Cam.position.x - Cam_StartPointX) * MoveRate, StartPointY + Cam.position.y * MoveRate);
        }
    }
}
