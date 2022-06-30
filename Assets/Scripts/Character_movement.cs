using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_movement : MonoBehaviour {

    Rigidbody playerRB;
    Vector3 movementUp, movementRight;
    [Range(0f, 500f)]
    public float speed = 500;
    Vector3 jump;
    [Range(0f, 1000f)]
    public float Jump = 1000;

    Transform touched;
    public GameObject Push;
    GameObject currentPush;
    bool canPush;
    
    // Use this for initialization
    void Start()
    {
        movementUp = new Vector3(0, 0, speed);
        movementRight = new Vector3(speed, 0, 0);
        playerRB = GetComponent<Rigidbody>();
        jump = new Vector3(0, Jump, 0);
        canPush = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Timer.game)
        {
            if (Input.GetKey(KeyCode.W))
            {
                playerRB.AddForce(movementUp * Time.fixedDeltaTime);
            }
            if (Input.GetKey(KeyCode.D))
            {
                playerRB.AddForce(movementRight * Time.fixedDeltaTime);
            }
            if (Input.GetKey(KeyCode.A))
            {
                playerRB.AddForce(-movementRight * Time.fixedDeltaTime);
            }
            if (Input.GetKey(KeyCode.S))
            {
                playerRB.AddForce(-movementUp * Time.fixedDeltaTime);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                playerRB.AddForce(jump * Time.deltaTime);
            }

            if (Input.GetMouseButtonDown(0) && canPush)
            {
                currentPush = Instantiate(Push, transform.position, transform.rotation);
                StartCoroutine("Force");
                canPush = false;
            }
        }

        if (!Timer.game)
        {
            playerRB.velocity = Vector3.zero;
        }

        currentPush.transform.localScale += new Vector3(25f, 25f, 25f) * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag != "Wall")
        {
            touched = collision.transform.parent;
            int count = touched.childCount;

            for(int i =0; i < count; i++)
            {
                Transform child = touched.GetChild(i);
                Rigidbody part = child.GetComponent<Rigidbody>();
                part.isKinematic = false;
            }
        }
    }

    IEnumerator Force()
    {
        
        yield return new WaitForSeconds(0.1f);
        Destroy(currentPush.gameObject);
        yield return new WaitForSeconds(2f);
        canPush = true;
    }
}
