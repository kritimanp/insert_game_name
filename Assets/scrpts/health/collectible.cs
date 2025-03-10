using UnityEngine;

public class collectible : MonoBehaviour
{
    public AudioClip collected;
    public bool stolen=false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"){
            soundManager.instance.PlaySound(collected);
            gameObject.SetActive(false);
            stolen=true;
        }
    }
}
