using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50;

    private bool isObjectAttached = true;

    private void Update()
    {
        if (!isObjectAttached)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            isObjectAttached = false;
            Destroy(this);
            return;
        }

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        mousePos.y = 4;

        var finalPosition = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
        GetComponent<Rigidbody2D>().MovePosition(finalPosition);
    }

    private void OnMouseDown()
    {
        if (isObjectAttached)
        {
            isObjectAttached = false;
            Destroy(this);
        }
    }
}
