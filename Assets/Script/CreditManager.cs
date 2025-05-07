using UnityEngine;
using UnityEngine.UI;

public class CreditManager : MonoBehaviour
{
    [SerializeField] private GameObject creditPanel; //อิงCreditPanel
    [SerializeField] private GameObject uiPanel; //UIหลักที่ต้องซ่อน

    void Start()
    {
        creditPanel.SetActive(false); // ซ่อนเครดิต
    }

    public void ShowCredits()
    {
        creditPanel.SetActive(true);  //เปิกเครดิต
        uiPanel.SetActive(false); //ซ่อน UI 
        Time.timeScale = 0;
    }

    public void HideCredits()
    {
        creditPanel.SetActive(false); 
        uiPanel.SetActive(true);
        Time.timeScale = 1;
    }
}
