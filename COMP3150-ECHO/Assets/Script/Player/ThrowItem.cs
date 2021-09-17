using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    public Camera cam;
  
    private Vector2 lastMouseClick;
    public float speed = 10f;
    [SerializeField]
    private int ammoCount = 5;
    private int currentAmmoIndex = 0;
    bool isClicked = false;
    [Space]
    public GameObject itemRippleEffect;
    private const int LEFT_CLICK = 0;
    private const int RIGHT_CLICK = 1;
    public int GetAmmoCount()
    {
        return ammoCount - currentAmmoIndex;
    }
    [Space]
    public ItemMove rock;
    void Start()
    {
        currentItem = null;
    }

    // Update is called once per frame
    void Update()
    {
        // IF RIGHT-MOUSE CLICKED
        if(Input.GetMouseButtonDown(LEFT_CLICK))
        {
            isClicked = true;

            // CHECK IF HAS AMMO
            if (currentAmmoIndex < ammoCount)
            {

                ItemMove temp = Instantiate(rock);
                temp.transform.position = transform.position;
                lastMouseClick = cam.ScreenToWorldPoint(Input.mousePosition);
                temp.SetTarget(lastMouseClick);
                // COUNT FOR AN AMMO
                currentAmmoIndex++;


            }

        }

       

    }



}
