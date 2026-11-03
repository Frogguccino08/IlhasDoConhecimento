using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarMenu : MonoBehaviour
{
    PersonagemSelecionado pc;
    void Start()
    {
        StartCoroutine(AcharSave());
        pc = PersonagemSelecionado.instance;
        pc.isTutorial = false;
    }

    public void Selecao()
    {
        SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
    }

    public void MotorBarco()
    {
        SceneManager.LoadScene("Motor", LoadSceneMode.Single);
    }

    public void StartTutorial()
    {
        pc.regiao = 5;
        pc.perso = pc.persos[3];
        pc.isTutorial = true;
        SceneManager.LoadScene("Combate", LoadSceneMode.Single);
    }

    IEnumerator AcharSave()
    {
        yield return new WaitForSeconds(0.2f);
        InfoPlayer.instance.CarregarInfo();
    }
}
