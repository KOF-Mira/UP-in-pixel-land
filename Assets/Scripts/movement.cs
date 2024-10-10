using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D MyRB;
    int playerstate; //0 is standing, 1 is walking (holding down horizontal movement), 2 is braking (friction is applied), 3 is not grounded
    Vector2 playervelocity;
    public float stopmagnitude;

    // Start is called before the first frame update
    void Start()
    {
        MyRB = this.GetComponent<Rigidbody2D>();
        playerstate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        playervelocity = MyRB.velocity;
        if (playervelocity.magnitude < stopmagnitude && playervelocity.magnitude > -stopmagnitude)
        {
            playerstate = 0;
            playervelocity = new Vector2(0f,0f);
        }
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A) && playervelocity.y > 0f)
        {
            playerstate = 1;
        }
        if (playervelocity.y != 0f)
        {
            playerstate = 3;
        }
        if (Input.GetKey(KeyCode.Space) && playervelocity.y < stopmagnitude * 3 && playervelocity.y > -stopmagnitude * 3)
        {
            playervelocity = new Vector2(0f,10f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MyRB.AddForce(Vector2.right);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MyRB.AddForce(Vector2.left);
        }
        print("playerstate is ..." + playerstate);
        MyRB.velocity = playervelocity;
    }
}
