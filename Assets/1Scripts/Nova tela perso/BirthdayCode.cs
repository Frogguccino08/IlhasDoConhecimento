using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirthdayCode : MonoBehaviour
{
    public TMP_Text text;
    public bool codigoZerado = true;
    public PCsSO pc;
    public TelaSelecao tela;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha0) && codigoZerado == true)
        {
            codigoZerado = false;
            StartCoroutine(Codigo());
        }
    }

    IEnumerator Codigo()
    {
        text.GetComponent<TMP_Text>().enabled = true;
        text.text += "0";

        while (!Input.GetKeyUp(KeyCode.Alpha7) && codigoZerado == false)
        {
            yield return null;
        }

        text.GetComponent<TMP_Text>().enabled = true;
        text.text += "7";

        while (!Input.GetKeyUp(KeyCode.Alpha1) && codigoZerado == false)
        {
            yield return null;
        }

        text.GetComponent<TMP_Text>().enabled = true;
        text.text += "1";

        while (!Input.GetKeyUp(KeyCode.Alpha4) && codigoZerado == false)
        {
            yield return null;
        }

        text.GetComponent<TMP_Text>().enabled = true;
        text.text += "4";

        StartCoroutine(CodigoCerto());
        yield break;

    }

    IEnumerator CodigoCerto()
    {
        text.color = Color.red;
        yield return new WaitForSeconds(1);

        text.text = "Code Activated!!!";

        for (int i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.5f);
            if (text.GetComponent<TMP_Text>().enabled == false)
            {
                text.GetComponent<TMP_Text>().enabled = true;
            }
            else
            {
                text.GetComponent<TMP_Text>().enabled = false;
            }
        }

        yield return new WaitForSeconds(0.3f);
        PersonagemSelecionado.instance.unlock[5] = true;
        foreach (GameObject obj in tela.persosDesc)
        {
            Destroy(obj);
        }
        tela.persosDesc.Clear();
        foreach (PCsSO boneco in tela.perso)
        {
            tela.ColocarPersonagem(boneco);
        }
    }
}