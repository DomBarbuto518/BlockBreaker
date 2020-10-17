using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] Vector2 paddlePos;
    [SerializeField] float mouseXPosInUnits;
    [SerializeField] float paddleMinX = 1f;
    [SerializeField] float paddleMaxX = 15f;
    const int SCREEN_WIDTH_IN_UNITS = 16;

    // Start is called before the first frame update
    void Start()
    {
        paddlePos = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithMouse();
    }

    private void MoveWithMouse()
    {
        mouseXPosInUnits = Input.mousePosition.x / Screen.width * SCREEN_WIDTH_IN_UNITS;    //Get Mouse position
        //Set paddle position vector to mouses position
        paddlePos.x = Mathf.Clamp(mouseXPosInUnits, paddleMinX, paddleMaxX);                
        //Set paddles position with our new vector
        transform.position = paddlePos;
    }
}
