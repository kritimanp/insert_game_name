using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class health : MonoBehaviour
{
    public Transform pfall;
    public float starthealth;
    bool dead=false;
    public float currhealth;
    public player_MV player;
    public Animator anim;
    public AudioClip trapSound, diesound;
    void Awake()
    {
        currhealth=starthealth;
    }
    void Update()
    {
        if(pfall.position.y<-20f){
            anim.SetTrigger("die");
            player.enabled=false;//stops movement
            soundManager.instance.PlaySound(diesound);
            dead=true;
            Object.FindAnyObjectByType<respwan>().respawn();
            }
    }
    

    public void TakeDamage(float damage){
        currhealth=Mathf.Clamp(currhealth-damage,0,starthealth);//sets up a range from 0 to starthealth

        if(currhealth>0){
            anim.SetTrigger("hurt");
            soundManager.instance.PlaySound(trapSound);
        }
        else{
            if(!dead){
                anim.SetTrigger("die");
                player.enabled=false;//stops movement
                soundManager.instance.PlaySound(diesound);
                dead=true;}//so that it does not repeat
            }
    }

    public void Respawn(){
        dead=false;
        gainLife(starthealth);
        anim.ResetTrigger("die");
        anim.Play("Idle");
        player.enabled=true;
    }
    public void gainLife(float life){
        if(currhealth<starthealth && life!=starthealth){
            currhealth=currhealth+life;
        }
        else
        currhealth=starthealth;
    }
    }
