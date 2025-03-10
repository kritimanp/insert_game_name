using Unity.Mathematics;
using UnityEngine;

public class player_MV : MonoBehaviour
{
    public Rigidbody2D obj;//to refer to the player
    public LayerMask groundLayer;
    public Animator anim;
    public float speed;
    public float jump;
    public BoxCollider2D boxColl;//for raycast(to recognise if the player is on a wall)
    float playerDirection;
    float wallJumpCooldown=1f;
    public AudioClip jumpSound;

    public bool grounded;
    void Update()
    {
     playerDirection=Input.GetAxis("Horizontal");//gives 1, 0 or -1 depending on the player input.
     //if right arrow->1
     //if left-arrow->-1
     if(playerDirection>0.01f)
     transform.localScale=new Vector3(5f,5f,1f);
     else if(playerDirection<-0.01f)
     transform.localScale=new Vector3(-5f,5f,1f);//flip the player to face left direction

     anim.SetBool("run",playerDirection!=0);//if the player is moving, it will set run bool to true
     anim.SetBool("grounded", isGrounded());// if isGrounded() returns true, it will set grounded to true.
     anim.SetBool("fall",obj.linearVelocity.y<-0.1f && (!isGrounded()));
     
     if(wallJumpCooldown>0.2){
        obj.linearVelocity=new Vector2(speed*playerDirection, obj.linearVelocity.y);//if player moving on the ground
        if(onWall()&&!isGrounded()){
            obj.gravityScale=1;
            obj.linearVelocity=new Vector2(-obj.linearVelocity.x*0.5f,-1f);//while sticking to a wall, the player comes down gradually and
            //has a small force in the opposite direction in the x axis
        }
        else{
            obj.gravityScale=2;//normally gravity of 2 units will apply
        }

        if(Input.GetKeyDown(KeyCode.Space))
        Jump();
     }
     else{
        wallJumpCooldown+=Time.deltaTime;
     }
    }

    void Jump(){
        if(isGrounded()){
            obj.linearVelocity=new Vector2(obj.linearVelocity.x,jump);
            soundManager.instance.PlaySound(jumpSound);
            anim.SetTrigger("jmp");
        }
        else if(onWall()&&!isGrounded()){
            wallJumpCooldown=0;//to prevent the player from jumping continuosly
            obj.linearVelocity=new Vector2(-Mathf.Sign(transform.localScale.x)*5,8);//in case localScale.x is 5, Mathf.Sign will give 1
            //in case localScale is -5, Mathf.Sign will give -1. the negative sign makes sure to apply the horizontal velocity in the opposite
            //direction wrt the player. the player jumps with a vertical velocity of 6
            soundManager.instance.PlaySound(jumpSound);
            anim.SetTrigger("jmp");
        }
    }

    public bool isGrounded(){
        RaycastHit2D raycastHit=Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0, Vector2.down, 0.2f, groundLayer);
         if (raycastHit.collider != null | grounded==true)
    {
        return true;
    }

    // Extra check: If player is still a child of a platform, consider them grounded
    if (transform.parent != null && transform.parent.CompareTag("platf"))
    {
        return true;
    }

    return false;//if the raycastHit is not null; i.e hitting the groundLayer, isGrounded is true
    }

    bool onWall(){
        RaycastHit2D raycastHit=Physics2D.BoxCast(boxColl.bounds.center, boxColl.bounds.size, 0, new Vector2(Mathf.Sign(transform.localScale.x),0),0.1f,groundLayer);
        return raycastHit.collider!=null;
    }

    public bool canAttack(){
        return playerDirection==0 && !isGrounded();
    }
}
