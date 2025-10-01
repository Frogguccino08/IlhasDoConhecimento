using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class Controle : MonoBehaviour
{
    //Variaveis
    public int turno = 0;
    public int inimigoAtual = 1;
    public bool paraEsperar = false;
    public bool processguir;
    public bool pulouTurno = false;

    public int pontosRodada;

    //Para a tela de vitória
    public GameObject CanvaVitoria;
    public TMP_Text textoComemorativo;
    public bool vitoriaOn = false;

    //Chamados de outros Objetos
    public Player player;
    public Butao[] butao = new Butao[6];
    public GameObject skipButton;
    public GameObject[] imgButao = new GameObject[6];
    public Enemy enemy;
    public TMP_Text texto;
    public ConhecimentoControl conhecimento;
    public TMP_Text pontMax;
    public TMP_Text inimigoTurno;
    public bool telaSair = false;

    public GameObject descricao;
    public GameObject descricaoGrande;
    public string efeitoAtq;

    public PersonagemSelecionado escolha;
    public TMP_Text textoArea;

    public GameObject textoRegiao;
    public GameObject telaCompleta;
    public GameObject[] oPlayer = new GameObject[2];
    public GameObject[] oEnemy = new GameObject[2];


    //Função start que sempre inicia no turno aliado e também mostra o texto da região e inicializa o player e o inimigo
    void Start()
    {
        escolha = PersonagemSelecionado.instance;
        player.InicializarPlayer();

        StartCoroutine(LigarTela());
    }

    //Espera mostrar a região e depois liga todas as coisas
    public IEnumerator LigarTela()
    {
        textoRegiao.SetActive(true);
        telaCompleta.SetActive(false);
        oPlayer[0].SetActive(false);
        oEnemy[0].SetActive(false);
        oPlayer[1].SetActive(false);
        oEnemy[1].SetActive(false);

        switch (escolha.regiao)
        {
            case 0: //costa
                textoRegiao.GetComponent<TMP_Text>().text = "Costa de Cacos";
                break;
            case 1: //coração
                textoRegiao.GetComponent<TMP_Text>().text = "Coração da Ilha";
                break;
            case 2: //comunidade
                textoRegiao.GetComponent<TMP_Text>().text = "Comunidade Abandonada";
                break;
            case 3: //arquivos
                textoRegiao.GetComponent<TMP_Text>().text = "Os arquivos";
                break;
            case 4: //floresta
                textoRegiao.GetComponent<TMP_Text>().text = "Floresta Composta";
                break;
        }

        yield return new WaitForSeconds(3);

        textoRegiao.SetActive(false);
        telaCompleta.SetActive(true);
        oPlayer[0].SetActive(true);
        oEnemy[0].SetActive(true);
        oPlayer[1].SetActive(true);
        oEnemy[1].SetActive(true);

        texto.enabled = false;
        enemy.InicializarInimigo();
        AtualizarEstadoBotoes();
        StartCoroutine(Turno(true));
        Debug.Log("Combate iniciou");

        if (inimigoAtual == 1)
        {
            pontosRodada = 0;
        }

        inimigoTurno.text = "Inimigo: " + inimigoAtual + "       Turno: " + turno;
        textoArea.text = "Pontuação:\n " + pontosRodada;
    }

    //Função responsável por trocar de turno
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
        inimigoTurno.text = "Inimigo: " + inimigoAtual + "       Turno: " + turno;
    }

    //O nome é turno inimigo porém essa função lida também com o final do turno aliado além do turno inimigo
    IEnumerator ExecutarTurnoInimigo()
    {
        DesativarBotao();

        if (enemy.currentHealth <= 0)
        {
            player.butaoClicado = false;
            DesativarBotao();

            texto.enabled = true;
            yield return EsperarTeclaEspaco();

            player.EfeitoCausado(1, player.attackPublic, (int)player.danoPublic);
            if (player.currentHealth <= 0)
            {
                player.cor.enabled = false;
                player.GetComponent<SpriteRenderer>().enabled = false;
                yield return StartCoroutine(player.Morto());
                inimigoAtual = 1;
                inimigoTurno.text = "Inimigo: " + inimigoAtual + "       Turno: " + turno;
                yield return EsperarTeclaEspaco();
                PersonagemSelecionado.instance.Resetar();
                SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
                yield break;
            }

            if (player.efeitosUsados[16]) yield return EsperarTeclaEspaco();

            if (player.currentHealth > 0)
            {
                player.EfeitoCausado(2, player.attackPublic, (int)player.danoPublic);
                if (player.efeitosUsados[18]) yield return EsperarTeclaEspaco();
            }

            player.EfeitoCausado(3, player.attackPublic, (int)player.danoPublic);

            enemy.GetComponent<SpriteRenderer>().enabled = false;
            enemy.cor.enabled = false;
            StartCoroutine(enemy.Morto());
            AtualizarEstadoBotoes();
            inimigoAtual++;
            inimigoTurno.text = "Inimigo: " + inimigoAtual + "       Turno: " + turno;
            yield break;
        }

        // Início da lógica de ataque do jogador
        texto.enabled = true;
        yield return EsperarTeclaEspaco();

        if (pulouTurno == true)
        {
            yield return EsperarTeclaEspaco();
        }

        //Escrever o efeito na tela
        if (player.temEfeito[player.idAtaqueUsado] == true && pulouTurno == false)
        {
            texto.text = efeitoAtq;
            yield return EsperarTeclaEspaco();
        }

        if (player.efeitosAtivos[7] > 0)
            player.quantBlock = player.efeitosAtivos[1];

        player.list.AtaquesComEfeitos(true, (escolha.regiao + 1) * -1, 4, player, enemy);
        player.list.AtaquesComEfeitos(true, (escolha.perso.id + 10) * -1, 4, player, enemy);

        if (pulouTurno == false)
        {
            player.list.AtaquesComEfeitos(true, player.ataqueUsado, 4, player, enemy);
        }

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
            int num = player.efeitosAtivos[1] - player.quantBlock;
            player.efeitosAtivos[1] = player.quantBlock;

            for (int i = 0; i < num; i++)
            {
                if (player.efeitosAtivos[7] > 0)
                {
                    player.efeitosAtivos[7] -= 1;
                }
                else
                {
                    player.efeitosAtivos[1] += 1;
                }
            }
        }

        player.EfeitoCausado(1, player.attackPublic, (int)player.danoPublic);
        if (turno > 1)
        {
            enemy.EfeitoCausado(3, enemy.attackPublic, (int)enemy.danoPublic);
        }

        if (player.efeitosUsados[16]) yield return EsperarTeclaEspaco();

        if (player.currentHealth <= 0)
        {
            player.cor.enabled = false;
            player.GetComponent<SpriteRenderer>().enabled = false;
            yield return StartCoroutine(player.Morto());
            inimigoAtual = 1;
            inimigoTurno.text = "Inimigo: " + inimigoAtual + "       Turno: " + turno;
            yield return EsperarTeclaEspaco();
            PersonagemSelecionado.instance.Resetar();
            SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
            yield break;
        }

        player.EfeitoCausado(2, player.attackPublic, (int)player.danoPublic);
        if (player.efeitosUsados[18]) yield return EsperarTeclaEspaco();

        player.EfeitoCausado(3, player.attackPublic, (int)player.danoPublic);

        if (pulouTurno == true)
        {
            pulouTurno = false;
        }


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


        // Efeito inicio do turno inimigo
        enemy.list.AtaquesComEfeitos(false, (escolha.regiao + 1) * -1, 9, player, enemy);
        player.list.AtaquesComEfeitos(true, (escolha.perso.id + 10) * -1, 10, player, enemy);
        enemy.list.AtaquesComEfeitos(false, enemy.ataqueUsado, 9, player, enemy);
        for (int i = 0; i < 6; i++)
        {
            if (enemy.isPassive[i])
                enemy.list.AtaquesComEfeitos(false, enemy.attackID[i], 9, player, enemy);
        }

        for (int i = 0; i < 6; i++)
        {
            if (player.isPassive[i])
                player.list.AtaquesComEfeitos(true, player.attackID[i], 10, player, enemy);
        }

        player.list.AtaquesComEfeitos(true, player.attackID[player.idAtaqueUsado], 10, player, enemy);

        //Após escolher o ataque
        enemy.EscolherAtaque();
        enemy.list.AtaquesComEfeitos(false, (escolha.regiao + 1) * -1, 0, player, enemy);

        texto.enabled = true;
        yield return EsperarTeclaEspaco();

        //Escrever o efeito na tela
        if (enemy.temEfeito[enemy.idAtaqueUsado] == true && enemy.maximo != 0 && enemy.pulouTurno == false)
        {
            texto.text = efeitoAtq;
            yield return EsperarTeclaEspaco();
        }

        if (enemy.efeitosAtivos[7] > 0)
            enemy.quantBlock = enemy.efeitosAtivos[1];

        enemy.list.AtaquesComEfeitos(false, (escolha.regiao + 1) * -1, 4, player, enemy);
        player.list.AtaquesComEfeitos(true, (escolha.perso.id + 10) * -1, 5, player, enemy);
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
            int num = enemy.efeitosAtivos[1] - enemy.quantBlock;
            enemy.efeitosAtivos[1] = enemy.quantBlock;

            for (int i = 0; i < num; i++)
            {
                if (enemy.efeitosAtivos[7] > 0)
                {
                    enemy.efeitosAtivos[7] -= 1;
                }
                else
                {
                    enemy.efeitosAtivos[1] += 1;
                }
            }
        }

        enemy.EfeitoCausado(1, enemy.attackPublic, (int)enemy.danoPublic);
        //player.EfeitoCausado(3, player.attackPublic, (int)player.danoPublic);
        if (enemy.efeitosUsados[16] && enemy.currentHealth > 0) yield return EsperarTeclaEspaco();

        if (enemy.currentHealth <= 0)
        {
            enemy.cor.enabled = false;
            enemy.GetComponent<SpriteRenderer>().enabled = false;
            enemy.cor.enabled = false;
            inimigoAtual++;
            StartCoroutine(enemy.Morto());
            AtualizarEstadoBotoes();
            StartCoroutine(Turno(false));
            turno = 0;
            inimigoTurno.text = "Inimigo: " + inimigoAtual + "       Turno: " + turno;
            yield break;
        }

        enemy.EfeitoCausado(2, enemy.attackPublic, (int)enemy.danoPublic);
        if (enemy.efeitosUsados[18]) yield return EsperarTeclaEspaco();

        // Verifica se o jogador morreu
        if (player.currentHealth <= 0)
        {
            player.cor.enabled = false;
            player.GetComponent<SpriteRenderer>().enabled = false;
            texto.enabled = true;
            yield return StartCoroutine(player.Morto());
            inimigoAtual = 1;
            inimigoTurno.text = "Inimigo: " + inimigoAtual + "       Turno: " + turno;
            yield return EsperarTeclaEspaco();
            PersonagemSelecionado.instance.Resetar();
            SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
            yield break;
        }

        // Se o jogador sobreviveu, volta o turno
        texto.enabled = false;
        AtivarBotao();

        player.list.AtaquesComEfeitos(true, (escolha.regiao + 1) * -1, 9, player, enemy);
        player.list.AtaquesComEfeitos(true, (escolha.perso.id + 10) * -1, 9, player, enemy);

        for (int i = 0; i < 6; i++)
        {
            if (player.isPassive[i])
                player.list.AtaquesComEfeitos(true, player.attackID[i], 9, player, enemy);
        }

        for (int i = 0; i < 6; i++)
        {
            if (enemy.isPassive[i])
                enemy.list.AtaquesComEfeitos(false, enemy.attackID[i], 10, player, enemy);
        }

        enemy.list.AtaquesComEfeitos(false, enemy.attackID[enemy.idAtaqueUsado], 10, player, enemy);

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


    //Função que espera o jogador selecionar algo na tela de upgrade antes de processeguir
    public IEnumerator TelaUpgrade()
    {
        processguir = false;

        while (processguir == false)
        {
            yield return null;
        }
    }


    //Função que confere se o botão dos ataques pode ser clicado ou não
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

    //Função que desativa os botões de ataque
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

    //Função que ativa os botões de ataque
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

    //Função responsável por fazer o jogo esperar o botão ser clicado para continuar quando tem um texto na tela
    public IEnumerator EsperarTeclaEspaco()
    {
        paraEsperar = true;

        while (!Input.GetKeyUp(KeyCode.Space) && !Input.GetKeyUp(KeyCode.Mouse0))
            yield return null;

        yield return new WaitForSeconds(0.01f);
        paraEsperar = false;
    }

    //Função que remove o aviso para o programa que o ataque foi utilizado
    public void AtaqueFeito()
    {
        for (int i = 0; i < 6; i++)
        {
            butao[i].ataqueUtilizado = false;
        }
    }

    //Função que coloca a quantidade de pontos quando você derrota um inimigo
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
            pontMax.text = "Pontuação Máxima: " + pontosRodada;
        }
    }

    //Função para aparecer uma tela de vitória
    public IEnumerator TelaVitoria()
    {
        escolha.pontos = pontosRodada;
        CanvaVitoria.SetActive(true);

        telaCompleta.SetActive(false);
        textoRegiao.SetActive(true);
        oPlayer[0].SetActive(false);
        oEnemy[0].SetActive(false);
        oPlayer[1].SetActive(false);
        oEnemy[1].SetActive(false);

        CanvaVitoria.GetComponent<TelaVitoria>().ColocarNome();

        while (!Input.GetKeyUp(KeyCode.Escape) && !Input.GetKeyUp(KeyCode.KeypadEnter) && vitoriaOn != false)
        {
            yield return null;
        }

        PersonagemSelecionado.instance.Resetar();
        SceneManager.LoadScene("Selecao", LoadSceneMode.Single);
    }
}