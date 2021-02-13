using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed = 5f;
    public Vector3 startPosition;
    public Vector3 startScale;
    // Start is called before the first frame update

    void Start()
    {
        startPosition = gameObject.transform.position;
        startScale = gameObject.transform.localScale;

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

    public void sizeIncrease()
    {
        this.transform.localScale += new Vector3(0, 0.5f, 0);
    }

    public void sizeDecrease()
    {
        this.transform.localScale -= new Vector3(0, 1.0f, 0);
    }

    public void Reset()
    {
        transform.position = startPosition;
        transform.localScale = startScale;
    }
}

