using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    public void StartGame(){
        Time.timeScale=1;
        SceneManager.LoadScene("SampleScene");
    }
}
