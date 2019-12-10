using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    //components
    SpriteRenderer theSR;

    //SerializedFields
    [SerializeField] Sprite defaultImage;
    [SerializeField] Sprite pressedImage;
    [SerializeField] KeyCode keyToPress;
    [SerializeField] KeyCode secondKeyToPress;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) || Input.GetKeyDown(secondKeyToPress))
        {
            theSR.sprite = pressedImage;
        }
        if (Input.GetKeyUp(keyToPress) || Input.GetKeyUp(secondKeyToPress))
        {

            theSR.sprite = defaultImage;
        }
    }
}
