using UnityEngine;

public class CreditotoMenu : MonoBehaviour
{
    public GameObject canvaMenu;
    public GameObject canvaCreditos;

    public bool actProducao = false;

    public void ReturnMenu()
    {
        if(actProducao)
        {
            canvaMenu.SetActive(true);
            canvaCreditos.SetActive(false);
            actProducao = false;
        }
        else
        {
            canvaMenu.SetActive(false);
            canvaCreditos.SetActive(true);
            actProducao = true;
        }
    }
}
