using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    public Camera cam;
    [SerializeField]
    private GameObject[] items;
    private Transform currentItem;
    private Vector2 lastMouseClick;
    public float speed = 10f;
    [SerializeField]
    private int ammoCount = 5;
    private int currentAmmoIndex = 0;
    bool isClicked = false;

    [Space]
    public GameObject rock;
    void Start()
    {
        currentItem = null;
        foreach(GameObject i in items)
        {
           GameObject temp =  Instantiate(i);
           temp.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // IF RIGHT-MOUSE CLICKED
        if(Input.GetMouseButtonDown(1))
        {
            isClicked = true;

            // CHECK IF HAS AMMO
            if (currentAmmoIndex < ammoCount)
            {

                // ACTIVATE CURRENT AMMO
                // items[currentAmmoIndex].SetActive(true);

                GameObject temp = Instantiate(rock);
                temp.transform.position = transform.position;
                currentItem = temp.transform;
                // SET POSITION OF CURRENT AMMO TO PLAYER'S POS
                // items[currentAmmoIndex].transform.position = transform.position;

                // REGISTER LAST MOUSE CLICK
                lastMouseClick = cam.ScreenToWorldPoint(Input.mousePosition);

                // REGISTER THE CURRENT AMMO ITEM TO MOVE
                // currentItem = items[currentAmmoIndex].transform;

                // COUNT FOR AN AMMO
                currentAmmoIndex++;
            }

        }
        if(isClicked)
        {

            // MAKE THE LAST ITEM MOVE TOWARDS MOUSE
            if(currentItem)
            {
                currentItem.position = Vector2.MoveTowards(currentItem.position, lastMouseClick, (speed * Time.deltaTime));

            }

        }
       

    }



}
