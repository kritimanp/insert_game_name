using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class uiManager : MonoBehaviour
{
    public GameObject pauseSreen;
    void Awake()
    {
        pauseSreen.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(pauseSreen.activeInHierarchy)
            PauseGame(false);
            else
            PauseGame(true);
        }
    }
    public void PauseGame(bool status){
        if(status==true){
           Time.timeScale=0;     
           pauseSreen.SetActive(true);}
        else{
            Time.timeScale=1;
            pauseSreen.SetActive(false);}
    }
    public void Restart(){
        Time.timeScale=1;
        StartCoroutine(RestartAfterDelay());
    }
    IEnumerator RestartAfterDelay()
    {
        yield return new WaitForSeconds(0.5f); // Short delay to allow scene to reset
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu(){
        SceneManager.LoadScene(0);
    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }

}
