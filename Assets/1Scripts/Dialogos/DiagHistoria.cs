using UnityEngine;

public class DiagHistoria : MonoBehaviour
{
    Escrever diagBox;
    public Controle control;

    void Start()
    {
        diagBox = Escrever.instance.GetComponent<Escrever>();
        control = gameObject.GetComponent<Controle>();
    }

    public void DiagInicial(int id)
    {
        switch(id)
        {
            case 0: //Amélia
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 0, 1, 0, 1, 1});
                diagBox.NovoDialogo(new string[]
                {"* Amélia pinta um quadro do horizonte da Costa de Vidro *",
                "* As criaturas em volta ignoram ela, deixando-a pintar sem problemas *",
                "Toda essa calma. Como vou transmitir isso no quadro?",
                "* Então, as criaturas em volta começam a se agitar, se atacando e se movendo como Criaturas Corrompidas *",
                "O que é isso? Algo está afetando as criaturas. Vou purifica-las antes que se tornem um problema.",
                "Algo muito errado está acontecendo..."});
                break;
            case 1: //Vlad
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 2, 2, 0, 2});
                diagBox.NovoDialogo(new string[]
                {"* Vlad explora a Floresta Composta, procurando por comida",
                "Por que tem tantas Criaturas Corrompidas aqui? Normalmente a quantidade é bem menor.",
                "Eu nem minha família podemos se alimentar de criaturas assim. Vou precisar arrumar outro lugar para caçar.",
                "* Vlad começa o caminho para fora da floresta mas a quantidade de Criaturas Corrompidas é demais para passar escondido *",
                "Parece que eu vou ter que sair daqui lutando."});
                break;
            case 2: //Kai
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 3, 0, 3, 3, 3, 0});
                diagBox.NovoDialogo(new string[]
                {"* Kai está atrás do balcão do seu bar, nenhum cliente a vista * ",
                "A esse ponto alguém já era para ter aparecido, será que aconteceu alguma coisa?",
                "* Ele sai pro lado de fora do bar e vê Criaturas Corrompidas pelas ruas *",
                "O que é isso?!",
                "Desde quando Criaturas Corrompidas passam pela comunidade?",
                "Eu não sou de brigar mas se ninguém lidar com isso não terei clientes.",
                "* Kai pega suas garrafas e taças para lutar *"});
                break;
            case 3: //Renan
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 4, 4, 0, 0, 4, 0, 4});
                diagBox.NovoDialogo(new string[]
                {"* Renan acorda sem lembranças de nada *",
                "...",
                "Onde eu estou? O que eu estou fazendo aqui?",
                "* Olhando em volta as montanhas de livros e documentos ele percebe estár Nos Arquivos *",
                "* Em suas mãos um papel, um documento com o seu nome. Rasgado *",
                "Eu rasguei isso sem querer? Eu preciso voltar pro Coração da Ilha e reportar pro meu superior.",
                "* Criaturas Corrompidas começam a se aproximar dele *",
                "Mas primeiro eu preciso sair desse lugar."});
                break;
            case 4: //Jayden
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 5, 5, 0, 0, 5, 5});
                diagBox.NovoDialogo(new string[]
                {"* Jayden está no Coração da Ilha, analisando comportamento de criaturas que são usadas para trabalho *",
                "Estranho, eu sei que a taxa de corrupção de criaturas quando são usadas dessa forma é mais alta.",
                "Mas nessa ilha elas estão maiores ainda.",
                "* Criaturas em volta dela se corrompem de uma hora para outra, as vezes sem aviso nenhum *",
                "* Ela observa os trabalhadores em volta, seus contratos fazem eles se perderem no trabalho *",
                "Os trabalhadores aqui não podem se defender...",
                "Vou precisar purificar algumas dessas Criaturas Corrompidas antes de qualquer pesquisa."});
                break;
            case 5: //Ana
                Debug.Log("id do boneco: " + id);
                break;
        }
    }

    public void DiagSegundo(int id)
    {
        switch(id)
        {
            case 0: //Amélia
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 1, 1, 1});
                diagBox.NovoDialogo(new string[]
                {"* Não importa quantas criaturas sejam purificadas mais delas surgem, parecem não acabar",
                "Purificar Criaturas Corrompidas sem saber de onde elas estão saindo não serve de nada.",
                "Vou voltar para Os Arquivos e tentar encontrar no conhecimento um motivo para essa corrupção.",
                "Vou purificar apenas aquela maior que pode ser um problema."});
                break;
            case 1: //Vlad
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{2, 0, 2});
                diagBox.NovoDialogo(new string[]
                {"Eu consigo ver a Comunidade depois daquelas árvores, estou quase saindo.",
                "* Uma última criatura bloqueia seu caminho *",
                "Não vou conseguir desviar dela, vou ter que purifica-la para chegar em casa."});
                break;
            case 2: //Kai
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 3, 3});
                diagBox.NovoDialogo(new string[]
                {"* Kai purifica várias criaturas e vê uma maior se aproximando *",
                "Só purificar essas criaturas não vai servir, preciso encontrar de onde elas estão vindo.",
                "Vou purificar essa maior para ela não destruir nada e vou para a Costa de Cacos tentar encontrar de lá um sinal de onde elas vieram."});
                break;
            case 3: //Renan
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 4});
                diagBox.NovoDialogo(new string[]
                {"* Renan faz seu caminho através das Criaturas Corrompidas *",
                "Ótimo, já consigo ver a saída só preciso passar por mais essa criatura para sair."});
                break;
            case 4: //Jayden
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 5, 5});
                diagBox.NovoDialogo(new string[]
                {"* Algumas das criaturas foram purificadas, ela consegue ver uma maior se corrompendo *",
                "Eu preciso de mais dados para saber o que está acontecendo na ilha.",
                "Preciso ir para uma região com mais criaturas para identificar o padrão, talvez a Floresta Composta seja a melhor opção."});
                break;
            case 5: //Ana
                Debug.Log("id do boneco: " + id);
                break;
        }
    }
}
