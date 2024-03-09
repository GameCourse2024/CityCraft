using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Transform holdSpot;
    public LayerMask pickupMask;
    private GameObject item;
    [SerializeField] private float offset = 0.4f;

    private InputMover playerInput;

    private void Start()
    {
        playerInput = GetComponent<InputMover>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Pressed Z");
            if (item)
            {
                item.transform.position = transform.position + playerInput.FacingDirection;
                item.transform.parent = null;
                if (item.GetComponent<Rigidbody2D>())
                {
                    item.GetComponent<Rigidbody2D>().simulated = true;
                }
                item = null;
            }
            else
            {
                Debug.Log("Entered ELSE");
                Collider2D pickUp = Physics2D.OverlapCircle(transform.position + playerInput.FacingDirection, offset, pickupMask);
                if (pickUp)
                {
                    item = pickUp.gameObject;
                    item.transform.position = holdSpot.position;
                    item.transform.parent = transform;
                    if (item.GetComponent<Rigidbody2D>())
                    {
                        item.GetComponent<Rigidbody2D>().simulated = false;
                    }
                }
            }
        }
    }
}
