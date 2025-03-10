using UnityEngine;

public class attacks : MonoBehaviour
{
    public Animator anim;
    public swordHit sw;
    public player_MV mv;
    public float attackCooldown;
    float cooldownTimer=5f;

    void Update()
    {
        if(Input.GetMouseButton(0)&&cooldownTimer>attackCooldown){
            Attack();
        }
        cooldownTimer+=Time.deltaTime;
    }
    void Attack(){
        anim.SetTrigger("atck");
        sw.ActivateHit();
        cooldownTimer=0;
    }
}
