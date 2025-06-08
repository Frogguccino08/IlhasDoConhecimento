using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Efeitos : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int TuOuOutro;
    public int quantos = 0;
    public int quantosProPos;
    public int quantosProTam;
    public string txt;

    public GameObject efeitos;
    public TMP_Text texto;

    public Player player;
    public Enemy enemy;

    public void OnPointerEnter(PointerEventData eventData)
    {
        quantos = 0;
        efeitos.SetActive(true);
        texto.text = "";

        if (TuOuOutro == 0)
        {
            for (int i = 2; i < 19; i++)
            {
                if (player.efeitosAtivos[i] > 0)
                {
                    quantos += 1;

                    switch (i)
                    {
                        case 2:
                            txt = "+ DefDis";
                            break;
                        case 3:
                            txt = "+ DefFis";
                            break;
                        case 4:
                            txt = "+ AtqDis";
                            break;
                        case 5:
                            txt = "+ AtqFis";
                            break;
                        case 6:
                            txt = "+ Conhec";
                            break;
                        case 7:
                            txt = "- Exposto";
                            break;
                        case 8:
                            txt = "- AtqDis";
                            break;
                        case 9:
                            txt = "- AtqFis";
                            break;
                        case 10:
                            txt = "- DefDis";
                            break;
                        case 11:
                            txt = "- DefFis";
                            break;
                        case 12:
                            txt = "- Conhec";
                            break;
                        case 16:
                            txt = "Cacos";
                            break;
                        case 18:
                            txt = "Nutrindo";
                            break;
                    }

                    texto.text += txt + " " + player.efeitosAtivos[i] + "\n";

                }
            }

            if (texto.text == "")
            {
                texto.text = "Sem efeito ativo";
            }

            quantosProPos = quantos;
            quantosProTam = quantos;

            if (quantos == 0)
            {
                quantosProTam = 1;
            }
            if (quantos == 1)
            {
                quantosProPos = 0;
            }
            else if (quantos > 1)
            {
                quantosProPos = quantos - 1;
            }

            efeitos.transform.position = new Vector3(efeitos.transform.position.x, efeitos.transform.position.y + (0.25f * quantosProPos), efeitos.transform.position.z);
            efeitos.GetComponent<RectTransform>().sizeDelta = new Vector2(3.5f, 0.5f * quantosProTam);
        }
        else if (TuOuOutro == 1)
        {
            for (int i = 2; i < 19; i++)
            {
                if (enemy.efeitosAtivos[i] > 0)
                {
                    quantos += 1;

                    switch (i)
                    {
                        case 2:
                            txt = "+ DefDis";
                            break;
                        case 3:
                            txt = "+ DefFis";
                            break;
                        case 4:
                            txt = "+ AtqDis";
                            break;
                        case 5:
                            txt = "+ AtqFis";
                            break;
                        case 6:
                            txt = "+ Conhec";
                            break;
                        case 7:
                            txt = "- Exposto";
                            break;
                        case 8:
                            txt = "- AtqDis";
                            break;
                        case 9:
                            txt = "- AtqFis";
                            break;
                        case 10:
                            txt = "- DefDis";
                            break;
                        case 11:
                            txt = "- DefFis";
                            break;
                        case 12:
                            txt = "- Conhec";
                            break;
                        case 16:
                            txt = "Cacos";
                            break;
                        case 18:
                            txt = "Nutrindo";
                            break;
                    }

                    texto.text += enemy.efeitosAtivos[i] + " " + txt + "\n";

                }
            }

            if (texto.text == "")
            {
                texto.text = "Sem efeito ativo";
            }

            quantosProPos = quantos;
            quantosProTam = quantos;

            if (quantos == 0)
            {
                quantosProTam = 1;
            }
            if (quantos == 1)
            {
                quantosProPos = 0;
            }
            else if (quantos > 1)
            {
                quantosProPos = quantos - 1;
            }

            efeitos.transform.position = new Vector3(efeitos.transform.position.x, efeitos.transform.position.y + (0.25f * quantosProPos), efeitos.transform.position.z);
            efeitos.GetComponent<RectTransform>().sizeDelta = new Vector2(3.5f, 0.5f * quantosProTam);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        efeitos.SetActive(false);

        if (TuOuOutro == 0)
        {
            efeitos.transform.position = new Vector3(transform.position.x + 2.40f, transform.position.y, transform.position.z);
            efeitos.GetComponent<RectTransform>().sizeDelta = new Vector2(3.5f, 0.5f);
            texto.text = "";
        }
        else if (TuOuOutro == 1)
        {
            efeitos.transform.position = new Vector3(transform.position.x + -2.4f, transform.position.y, transform.position.z);
            efeitos.GetComponent<RectTransform>().sizeDelta = new Vector2(3.5f, 0.5f);
            texto.text = "";
        }
    }
}
