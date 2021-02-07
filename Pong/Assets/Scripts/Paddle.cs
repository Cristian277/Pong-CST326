using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed = 5f;
    public Vector3 startPosition;
    // Start is called before the first frame update

    void Start()
    {
        startPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            transform.Translate(0f, Input.GetAxisRaw("Vertical") * speed * Time.deltaTime,0f);
        }
        else
        {
            transform.Translate(0f, Input.GetAxisRaw("Vertical2") * speed * Time.deltaTime, 0f);
        }
    }

    public void Reset()
    {
        transform.position = startPosition;
    }
}

