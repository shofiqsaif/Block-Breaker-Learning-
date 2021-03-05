using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float screenWidthInUnit = 16f;
    [SerializeField] float minX;
    [SerializeField] float maxX;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnit= (Input.mousePosition.x / Screen.width * screenWidthInUnit);
        
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        mousePosInUnit = Mathf.Clamp(mousePosInUnit, minX, maxX);
        paddlePos.x = mousePosInUnit;

        transform.position = paddlePos;

    }
}
