using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Controle : MonoBehaviour
{
    public int turno = 0;
    public int inimigoAtual = 1;
    public bool paraEsperar = false;
    public bool processguir;
    public bool pulouTurno = false;

    public int pontosRodada;

    public Player player;
    public Butao[] butao = new Butao[6];
    public GameObject skipButton;
    public GameObject[] imgButao = new GameObject[6];
    public Enemy enemy;
    public TMP_Text texto;
    public ConhecimentoControl conhecimento;
    public TMP_Text pontMax;
    public TMP_Text inimigoTurno;

    public GameObject descricao;
    public GameObject descricaoGrande;

    public PersonagemSelecionado escolha;
    public TMP_Text textoArea;

    void Start()
    {
        escolha = PersonagemSelecionado.instance;
        StartCoroutine(TextoRegiao());

        texto.enabled = false;
        player.InicializarPlayer();
        enemy.InicializarInimigo();
        AtualizarEstadoBotoes();
        StartCoroutine(Turno(true));
        Debug.Log("Combate iniciou");

        pontosRodada = 0;

        inimigoTurno.text = "Inimigo: " + inimigoAtual +"       Turno: " + turno;
    }

    public IEnumerator Turno(bool isTurnoAliado)
    {
        if (turno != 0)
        {
            if (isTurnoAliado)
            {
                AtualizarEstadoBotoes();
                texto.enabled = false;
            }
            else
            {
                yield return StartCoroutine(ExecutarTurnoInimigo());
            }
        }

        turno++;
        inimigoTurno.text = "Inimigo: " + inimigoAtual +"       Turno: " + turno;
    }

    IEnumerator ExecutarTurnoInimigo()
    {
        DesativarBotao();
        
        if (enemy.currentHealth <= 0)
        {
            DesativarBotao();

            texto.enabled = true;
            yield return EsperarTeclaEspaco();

            player.EfeitoCausado(1, player.attackPublic, (int)player.danoPublic);
            if (player.currentHealth <= 0)
            {
                yield return StartCoroutine(player.Morto());
                inimigoAtual = 1;
                inimigoTurno.text = "Inimigo: " + inimigoAtual + "       Turno: " + turno;
                yield return EsperarTeclaEspaco();
                PersonagemSelecionado.instance.Resetar();
                SceneManager.LoadScene("SelecaoPersonagem", LoadSceneMode.Single);
                yield break;
            }

            if (player.efeitosUsados[16]) yield return EsperarTeclaEspaco();

            if (player.currentHealth > 0)
            {
                player.EfeitoCausado(2, player.attackPublic, (int)player.danoPublic);
                if (player.efeitosUsados[18]) yield return EsperarTeclaEspaco();
            }

            StartCoroutine(enemy.Morto());
            AtualizarEstadoBotoes();
            inimigoAtual++;
            inimigoTurno.text = "Inimigo: " + inimigoAtual + "       Turno: " + turno;
            yield break;
        }

        // Início da lógica de ataque do jogador
        texto.enabled = true;
        yield return EsperarTeclaEspaco();

        if (player.efeitosAtivos[7] > 0)
            player.quantBlock = player.efeitosAtivos[1];

        player.list.AtaquesComEfeitos(true, player.ataqueUsado, 4, player, enemy);
        for (int i = 0; i < 6; i++)
        {
            if (player.isPassive[i])
                player.list.AtaquesComEfeitos(true, player.attackID[i], 4, player, enemy);
        }

        for (int i = 0; i < 6; i++)
        {
            if (enemy.isPassive[i])
                enemy.list.AtaquesComEfeitos(false, enemy.attackID[i], 5, player, enemy);
        }

        if (player.efeitosAtivos[7] > 0 && player.quantBlock < player.efeitosAtivos[1])
        {
            player.efeitosAtivos[1] = player.quantBlock;
            Debug.Log("Você está exposto, não pode mais bloquear");
        }

        player.EfeitoCausado(1, player.attackPublic, (int)player.danoPublic);
        if (player.efeitosUsados[16]) yield return EsperarTeclaEspaco();

        if (player.currentHealth <= 0)
        {
            yield return StartCoroutine(player.Morto());
            inimigoAtual = 1;
            inimigoTurno.text = "Inimigo: " + inimigoAtual +"       Turno: " + turno;
            yield return EsperarTeclaEspaco();
            PersonagemSelecionado.instance.Resetar();
            SceneManager.LoadScene("SelecaoPersonagem", LoadSceneMode.Single);
            yield break;
        }

        player.EfeitoCausado(2, player.attackPublic, (int)player.danoPublic);
        if (player.efeitosUsados[18]) yield return EsperarTeclaEspaco();

        // Turno do inimigo
        if (turno != 2 && turno != 1)
        {
            enemy.currentCharge = Mathf.Min(enemy.currentCharge + 2, enemy.maxCharge);
            
            if (enemy.efeitosAtivos[6] > 0)
        {
            enemy.currentCharge += 1;
            enemy.efeitosAtivos[6] -= 1;
        }
        if (enemy.efeitosAtivos[12] > 0)
        {
            enemy.currentCharge -= 1;
            enemy.efeitosAtivos[12] -= 1;
        }
        }
        enemy.EscolherAtaque();

        texto.enabled = true;
        yield return EsperarTeclaEspaco();

        if (enemy.efeitosAtivos[7] > 0)
            enemy.quantBlock = enemy.efeitosAtivos[1];

        enemy.list.AtaquesComEfeitos(false, enemy.ataqueUsado, 4, player, enemy);
        for (int i = 0; i < 6; i++)
        {
            if (enemy.isPassive[i])
                enemy.list.AtaquesComEfeitos(false, enemy.attackID[i], 4, player, enemy);
        }

        for (int i = 0; i < 6; i++)
        {
            if (player.isPassive[i])
                player.list.AtaquesComEfeitos(true, player.attackID[i], 5, player, enemy);
        }

        if (enemy.efeitosAtivos[7] > 0 && enemy.quantBlock < enemy.efeitosAtivos[1])
        {
            enemy.efeitosAtivos[1] = enemy.quantBlock;
            Debug.Log("Você está exposto, não pode mais bloquear");
        }

        enemy.EfeitoCausado(1, enemy.attackPublic, (int)enemy.danoPublic);
        if (enemy.efeitosUsados[16]) yield return EsperarTeclaEspaco();

        enemy.EfeitoCausado(2, enemy.attackPublic, (int)enemy.danoPublic);
        if (enemy.efeitosUsados[18]) yield return EsperarTeclaEspaco();

        // Verifica se o jogador morreu
        if (player.currentHealth <= 0)
        {
            texto.enabled = true;
            yield return StartCoroutine(player.Morto());
            inimigoAtual = 1;
            inimigoTurno.text = "Inimigo: " + inimigoAtual +"       Turno: " + turno;
            yield return EsperarTeclaEspaco();
            PersonagemSelecionado.instance.Resetar();
            SceneManager.LoadScene("SelecaoPersonagem", LoadSceneMode.Single);
            yield break;
        }

        // Se o jogador sobreviveu, volta o turno
        texto.enabled = false;
        AtivarBotao();

        player.currentCharge = Mathf.Min(player.currentCharge + 2, player.maxCharge);
        if (player.efeitosAtivos[6] > 0)
        {
            player.currentCharge += 1;
            player.efeitosAtivos[6] -= 1;
        }
        if (player.efeitosAtivos[12] > 0)
        {
            player.currentCharge -= 1;
            player.efeitosAtivos[12] -= 1;
        }

        conhecimento.SpawnConhecimento(player.maxCharge, player.currentCharge);

        AtualizarEstadoBotoes();
    }


    public IEnumerator TelaUpgrade()
    {
        processguir = false;

        while(processguir == false)
        {
            yield return null;
        }
    }


    void AtualizarEstadoBotoes()
    {
        for (int i = 0; i < 6; i++)
        {
            butao[i].id = i;
            butao[i].ColocandoAtaque(i);

            bool ativo = player.attackID[i] != 0;

            var botaoUI = butao[i].GetComponent<Button>();
            var imagem = butao[i].GetComponent<Image>();

            botaoUI.interactable = ativo;
            imagem.raycastTarget = ativo;
        }
    }

    public void DesativarBotao()
    {
        for (int i = 0; i < 6; i++)
        {
            imgButao[i].SetActive(false);
            butao[i].GetComponent<Button>().enabled = false;
        }

        skipButton.SetActive(false);
        descricao.SetActive(false);
        descricaoGrande.SetActive(false);
        
    }

    public void AtivarBotao()
    {
        for (int i = 0; i < 6; i++)
        {
            imgButao[i].SetActive(true);
            butao[i].GetComponent<Button>().enabled = true;
            butao[i].ColocandoAtaque(i);
            AtualizarEstadoBotoes();
        }

        skipButton.SetActive(true);
    }

    public IEnumerator EsperarTeclaEspaco()
    {
        paraEsperar = true;

        while (!Input.GetKeyUp(KeyCode.Space) && !Input.GetKeyUp(KeyCode.Mouse0))
            yield return null;

        yield return new WaitForSeconds(0.01f);
        paraEsperar = false;
    }

    IEnumerator TextoRegiao()
    {
        switch (escolha.regiao)
        {
            case 0: //costa
                textoArea.text = "Costa de Cacos";
                break;
            case 1: //coração
                textoArea.text = "Coração da Ilha";
                break;
            case 2: //comunidade
                textoArea.text = "Comunidade Abandonada";
                break;
            case 3: //arquivos
                textoArea.text = "Os arquivos";
                break;
            case 4: //floresta
                textoArea.text = "Floresta Composta";
                break;
        }

        yield return new WaitForSeconds(3);
        textoArea.text = "Pontuação:\n " + pontosRodada;
    }

    public void AtaqueFeito()
    {
        for(int i = 0; i < 6; i++)
        {
            butao[i].ataqueUtilizado = false;
        }
    }

    public void ColocarPontosInimigoDerrotado()
    {
        if (player.currentHealth == player.maxHealth)
        {
            pontosRodada += 200;
        }
        pontosRodada += 100;
        pontosRodada += 500 / ((turno / 2) + 1);

        textoArea.text = "Pontuação:\n " + pontosRodada;

        if (pontosRodada > escolha.pontos)
        {
            escolha.pontos = pontosRodada;
            pontMax.text = "Pontuação Máxima: " + escolha.pontos;
        }
    }
}