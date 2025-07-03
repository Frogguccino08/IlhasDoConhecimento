using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Descricao : MonoBehaviour
{
    //Chamado de outros objetos
    public AttackList list;
    public PersonagemSelecionado perso;
    public Player player;
    public Scene cena;

    //Chamado de objetos dentro da própria descrição
    public TMP_Text nomeAtq;
    public TMP_Text material;
    public Image imgMaterial;
    public TMP_Text phispepas;
    public TMP_Text carga;
    public TMP_Text dano;
    public TMP_Text desc;

    //Variável
    public int rEmConta = 0;


    //Função responsável por toda a parte de escrever toda a descrição
    public void BotandoDescricao(int id)
    {
        cena = SceneManager.GetActiveScene();
        if (cena.name == "Combate")
        {
            player = GameObject.Find("Player").GetComponent<Player>();
        }

        perso = PersonagemSelecionado.instance;
        list.CriarAtaque(id);

        nomeAtq.text = list.nome;

        switch (list.material)
        {
            case 0:
                material.text = "Material";

                if (perso.perso != null)
                {
                    switch (perso.perso.material)
                    {
                        default:
                            material.text = "Material";
                            break;
                        case 1:
                            material.text = "Papel";
                            break;
                        case 2:
                            material.text = "Plástico";
                            break;
                        case 3:
                            material.text = "Vidro";
                            break;
                        case 4:
                            material.text = "Metal";
                            break;
                        case 5:
                            material.text = "Orgânico";
                            break;
                    }
                }

                break;
            case 1:
                material.text = "Papel";
                break;
            case 2:
                material.text = "Plástico";
                break;
            case 3:
                material.text = "Vidro";
                break;
            case 4:
                material.text = "Metal";
                break;
            case 5:
                material.text = "Orgânico";
                break;
        }

        if (list.isPassiva == true)
        {
            phispepas.enabled = true;
            phispepas.text = "Pas";
        }
        else
        {
            if (list.phispe == true && list.dano != 0)
            {
                phispepas.enabled = true;
                phispepas.text = "Fís";
            }
            else if (list.phispe == false && list.dano != 0)
            {
                phispepas.enabled = true;
                phispepas.text = "Dis";
            }
            else if (list.dano == 0)
            {
                phispepas.enabled = false;
            }
        }

        carga.text = "Carga: " + list.carga;

        if (list.dano != 0)
        {
            if (player == null)
            {
                dano.enabled = true;
                dano.text = list.quantidade + " x " + list.dano;
                dano.color = Color.black;
            }
            else
            {
                dano.enabled = true;
                if (list.phispe == true)
                {
                    dano.text = list.quantidade + " x " + (list.dano + player.modPhiDamage + rEmConta);

                    if (list.dano > list.dano + player.modPhiDamage + rEmConta)
                    {
                        dano.color = Color.red;
                    }
                    else if (list.dano < list.dano + player.modPhiDamage + rEmConta)
                    {
                        dano.color = Color.green;
                    }
                    else
                    {
                        dano.color = Color.black;
                    }
                }
                else
                {
                    dano.text = list.quantidade + " x " + (list.dano + player.modSpeDamage + rEmConta);

                    if (list.dano > list.dano + player.modSpeDamage + rEmConta && list.dano > 0)
                    {
                        dano.color = Color.red;
                    }
                    else if (list.dano > list.dano + player.modSpeDamage + rEmConta && list.dano < 0)
                    {
                        dano.color = Color.green;
                    }
                    else if (list.dano < list.dano + player.modSpeDamage + rEmConta && list.dano > 0)
                    {
                        dano.color = Color.green;
                    }
                    else if (list.dano < list.dano + player.modSpeDamage + rEmConta && list.dano < 0)
                    {
                        dano.color = Color.red;
                    }
                    else
                    {
                        dano.color = Color.black;
                    }
                }

            }

        }
        else
        {
            dano.enabled = false;
        }

        desc.text = list.desc;
    }
}
