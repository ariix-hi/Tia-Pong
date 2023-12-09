using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControls : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public Vector2 resetPosition;

    void GoBall(){
        float rand = Random.Range(0, 2);
        if(rand < 1){
            rb2d.AddForce(new Vector2(20, -15));
        } else {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }
    // Start is called before the first frame update
    void Start(){
        rb2d =  GetComponent<Rigidbody2D>();
        Invoke("GoBall",2);

    }

    void OnCollisionEnter2D(Collision2D coll) {
        if(coll.collider.CompareTag("player")){
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

    public void ResetBall()
    {
        transform.position = resetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
