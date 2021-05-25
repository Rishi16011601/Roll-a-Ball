using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
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
    private void Start()
    {
        count = 0;
        theTime = 0;
        SetCountText();
        winTextObject.SetActive(false);
        
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
        if (Input.GetKey(keyPositive))
            GetComponent<Rigidbody>().velocity += v3Force;
        if (Input.GetKey(keyNegative))
            GetComponent<Rigidbody>().velocity -= v3Force;

        if (count != 12)
        {
            theTime = (theTime + Time.deltaTime);
            SetTime();
        }
        
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
}
