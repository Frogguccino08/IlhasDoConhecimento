using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TelaUpgrade : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Chamados de outros objetos
    public Controle control;
    public GameObject oProprio;
    public Player player;
    public AttacksEfeitos list;
    public AttacksList lista;
    public Butao[] butoes = new Butao[6];

    public TelaUpgrade[] osDois = new TelaUpgrade[2];

    public GameObject telaInicial;
    public GameObject telaAtributos;
    public GameObject telaAtaques;
    public GameObject telaAtaquesAntigos;

    public TMP_Text texto;
    public GameObject fundo;

    public GameObject desc;

    //Variáveis
    public int idAtaque;
    public int idAtaqueAntigo;

    public int ataque;


    //Função colocada no botão de pular, adiciona pontos e vai pro proximo turno
    public void Pular()
    {
        player.telaUpgradeOn = false;
        control.pontosRodada += 150;
        control.textoArea.text = "Pontuação:\n" + control.pontosRodada;

        control.processguir = true;
        oProprio.SetActive(false);

        if (control.pontosRodada > control.escolha.pontos)
        {
            control.escolha.pontos = control.pontosRodada;
            control.pontMax.text = "Pontuação Máxima: " + control.escolha.pontos;
        }
    }

    //Botão de voltar de todas as telas de volta para a tela inicial do upgrade
    public void Voltar()
    {
        telaInicial.SetActive(true);
        telaAtributos.SetActive(false);
        telaAtaques.SetActive(false);
        telaAtaquesAntigos.SetActive(false);
    }

    //Função que abre a tela de atributos
    public void Atributos()
    {
        telaInicial.SetActive(false);
        telaAtributos.SetActive(true);
        telaAtaques.SetActive(false);
    }

    //Função que abre a tela de novos ataques
    public void Ataques()
    {
        telaInicial.SetActive(false);
        telaAtributos.SetActive(false);
        telaAtaques.SetActive(true);
    }

    //Função que aumenta um atributo baseado em qual botão você clicar
    public void AtributoIncrease(int i)
    {
        switch (i)
        {
            case 0:
                player.maxHealth += 25;
                player.currentHealth = player.maxHealth;
                player.healthbar.MaximoVida(player.maxHealth);
                player.text.text = player.currentHealth + "/" + player.maxHealth;
                player.healthbar.MudarBarra(player.currentHealth);

                control.processguir = true;
                oProprio.SetActive(false);
                break;
            case 1:
                player.maxCharge += 1;
                player.controlConheci.SpawnConhecimento(player.maxCharge, player.currentCharge);

                control.processguir = true;
                oProprio.SetActive(false);
                break;
            case 2:
                player.phiDamage += 1;

                control.processguir = true;
                oProprio.SetActive(false);
                break;
            case 3:
                player.speDamage += 1;

                control.processguir = true;
                oProprio.SetActive(false);
                break;
            case 4:
                player.phiDefense += 1;

                control.processguir = true;
                oProprio.SetActive(false);
                break;
            case 5:
                player.speDefense += 1;

                control.processguir = true;
                oProprio.SetActive(false);
                break;
        }
    }

    //Botão que escolhe quais ataques vão aparecer na parte de ataques
    public void FazerAtaques()
    {
        do
        {
            idAtaque = player.pc.listaAtaquesAprendiveis[UnityEngine.Random.Range(0, player.pc.listaAtaquesAprendiveis.Length)];
        } while (osDois[0].idAtaque == idAtaque || osDois[1].idAtaque == idAtaque || idAtaque == player.attackID[0] || idAtaque == player.attackID[1] || idAtaque == player.attackID[2] || idAtaque == player.attackID[3] || idAtaque == player.attackID[4] || idAtaque == player.attackID[5]);
        Attacks ataqueA = lista.CriarAtaques(idAtaque);
        Debug.Log(idAtaque);
        Debug.Log(ataqueA);

        texto.text = ataqueA.nome;

        if (ataqueA.material == 0)
            {
                //Sem material
                fundo.GetComponent<Image>().color = new Color32(147, 115, 80, 255);
            }
            else if (ataqueA.material == 1)
            {
                //Papel
                fundo.GetComponent<Image>().color = new Color32(65, 105, 225, 255);
            }
            else if (ataqueA.material == 2)
            {
                //Plastico
                fundo.GetComponent<Image>().color = new Color32(155, 17, 30, 255);
            }
            else if (ataqueA.material == 3)
            {
                //Vidro
                fundo.GetComponent<Image>().color = new Color32(0, 100, 0, 255);
            }
            else if (ataqueA.material == 4)
            {
                //Metal
                fundo.GetComponent<Image>().color = new Color32(238, 173, 45, 255);
            }
            else if (ataqueA.material == 5)
            {
                //Organico
                fundo.GetComponent<Image>().color = new Color32(120, 64, 8, 255);
            }

        ataque = idAtaque;
    }

    //Função que faz mostrar os ataques antigos quando você clica em um ataque e já está sem espaço para novos ataques
    public void FazerAtaquesAntigo(int idzinho)
    {
        idAtaqueAntigo = player.attackID[idzinho];
        Attacks ataqueA = lista.CriarAtaques(idAtaqueAntigo);

        texto.text = ataqueA.nome;

        if (ataqueA.material == 0)
        {
            //Nenhum ataque
            fundo.GetComponent<Image>().color = new Color32(147, 115, 80, 255);
        }
        else if (ataqueA.material == 1)
        {
            //Papel
            fundo.GetComponent<Image>().color = new Color32(65, 105, 225, 255);
        }
        else if (ataqueA.material == 2)
        {
            //Plastico
            fundo.GetComponent<Image>().color = new Color32(155, 17, 30, 255);
        }
        else if (ataqueA.material == 3)
        {
            //Vidro
            fundo.GetComponent<Image>().color = new Color32(0, 100, 0, 255);
        }
        else if (ataqueA.material == 4)
        {
            //Metal
            fundo.GetComponent<Image>().color = new Color32(238, 173, 45, 255);
        }
        else if (ataqueA.material == 5)
        {
            //Organico
            fundo.GetComponent<Image>().color = new Color32(120, 64, 8, 255);
        }

        ataque = idAtaqueAntigo;
    }

    //Função ao clicar em um ataque novo coloca no proximo espaço livre ou abre a tela de ataques antigos
    public void ClicouAtaqueNovo()
    {
        if (player.attackID[5] != 0)
        {
            oProprio.GetComponent<TelaUpgrade>().idAtaque = idAtaque;
            telaAtaquesAntigos.SetActive(true);
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                if (player.attackID[i] == 0)
                {
                    player.attackID[i] = idAtaque;

                    player.AtaquesSelecionados();


                    butoes[i].ColocandoAtaque(i);

                    control.processguir = true;
                    player.telaUpgradeOn = false;
                    oProprio.SetActive(false);

                    break;
                }
            }
        }
    }

    //Função de mudar o ataque antigo para o novo quando clicar nele
    public void ClicouAtaqueSubstituir()
    {
        player.attackID[idAtaque] = oProprio.GetComponent<TelaUpgrade>().idAtaque;
        player.AtaquesSelecionados();

        for (int o = 0; o < 6; o++)
        {
            butoes[o].ColocandoAtaque(o);
        }

        control.processguir = true;
        player.telaUpgradeOn = false;
        oProprio.SetActive(false);
        telaAtaques.SetActive(false);
        telaAtaquesAntigos.SetActive(false);
    }

    //Função aparecer descrição dos ataques quando passar o mouse por cima
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (desc != null)
        {
            desc.GetComponent<Descricao>().BotandoDescricao(ataque);
            desc.SetActive(true);
        }
    }

    //Função para sumir a descrição para tirar o mouse
    public void OnPointerExit(PointerEventData eventData)
    {
        if (desc != null)
        {
            desc.SetActive(false);
        }
    }
}
