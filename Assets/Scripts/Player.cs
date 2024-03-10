using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 50;

    private bool isObjectAttached = true;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isObjectAttached)
        {
            isObjectAttached = false;
            return;
        }

        if (isObjectAttached)
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            mousePos.y = 4;

            var finalPosition = Vector3.MoveTowards(transform.position, mousePos, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(finalPosition);
        }
        else
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }

    private void OnMouseDown()
    {
        if (!isObjectAttached && Input.GetMouseButtonDown(0))
        {
            isObjectAttached = false;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
        }
    }
}
