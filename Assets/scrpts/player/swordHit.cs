using UnityEngine;

public class swordHit : MonoBehaviour
{
    public GameObject sword;
    public float attackDuration;
    public BoxCollider2D swordColl;
    public void ActivateHit(){
        sword.SetActive(true);
        swordColl.enabled=true;
        Invoke("stopSword",attackDuration);
    }
    void stopSword(){
        sword.SetActive(false);
        swordColl.enabled=false;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit!");
        {
            
        }
    }
}
