using UnityEditor;
using UnityEngine;

public class GetScreenSize
{
    public Vector2 ScreenSize()
    {
        int x = Screen.width;
        int y = Screen.height;
        Vector2 size;
        size.x = x;
        size.y = y;
        return size;
    }
}