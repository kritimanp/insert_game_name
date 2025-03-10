using UnityEngine;

public class winning : MonoBehaviour
{
    public collectible coll;
    public GameObject winScreen;
    void Awake()
    {
        winScreen.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player" && coll.stolen==true){
            winScreen.SetActive(true);
            Debug.Log("won");
        }
    }
}
