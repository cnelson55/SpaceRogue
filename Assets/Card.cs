using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    private int Cost { get; set; }
    private int Value { get; set; }
    private bool IsOffense { get; set; }

    private float startPosX;
    private float startPosY;
    private bool isBeingHeld = false;

    // Start is called before the first frame update
    void Start()
    {
        Cost = Random.Range(0,5);
        Value = Random.Range(0, 5);
        IsOffense = true;

        startPosX = transform.position.x;
        startPosY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeingHeld == true)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            this.gameObject.transform.localPosition = new Vector3(mousePos.x, mousePos.y, 0);
        } else
        {
            if (transform.position.y > -0.25 && transform.position.x > -4.5 && transform.position.x < 4.0)
            {

                GameObject.Find("PlayedNotifier").GetComponent<Text>().text = "Cost: " + Cost + "   Value: " + Value;
                Object.Destroy(this.gameObject);

            } else
            {
                this.gameObject.transform.localPosition = new Vector3(startPosX, startPosY, 0);
            }
            
        }
    }

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject.Find("PlayedNotifier").GetComponent<Text>().text = "";
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);


            isBeingHeld = true;
        }
    }

    private void OnMouseUp()
    {
        isBeingHeld = false;
    }
}

