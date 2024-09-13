using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrostSpellCast : MonoBehaviour
{
    public GameObject spellVisualizer;
    private GameObject currentVisualizer;

    public GameObject frostSpell;

    public float groundLevel = 0f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pickFrostSpell();
        }

        if (currentVisualizer != null)
        {
            moveVisualizerAlongMouse();
             if (Input.GetMouseButtonDown(0)) 
             {
                useSpell();
             }            
        }
    }

    void pickFrostSpell()
    {
        if (currentVisualizer != null)
        {
            Destroy(currentVisualizer);
        }

            Cursor.visible = false; 

        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.y = groundLevel;
        currentVisualizer = Instantiate(spellVisualizer, mouseWorldPosition, Quaternion.identity);
    }

    void moveVisualizerAlongMouse()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        mouseScreenPosition.z = Mathf.Abs(Camera.main.transform.position.z);
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.y = groundLevel;
        currentVisualizer.transform.position = mouseWorldPosition;
    }

    void useSpell()
    {

         Instantiate(frostSpell, currentVisualizer.transform.position, Quaternion.identity);
            Destroy(currentVisualizer);         
                        Cursor.visible = true; 
    }
}
