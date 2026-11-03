using UnityEngine;
using UnityEngine.UI;

public class DiagTutorial : MonoBehaviour
{
    Escrever diagBox;
    public Controle control;
    [SerializeField] Butao[] bts = new Butao[6];
    [SerializeField] GameObject btSkip;

    void Start()
    {
        diagBox = Escrever.instance.GetComponent<Escrever>();
    }

    //Função que coloca o dialogo ou quando inicia o turno ou quando acaba o turno (sem o inimigo morrer, precisa de outra para isso)
    public void ColocarDialogo(bool hora, int turno)
    {
        switch (turno)
        {
            case 1:
                if(hora)
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0, 0, 0, 0});
                    diagBox.NovoDialogo(new string[]
                    {"Bem-Vindo ao mundo de \"Ilhas do Conhecimento\" (Clique em qualquer lugar da tela para seguir).",
                    "Vamos a algumas explicações, O personagem a esquerda é você e a direita é uma criatura corrompida (Seu Inimigo).",
                    "Você precisa purifica-lo, para fazer isso você precisa abaixar a barra de vida dele a zero. A barra de vida do inimigo sendo a da direita, fique de olho também na sua a esquerda.",
                    "A baixo logo atrás desse dialogo fica os ataques do seu personagem, selecione o primeiro."});
                }
                break;
            case 2:
                if(hora)
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0, 0, 0});
                    diagBox.NovoDialogo(new string[]
                    {"Muito bem! Se você ver em baixo da sua vida há alguns quadrados azuis, aquela é sua \"Carga de Conhecimento\".",
                    "Passando com o mouse por cima de um ataque você consegue ver as informações dele, para usar um ataque você precisa ter carga o suficiente. A quantidade certa fica marcada em \"Carga\" na descrição do ataque.",
                    "A cada turno você recuperá 2 de carga, queremos usar o \"Ataque Pesado\" porém não temos carga. Vamos pular o turno para recuperar a carga mais rápido."});
                }
                break;
            case 3:
                if(hora)
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0});
                    diagBox.NovoDialogo(new string[]
                    {"Ótimo, agora use o ataque pesado."});
                }
                break;
            case 4:
                if(hora)
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0, 0, 0});
                    diagBox.NovoDialogo(new string[]
                    {"Você tomou bastante dano, eu recomendária bloquear.",
                    "Bloquear impede que você tome dano de ataques, porém cuidado, outros efeitos te afetam mesmo com bloqueio.",
                    "Embaixo da sua barra de vida a direita mostra quantos bloqueios você tem ativo. Use o ataque \"Bloquear\"."});
                }
                else
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0, 0, 0});
                    diagBox.NovoDialogo(new string[]
                    {"Observe no seu ataque pesado que o dano está descrito como \"2x2\", isso significa que o ataque acerta duas vezes com 2 de dano.",
                    "O primeiro número sendo a quantidade de golpes e o segundo o dano.",
                    "Bloqueios apenas defendem 1 golpe. Se você tiver com 2 bloqueios e o inimigo te atingir com um golpe 3x2 você ainda tomará 1 dano."});
                }
                break;
            case 5:
                if(hora)
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0, 0, 0});
                    diagBox.NovoDialogo(new string[]
                    {"Sempre que você usa um ataque que causa dano você recebe uma \"Carga R\".",
                    "A carga R faz seus ataques ficarem mais fortes, e caso ele tenha algum efeito adicional ele também é aumentado",
                    "Você pode usar uma Carga R em qualquer ataque, para fazer isso segure o botão do ataque ao invés de apenas clicar."});
                }
                else
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0, 0, 0});
                    diagBox.NovoDialogo(new string[]
                    {"Caso você escolha esperar por 3 de Carga R, você pode usar o \"3R\" segurando o botão do ataque até todos os Rs ficarem iluminados.",
                    "Ao utilizar o 3R, você usa o ataque selecionado duas vezes.",
                    "Isso é algo muito poderoso, escolha bem quando utilizar a carga R."});
                }
                break;
            case 6:
                if(hora)
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0, 0, 0, 0, 0});
                    diagBox.NovoDialogo(new string[]
                    {"Tanto seu personagem, quanto a região que você está, tem habilidades passivas.",
                    "Habilidades passivas são efeitos que acontecem quando um critério é alcançado sem você precisar clicar em nada.",
                    "Sempre que uma passiva acontecer um aviso irá aparecer no centro da tela por um momento.",
                    "Para checar a sua habilidade e da região passe o mouse por cima da barra de vida do seu personagem.",
                    "Junto com essas informações também é mostrado seus atributos, como dano físico e a distância, defesa e entre outros."});
                }
                else
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0});
                    diagBox.NovoDialogo(new string[]
                    {"Parece que o inimigo usou um ataque de efeito."});
                }
                break;
            case 7:
                if(hora)
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0, 0, 0, 0});
                    diagBox.NovoDialogo(new string[]
                    {"Ataques de efeitos adicionam ao seu personagem ou ao inimigo uma redução ou aumento de atributo.",
                    "No caso do utilizado contra você foi uma redução de dano físico.",
                    "Esses efeitos tem uma quantidade exata que diminue ou aumenta, ao usar mais de um desses efeitos você continua com a mesma quantidade de redução ou aumento",
                    "Você pode ver quantos efeitos você tem ou o inimigo tem passando o mouse por cima do botão \"E\" de cada lado da tela."});
                }
                else
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0});
                    diagBox.NovoDialogo(new string[]
                    {"Ao utilizar mais de um ataque de efeito igual a quantidade de turnos que o efeito ficarrá ativo se acumulam."});
                }
                break;
            case 8:
                if(hora)
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0, 0, 0});
                    diagBox.NovoDialogo(new string[]
                    {"Existem 3 tipos de ataque:\nAtaques físicos que usam dano físico e o alvo se defende com defesa física.\nAtaques a distância que usam dano a distância e o alvo se defende com defesa a distância.\nE Passivas que acontecem automaticamente.",
                    "Para ver qual deles um ataque é basta ver em sua descrição, passando o mouse por cima do ataque.\n\"Fis\" são ataques físicos,\n\"Dis\" são ataques a distância,\n\"Pas\" são passivas.",
                    "Tenha certeza de utilizar ataques que os seus atributos sejam maiores."});
                }
                else
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0, 0});
                    diagBox.NovoDialogo(new string[]
                    {"Agora vou demonstrar fraquezas para você. para isso mudarei o material do inimigo.",
                    "Observe a cor dele"});
                }
                break;
            case 9:
                if(hora)
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0, 0});
                    diagBox.NovoDialogo(new string[]
                    {"Papel é fraco contra metal, fazendo ele receber um segundo dano pequeno após cada ataque de dano de metal.",
                    "Tente usar um ataque de dano de metal nele."});
                }
                else
                {
                    control.emDialogo = true;
                    diagBox.NovoPersonagens(new int[]{0, 0, 0, 0});
                    diagBox.NovoDialogo(new string[]
                    {"Clicando \"ESC\" no seu teclado você abre o menu do jogo onde você pode ver todas as fraquezas.",
                    "Para saber o seu material, material do inimigo ou material do seu ataque siga o mesmo esquema de cor que está no menu de fraquezas.",
                    "Um lembrete importante, usar ataques do mesmo material que você aumentam o dano do ataque, e você é resistênte contra o mesmo material que você.",
                    "Agora termine de purificar esse inimigo!"});
                }
                break;
        }
    }

    public void DialogoPurificou()
    {
        control.emDialogo = true;
        diagBox.NovoPersonagens(new int[]{0, 0, 0, 0});
        diagBox.NovoDialogo(new string[]
        {"Muito bem!",
        "No primeiro inimigo e após isso a cada 2 que você purificar, você recebe uma melhoria de personagem.",
        "Nela você pode escolher aumentar um atributo do seu personagem, ou ganhar um novo ataque.",
        "Fique a vontade de escolher, e se os ataques não forem do seu agrado, uma vez por jogatína e +1 por cada chefão que você derrotar, você pode rerolar os ataques para aparecer outros."});
    }

    public void DialogoFinal()
    {
        control.emDialogo = true;
        diagBox.NovoPersonagens(new int[]{0, 0, 0, 0});
        diagBox.NovoDialogo(new string[]
        {"Parabéns! Você finalizou o tutorial do jogo.",
        "Agora clicando em \"Jogar\" no menu te colocará no jogo de verdade.",
        "Apenas escolha o seu personagem e purifique a ilha!",
        "Caso tenha alguma dúvida sobre o jogo o tutorial se manterá disponível sempre para vocè relembrar as mecânicas."});
    }

    public void InteracaoBt()
    {
        switch(control.turno)
        {
            case 1:
                bts[0].ativoTutorial = true;
                bts[1].ativoTutorial = false;
                bts[2].ativoTutorial = false;
                bts[3].ativoTutorial = true;
                bts[4].ativoTutorial = true;
                bts[5].ativoTutorial = true;
                btSkip.GetComponent<Button>().interactable = false;
                break;
            case 2:
                bts[0].ativoTutorial = false;
                bts[1].ativoTutorial = false;
                bts[2].ativoTutorial = false;
                bts[3].ativoTutorial = true;
                bts[4].ativoTutorial = true;
                bts[5].ativoTutorial = true;
                btSkip.GetComponent<Button>().interactable = true;
                break;
            case 3:
                bts[0].ativoTutorial = false;
                bts[1].ativoTutorial = true;
                bts[2].ativoTutorial = false;
                bts[3].ativoTutorial = true;
                bts[4].ativoTutorial = true;
                bts[5].ativoTutorial = true;
                btSkip.GetComponent<Button>().interactable = false;
                break;
            case 4:
                bts[0].ativoTutorial = false;
                bts[1].ativoTutorial = false;
                bts[2].ativoTutorial = true;
                bts[3].ativoTutorial = true;
                bts[4].ativoTutorial = true;
                bts[5].ativoTutorial = true;
                btSkip.GetComponent<Button>().interactable = false;
                break;
            case 5:
                bts[0].ativoTutorial = true;
                bts[1].ativoTutorial = true;
                bts[2].ativoTutorial = true;
                bts[3].ativoTutorial = true;
                bts[4].ativoTutorial = true;
                bts[5].ativoTutorial = true;
                btSkip.GetComponent<Button>().interactable = true;
                break;
            case 6:
                bts[0].ativoTutorial = true;
                bts[1].ativoTutorial = true;
                bts[2].ativoTutorial = true;
                bts[3].ativoTutorial = true;
                bts[4].ativoTutorial = true;
                bts[5].ativoTutorial = true;
                btSkip.GetComponent<Button>().interactable = true;
                break;
            case 7:
                bts[0].ativoTutorial = true;
                bts[1].ativoTutorial = true;
                bts[2].ativoTutorial = true;
                bts[3].ativoTutorial = true;
                bts[4].ativoTutorial = true;
                bts[5].ativoTutorial = true;
                btSkip.GetComponent<Button>().interactable = true;
                break;
            case 8:
                bts[0].ativoTutorial = true;
                bts[1].ativoTutorial = true;
                bts[2].ativoTutorial = true;
                bts[3].ativoTutorial = true;
                bts[4].ativoTutorial = true;
                bts[5].ativoTutorial = true;
                btSkip.GetComponent<Button>().interactable = true;
                break;
            case 9:
                bts[0].ativoTutorial = true;
                bts[1].ativoTutorial = true;
                bts[2].ativoTutorial = false;
                bts[3].ativoTutorial = true;
                bts[4].ativoTutorial = true;
                bts[5].ativoTutorial = true;
                btSkip.GetComponent<Button>().interactable = false;
                break;
            case 10:
                bts[0].ativoTutorial = true;
                bts[1].ativoTutorial = true;
                bts[2].ativoTutorial = true;
                bts[3].ativoTutorial = true;
                bts[4].ativoTutorial = true;
                bts[5].ativoTutorial = true;
                btSkip.GetComponent<Button>().interactable = true;
                break;
        }

        foreach(Butao bt in bts)
        {
            bt.MudarCor(bt.id);
        }
    }
}
