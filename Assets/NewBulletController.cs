using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBulletController : MonoBehaviour
{

    public int bulletSelection = 0;

    // Start is called before the first frame update
    void Start()
    {
        SelectBullet();
    }

    // Update is called once per frame
    void Update()
    {

        int prevSelection = bulletSelection;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (bulletSelection >= transform.childCount - 1)
                bulletSelection = 0;
            else
                bulletSelection++;
            // Doable with Modulo?
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (bulletSelection <= 0)
                bulletSelection = transform.childCount - 1;
            else
                bulletSelection--;
            // Doable with Modulo?
        }

        if (prevSelection != bulletSelection)
        {
            SelectBullet();
        }
        // Map to numbers? KeyCode.Alpha1, etc.
    }

    void SelectBullet ()
    {
        int i = 0;

        foreach (Transform bullet in transform)
        {
            if (i == bulletSelection)
                bullet.gameObject.SetActive(true);
            else
                bullet.gameObject.SetActive(false);
            i++;

        }

    }
}
