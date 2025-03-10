using UnityEngine;

public class caution : MonoBehaviour
{
    bool cauti=false;
    public GameObject cautionScreen;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"){
            cauti=true;
            cautionScreen.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag=="Player"){
            cauti=false;
            cautionScreen.SetActive(false);
        }
    }
}
