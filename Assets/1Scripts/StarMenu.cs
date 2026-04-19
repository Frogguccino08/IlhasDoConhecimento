using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarMenu : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(AcharSave());
    }

    public void historia()
    {
        PersonagemSelecionado.instance.isHistoria = true;
        SceneManager.LoadScene("Mapa", LoadSceneMode.Single);
    }

    public void Selecao()
    {
        PersonagemSelecionado.instance.isHistoria = false;
        SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
    }

    public void MotorBarco()
    {
        SceneManager.LoadScene("Motor", LoadSceneMode.Single);
    }

    IEnumerator AcharSave()
    {
        yield return new WaitForSeconds(0.2f);
        InfoPlayer.instance.CarregarInfo();
    }
}
