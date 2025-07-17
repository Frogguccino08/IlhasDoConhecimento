using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Butao : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    //Variavel que precisa
    public int id;
    public bool ataqueUtilizado = false;

    //Chamado de outros Objetos
    public Player player;
    public Enemy enemy;
    public TMP_Text text;
    public Controle control;

    public GameObject desc;

    //Coloca o nome do ataque no botão, deixa ele desativado ou não caso tiver como, e chama a função de mudar a cor
    public void ColocandoAtaque(int id)
    {
        text.text = player.nome[id];
        MudarCor(id);

        if (player.attackID[id] == 0)
        {
            this.GetComponent<Button>().interactable = false;
        }
        else
        {
            this.GetComponent<Button>().interactable = true;
            this.GetComponent<Image>().raycastTarget = true;
        }
    }

    //Muda a cor do botão baseado no material
    public void MudarCor(int id)
    {
        int cor;
        cor = player.material[id];
        if (player.material[id] == 0)
        {
            cor = player.materialPlayer;
        }

        if (player.nome[id] == "- -")
            {
                //Nenhum ataque
                this.GetComponent<Image>().color = new Color32(147, 115, 80, 255);
            }
            else if (cor == 1)
            {
                //Papel
                if (player.isPassive[id] == true || player.currentCharge < player.carga[id])
                {
                    this.GetComponent<Image>().color = new Color32(51, 58, 99, 255);
                }
                else
                {
                    this.GetComponent<Image>().color = new Color32(65, 105, 225, 255);
                }

            }
            else if (cor == 2)
            {
                //Plastico
                if (player.isPassive[id] == true || player.currentCharge < player.carga[id])
                {
                    this.GetComponent<Image>().color = new Color32(86, 7, 13, 255);
                }
                else
                {
                    this.GetComponent<Image>().color = new Color32(155, 17, 30, 255);
                }
            }
            else if (cor == 3)
            {
                //Vidro
                if (player.isPassive[id] == true || player.currentCharge < player.carga[id])
                {
                    this.GetComponent<Image>().color = new Color32(0, 54, 0, 255);
                }
                else
                {
                    this.GetComponent<Image>().color = new Color32(0, 100, 0, 255);
                }

            }
            else if (cor == 4)
            {
                //Metal
                if (player.isPassive[id] == true || player.currentCharge < player.carga[id])
                {
                    this.GetComponent<Image>().color = new Color32(136, 98, 22, 255);
                }
                else
                {
                    this.GetComponent<Image>().color = new Color32(238, 173, 45, 255);
                }
            }
            else if (cor == 5)
            {
                //Organico
                if (player.isPassive[id] == true || player.currentCharge < player.carga[id])
                {
                    this.GetComponent<Image>().color = new Color32(90, 78, 53, 255);
                }
                else
                {
                    this.GetComponent<Image>().color = new Color32(120, 64, 8, 255);
                }
            }
    }


    //Função para quando clicar escolher o ataque
    public void Onclick()
    {
        if (player.isPassive[id] == false && player.currentCharge >= player.carga[id])
        {
            StartCoroutine(player.UsarAtaque(id));
            ataqueUtilizado = true;
        }
    }

    //Função responsável pela carga R e 3R
    public IEnumerator EsperandoR()
    {
        if (player.nome[id] != "- -")
        {
            ataqueUtilizado = false;

            if (Input.GetKeyDown(KeyCode.Mouse0) && player.currentR > 0)
            {
                yield return new WaitForSeconds(1);
                if (Input.GetKey(KeyCode.Mouse0))
                {
                    player.usingR = true;
                    Debug.Log("Carga R usada");
                    if (player.dano[id] < 0)
                    {
                        desc.GetComponent<Descricao>().rEmConta = -1;
                    }
                    else if (player.dano[id] > 0)
                    {
                        desc.GetComponent<Descricao>().rEmConta = 1;
                    }
                    desc.GetComponent<Descricao>().BotandoDescricao(player.attackID[id]);

                    if (player.currentR == 3)
                    {
                        yield return new WaitForSeconds(1);
                        if (Input.GetKey(KeyCode.Mouse0))
                        {
                            player.usingR = false;
                            player.using3R = true;
                            Debug.Log("3R Usado");
                            desc.GetComponent<Descricao>().rEmConta = 0;
                            desc.GetComponent<Descricao>().BotandoDescricao(player.attackID[id]);
                        }
                        else
                        {
                            Debug.Log("Carga cortada");
                            player.usingR = false;
                            player.using3R = false;
                            desc.GetComponent<Descricao>().rEmConta = 0;
                            desc.GetComponent<Descricao>().BotandoDescricao(player.attackID[id]);
                            yield break;

                        }
                    }
                }
                else
                {
                    Debug.Log("Carga cortada");
                    player.usingR = false;
                    player.using3R = false;
                    desc.GetComponent<Descricao>().rEmConta = 0;
                    desc.GetComponent<Descricao>().BotandoDescricao(player.attackID[id]);
                    yield break;
                }

                while (!Input.GetKeyUp(KeyCode.Mouse0))
                {
                    desc.GetComponent<Descricao>().rEmConta = 0;
                    yield return null;
                }

                if (ataqueUtilizado == true)
                {
                    desc.GetComponent<Descricao>().rEmConta = 0;
                    yield break;
                }
                else
                {
                    Debug.Log("Carga cortada");
                    player.usingR = false;
                    player.using3R = false;
                    desc.GetComponent<Descricao>().rEmConta = 0;
                    desc.GetComponent<Descricao>().BotandoDescricao(player.attackID[id]);
                    yield break;
                }
            }
        }
    }

    //Função que faz segurar o botão começar a carga R
    public void OnPointerDown(PointerEventData eventData)
    {
        if (player.isPassive[id] == false && player.currentCharge >= player.carga[id])
        {
            StartCoroutine(EsperandoR());
        }
    }

    //Função de aparecer a descrição quando passa o mouse por cima
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (desc != null)
        {
            desc.GetComponent<Descricao>().BotandoDescricao(player.attackID[id]);
            desc.SetActive(true);
        }
    }

    //Função de sumir a descrição ao tirar o mouse
    public void OnPointerExit(PointerEventData eventData)
    {
        if (desc != null)
        {
            desc.SetActive(false);
        }
    }
}