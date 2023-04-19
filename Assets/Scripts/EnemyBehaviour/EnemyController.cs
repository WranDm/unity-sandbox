using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Wander,
    Follow,
    Search,
    Die
};

public class EnemyController : MonoBehaviour
{

    GameObject player;
    public EnemyState currentSt = EnemyState.Wander;

    public float range;
    public float speed;
    private bool whichWay = false;
    private bool dead = false;
    private Vector3 randDir;
    
    [SerializeField] float sight = 5;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentSt)
        {
            case (EnemyState.Wander):
                Wander();
                break;
            case (EnemyState.Follow):
                Follow();
                break;
            case (EnemyState.Search):
                Search();
                break;
            case (EnemyState.Die):

                break;
        }

        if(isPlayerClose(range) && currentSt != EnemyState.Die)
        {
            currentSt = EnemyState.Follow;
        }
        else if(!isPlayerClose(range) && currentSt != EnemyState.Die)
        {
            currentSt = EnemyState.Wander;
        }    
    }

    private bool isPlayerClose(float range)
    {
        // Why does canseePlayer not work.
        return (Vector3.Distance(transform.position, player.transform.position) <= range) && canSeePlayer(sight);
    }

    bool canSeePlayer(float distance)
    {
        bool val = false;
        var castDist = distance;

        // If player should not be immediately visible, use:
        // Vector2 endPos = castPoint.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Linecast(transform.position, player.transform.position, 1 << LayerMask.NameToLayer("Action"));

        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                // Aggro
                val = true;

            } else
            {
                //fix? add delay to chase? like Invoke? 
                val = false;
            }

            
        }
        Debug.DrawLine(transform.position, player.transform.position, Color.blue);
        return val;
    }

    private IEnumerator ThisWay()
    {
        whichWay = true;
        yield return new WaitForSeconds(Random.Range(2f, 8f));
        randDir = new Vector3(0, 0, Random.Range(0, 360));
        Quaternion nextRot = Quaternion.Euler(randDir);
        transform.rotation = Quaternion.Lerp(transform.rotation, nextRot, Random.Range(0.5f, 2.5f));
        whichWay = false;
    }

    void Wander()
    {
        if(!whichWay)
        {
            StartCoroutine(ThisWay());
        }

        transform.position += -transform.right * speed * Time.deltaTime;
        if(isPlayerClose(range))
        {
            currentSt = EnemyState.Follow;
        }
    }

    void Follow()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    void Search()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
