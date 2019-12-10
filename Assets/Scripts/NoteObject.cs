using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteObject : MonoBehaviour
{
    //SerializedFields
    [SerializeField] KeyCode keyToPress;
    [SerializeField] KeyCode secondKeyToPress;

    public bool canBePressed;

    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress) || Input.GetKeyDown(secondKeyToPress))
        {
            if (canBePressed)
            {
                gameObject.SetActive(false);
                //GameController.instance.NoteHit();

                if (Mathf.Abs(transform.position.y) > 0.25f)
                {
                    GameController.instance.NormalHit();
                    Debug.Log("Hit");
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if (Mathf.Abs(transform.position.y) > 0.05f)
                {
                    GameController.instance.GoodHit();
                    Debug.Log("Good Hit");
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    GameController.instance.PerfectHit();
                    Debug.Log("Perfect Hit");
                    Instantiate(perfectEffect, transform.position, perfectEffect.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Activator")
        {
            canBePressed = false;
            GameController.instance.NoteMissed();
            Instantiate(missEffect, transform.position, missEffect.transform.rotation);
        }
    }
}
