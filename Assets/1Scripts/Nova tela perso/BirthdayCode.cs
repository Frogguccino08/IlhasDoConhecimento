using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class BirthdayCode : MonoBehaviour
{
    //Códigos
    //0714 Yoko
    //

    public TMP_Text text;
    public bool codigoZerado = true;
    public PCsSO pc;
    public TelaSelecao tela;

    void Update()
    {
        StartCoroutine(Codigo());
    }

    IEnumerator Codigo()
    {
        if(Input.GetKeyUp(KeyCode.Alpha0) || Input.GetKeyUp(KeyCode.Keypad0))
        {
            text.GetComponent<TMP_Text>().enabled = true;
            text.text += "0";
        }
        else if(Input.GetKeyUp(KeyCode.Alpha1) || Input.GetKeyUp(KeyCode.Keypad1))
        {
            text.GetComponent<TMP_Text>().enabled = true;
            text.text += "1";
        }
        else if(Input.GetKeyUp(KeyCode.Alpha2) || Input.GetKeyUp(KeyCode.Keypad2))
        {
            text.GetComponent<TMP_Text>().enabled = true;
            text.text += "2";
        }
        else if(Input.GetKeyUp(KeyCode.Alpha3) || Input.GetKeyUp(KeyCode.Keypad3))
        {
            text.GetComponent<TMP_Text>().enabled = true;
            text.text += "3";
        }
        else if(Input.GetKeyUp(KeyCode.Alpha4) || Input.GetKeyUp(KeyCode.Keypad4))
        {
            text.GetComponent<TMP_Text>().enabled = true;
            text.text += "4";
        }
        else if(Input.GetKeyUp(KeyCode.Alpha5) || Input.GetKeyUp(KeyCode.Keypad5))
        {
            text.GetComponent<TMP_Text>().enabled = true;
            text.text += "5";
        }
        else if(Input.GetKeyUp(KeyCode.Alpha6) || Input.GetKeyUp(KeyCode.Keypad6))
        {
            text.GetComponent<TMP_Text>().enabled = true;
            text.text += "6";
        }
        else if(Input.GetKeyUp(KeyCode.Alpha7) || Input.GetKeyUp(KeyCode.Keypad7))
        {
            text.GetComponent<TMP_Text>().enabled = true;
            text.text += "7";
        }
        else if(Input.GetKeyUp(KeyCode.Alpha8) || Input.GetKeyUp(KeyCode.Keypad8))
        {
            text.GetComponent<TMP_Text>().enabled = true;
            text.text += "8";
        }
        else if(Input.GetKeyUp(KeyCode.Alpha9) || Input.GetKeyUp(KeyCode.Keypad9))
        {
            text.GetComponent<TMP_Text>().enabled = true;
            text.text += "9";
        }

        if(text.text.Length == 4)
        {
            text.color = Color.red;
            yield return new WaitForSeconds(1);
            ChecarCodigo();
            text.text = "";
        }
    }

    void ChecarCodigo()
    {
        string codigo = text.text;

        if(codigo == "0302" || codigo == "6942") //Adicionar código aqui com um ||
        {
            text.color = Color.red;
            StartCoroutine(CodigoCerto());
        }
        else
        {
            text.text = "";
        }
    }

    IEnumerator CodigoCerto()
    {
        string codigo = text.text;

        yield return StartCoroutine(Comemoracao());

        if(codigo == "6942")
        {
            InfoPlayer.instance.HardReset();
        }
        if(codigo == "0302")
        {
            InfoPlayer.instance.unlock[5] = true;
        }
        //Adicionar aqui personagem novo que seja por código
        
        foreach (GameObject obj in tela.persosDesc)
        {
            Destroy(obj);
        }
        tela.persosDesc.Clear();
        foreach (PCsSO boneco in PersonagemSelecionado.instance.persos)
        {
            tela.ColocarPersonagem(boneco);
        }

        text.text = "";
        text.color = Color.black;
        InfoPlayer.instance.SalvarInfo();
    }

    IEnumerator Comemoracao()
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
    }
}