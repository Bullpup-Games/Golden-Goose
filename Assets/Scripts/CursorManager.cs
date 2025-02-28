using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
   
    [SerializeField]
    Texture2D cursorTexture;
    
    [SerializeField]
    private Vector2 clickPosition = Vector2.zero;
    void Start()
    {
        Cursor.SetCursor(cursorTexture, clickPosition, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    Vector2 MousePosInWorldSpace()
    {

       // return Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return Vector2.zero;
    }
}
