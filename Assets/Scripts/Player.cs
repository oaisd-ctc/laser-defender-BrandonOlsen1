using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float Speed = 5f;

     [SerializeField] float paddingleft;
      [SerializeField] float paddingright;
       [SerializeField] float paddingtop;
        [SerializeField] float paddingbottem;


    Vector2 rawInputt;

    Vector2 minBounds;
    Vector2 MaxBounds;


    void Start() 
    {
        InitBounds();
    }
   
    void Update()
    {
        Moving();
    }


    


    void Moving()
    {
        Vector2 delta = rawInputt * Speed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingleft, MaxBounds.x- paddingright);
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingbottem , MaxBounds.y - paddingtop);
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInputt = value.Get<Vector2>();
        Debug.Log(rawInputt);
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        MaxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }




}
