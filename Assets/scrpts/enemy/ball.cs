using UnityEngine;

public class ball : MonoBehaviour
{
    public player_MV player;
    public float distance;
    public float damage;
    public float speed;
    public health playerHealth;
    float leftedge;
    float rightedge;
    bool moveLeft;

    void Awake()
    {
        leftedge=transform.position.x-distance;
        rightedge=transform.position.x+distance;
    }
    void Update()
    {
        if(moveLeft){
            if(transform.position.x>leftedge){
            transform.position=new Vector3(transform.position.x-speed*Time.deltaTime,transform.position.y,transform.position.z);
            }
            else{
                moveLeft=false;
            }
        }
        else{
            if(transform.position.x<rightedge){
            transform.position=new Vector3(transform.position.x+speed*Time.deltaTime,transform.position.y,transform.position.z);
            }
            else{
                moveLeft=true;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"){
            playerHealth.TakeDamage(damage);
        }
    }
}
