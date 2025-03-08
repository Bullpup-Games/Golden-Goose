using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
   
    [SerializeField]
    Texture2D cursorTexture;
    
    [SerializeField]
    private Vector2 clickPosition = Vector2.zero;

    private static CursorManager _instance;
    public static CursorManager Instance => _instance;

    private void Awake()
    {
        if (_instance is not null)
        {
            Destroy( _instance );
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

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
