//using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class health1 : MonoBehaviour
{
    public health playerHealth;
    public Image totalHealth;
    public Image currentHealth;
    public void Start()
    {
        totalHealth.fillAmount=playerHealth.currhealth/10;
    }

    void Update()
    {
        currentHealth.fillAmount=playerHealth.currhealth/10;
    }
}
