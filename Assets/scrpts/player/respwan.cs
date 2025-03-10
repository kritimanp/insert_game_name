using UnityEngine;

public class respwan : MonoBehaviour
{
    public Transform currentCheckpoint;
    //public player_MV player;
    public health playerHealth;
    public cameraMv cam;
    public void respawn(){
        transform.position=currentCheckpoint.position;//move player to the checkpoint position
        playerHealth.Respawn();
        cam.instantMoveToCheckpoint(currentCheckpoint.position);
    }
}
