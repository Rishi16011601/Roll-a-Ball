using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Controls : MonoBehaviour
{
    private int count;
    private float theTime;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public TextMeshProUGUI calTime;

    [SerializeField]
    Vector3 v3Force;
    [SerializeField]
    KeyCode keyPositive;
    [SerializeField]
    KeyCode keyNegative;
    // Start is called before the first frame update

    private Rigidbody rb;
    public float speed;
    private GameObject focalPoint;

    private float movementX;
    private float movementY;

    private void Start()
    {
        count = 0;
        theTime = 0;
        SetCountText();
        winTextObject.SetActive(false);
        //rbplayer = GetComponent<Rigidbody>();
        //focalPoint = GameObject.Find("FocalPoint");

        rb = GetComponent<Rigidbody>();

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
    }

    void SetTime()
    {
        //string tym = string.Format("{0:.2f}", theTime);
        calTime.text = "Time: \n" + theTime.ToString("F");
        //calTime.text = "Time: \n" + tym;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (count != 12)
        {
            theTime = (theTime + Time.deltaTime);
            SetTime();
        }

        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;

            SetCountText();
        }
    }
    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }
}