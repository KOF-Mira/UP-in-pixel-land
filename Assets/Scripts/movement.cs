using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    Rigidbody2D MyRB;
    int playerstate; //0 is standing, 1 is walking (holding down horizontal movement), 2 is braking (friction is applied)
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
            MyRB.velocity = new Vector2(0f,0f);
        }
        if (Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A))
        {
            playerstate = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MyRB.AddForce(Vector2.right);
        }
        print("playerstate is ..." + playerstate);
    }
}
