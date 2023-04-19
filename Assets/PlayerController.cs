using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float PlayerSpeed;
    Rigidbody2D PlayerRB;

    public GameObject BulletPf;
    public float BulletSpd;
    private float FireRate;
    public float BulletDelay;
    private InventoryManager Inventory;
    [SerializeField] private InventoryUI uiInventory;
    public int tempItem;

    // Start is called before the first frame update
    void Start()
    {
        PlayerRB = GetComponent<Rigidbody2D>();
        tempItem = 0;
        Inventory = new InventoryManager();
        Debug.Log("Inventorizing.");
        uiInventory.SetInventory(Inventory);
    }

    private void Awake()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        float pewH = Input.GetAxis("PewPewHoriz");
        float pewV = Input.GetAxis("PewPewVert");

        if((pewH != 0 || pewV != 0) && Time.time > FireRate + BulletDelay)
        {
            Shoot(pewH, pewV);
            FireRate = Time.time;
        }

        PlayerRB.velocity = new Vector3(horiz * PlayerSpeed, vert * PlayerSpeed, 0);
    }

    void Shoot(float x, float y)
    {
        GameObject bullet = Instantiate(BulletPf, transform.position, transform.rotation) as GameObject;
        bullet.AddComponent<Rigidbody2D>().gravityScale = 0;
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector3(
            (x < 0) ? Mathf.Floor(x) * BulletSpd : Mathf.Ceil(x) * BulletSpd,
            (y < 0) ? Mathf.Floor(y) * BulletSpd : Mathf.Ceil(y) * BulletSpd,
            0
        );
        if (tempItem > 0)
        {
            bullet.GetComponent<SpriteRenderer>().material.color = new Color(0, 255, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if(col.tag == "Pickup")
        {
            tempItem += 1;
            Destroy(col.transform.gameObject);
        }
    }

}
