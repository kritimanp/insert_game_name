using UnityEngine;

public class life : MonoBehaviour
{
    public health playerHealth;
    public AudioClip gainHeart;
    public float heart;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"){
            playerHealth.gainLife(heart);
            soundManager.instance.PlaySound(gainHeart);
            gameObject.SetActive(false);

        }
    }

}
