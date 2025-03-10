using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.Rendering;

public class sideways : MonoBehaviour
{
    public float distance;
    public player_MV player;
    public float speed;
    bool moveLeft;
    float leftedge;
    float rightedge;

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
    if (collision.CompareTag("Player")) // Ensure Player has the correct tag
    {
        player.grounded=true;
        Vector3 originalScale=collision.transform.localScale;
        collision.transform.SetParent(transform); // Attach player to platform
        collision.transform.localScale=originalScale;
    }
}

    void OnTriggerExit2D(Collider2D collision)
{
    if (collision.CompareTag("Player")&& gameObject.activeInHierarchy)
    {
      collision.transform.SetParent(null);
        player.grounded=false;
         // Detach player from platform
    }
}

}
