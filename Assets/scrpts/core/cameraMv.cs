//using System.Numerics;
using UnityEngine;

public class cameraMv : MonoBehaviour
{
    /*public player_MV player;
    public Vector2 offset;
    void Update()
    {
        transform.position=new Vector3(player.transform.position.x+offset.x,player.transform.position.y+offset.y,
        transform.position.z);
    }*/
    public float followSpeed=2f;
    public float yoffset=1f;
    public Transform player;

    void Update()
    {
        Vector3 newpos=new Vector3(player.position.x,player.position.y+yoffset,-10f);
        transform.position=Vector3.Slerp(transform.position,newpos,followSpeed*Time.deltaTime);
    }
    public void instantMoveToCheckpoint(Vector3 checkpointPos){
        transform.position=new Vector3(checkpointPos.x,checkpointPos.y+yoffset,-10f);
    }
}
