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

    public void DiagTerceiro(int id)
    {
        switch(id)
        {
            case 0: //Amélia - 1
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 0, 1, 0, 1, 1, 0, 1});
                diagBox.NovoDialogo(new string[]
                {"* Amélia entra nos Arquivos *",
                "* Ela procura entre os livros por uma razão para estar acontecendo mais corrupção que o normal *",
                "Estranho. Nos conhecimentos antigos e nos documentos não parece ter nada em específico fazendo elas serem corrompidas.",
                "* Ela vê vários documentos da Concha, empresa que domina a ilha *",
                "Eles... Eles são o motivo.",
                "Desde que eles entraram aqui tudo começou a piorar, agora está transbordando da panela tudo que estava fervendo.",
                "* As criaturas em volta dela que vivem nos Arquivos começam a se corromper assim como na Costa de cacos *",
                "Alguém vai precisar fazer algo, a corrupção vai se espalhar por todo o lugar."});
                break;
            case 1: //Vlad - 2
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 0, 2, 2, 2});
                diagBox.NovoDialogo(new string[]
                {"* Saindo da Floresta Composta e entrando na Comunidade ele vê que ela parece estar abandonada *",
                "* Criaturas Corrompidas caminham nas ruas e ele não consegue ver ninguém *",
                "O que está causando tudo isso? Até na Comunidade, o lugar mais seguro da ilha, as criaturas estão corrompidas.",
                "Minha família! Preciso ver se eles estão seguros.",
                "Vou passar por essas criaturas e chegar até eles."});
                break;
            case 2: //Kai - 3
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 0, 3, 0, 3});
                diagBox.NovoDialogo(new string[]
                {"* Chegando na Costa de cacos ela não está melhor do que a Comunidade *",
                "* Criaturas Corrompidas caminham e se atacam por todos os lados *",
                "Otímo, mais problemas. Eu preciso chegar em um lugar mais aberto para poder ver.",
                "* Ele vê a distância um grande caco de vidro nas areias como um obelisco *",
                "Subindo nele eu poderei ver facilmente a ilha. Só preciso passar pelas criaturas até chegar lá."});
                break;
            case 3: //Renan - 4
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 0, 4, 0, 4, 0, 4});
                diagBox.NovoDialogo(new string[]
                {"* Renan chega no Coração da Ilha, seu local de trabalho e de muitos outros *",
                "* Ele vê trabalhadores perdidos no trabalho, sem sequer registrar o que acontece em volta deles *",
                "Eu... Tinha esquecido como essa visão era ruim, eu mesmo ficava perdido no meu trabalho... Como eu escapei disso?",
                "* Ele se lembra do papel com o seu nome que ele tinha rasgado nos Arquivos *",
                "Aquele... Era meu contrato? Por isso eu não estou mais trabalhando?",
                "* Seu pensamento é interrompido quando Criaturas Corrompidas atacam os trabalhadores *",
                "Não! Eles não conseguem se defender."});
                break;
            case 4: //Jayden - 5
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 5, 5});
                diagBox.NovoDialogo(new string[]
                {"* Chegando na Floresta Composta ela vê muitas Criaturas Corrompidas assim como no Coração da Ilha *",
                "São muitas, preciso purifica-las antes que elas comecem a escapar para outras regiões.",
                "Enquanto isso vou coletando dados."});
                break;
            case 5: //Ana
                Debug.Log("id do boneco: " + id);
                break;
        }
    }

    public void DiagQuarto(int id)
    {
        switch(id)
        {
            case 0: //Amélia
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{1, 1, 1, 0});
                diagBox.NovoDialogo(new string[]
                {"São muitas, eu preciso fazer algo.",
                "Na Floresta Orgânica. Eu li que lá tem um caminho para entrar nos escritórios da Concha.",
                "Irei mostrar o que está acontecendo, eles vão precisar diminuir as atividades na ilha.",
                "* Uma criatura fecha seu caminho *"});
                break;
            case 1: //Vlad
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 0, 2, 2, 0, 2});
                diagBox.NovoDialogo(new string[]
                {"* Ele chega em casa e entra *",
                "* Primeiro ele não vê ninguém mas após procurar um pouco mais ele encontra sua esposa e filho escondidos *",
                "Vocês estão bem!",
                "Eu vou dar um jeito de tirar essas criaturas daqui, talvez nos Arquivos tenha uma forma de lidar com essa corrupção.",
                "* Saindo para rua seu caminho é bloqueado por uma Criatura corrompida muito maior *",
                "Vou purificar essa criatura, ela está perto demais da minha casa, depois vou para Os Arquivos."});
                break;
            case 2: //Kai
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{0, 0, 0, 3, 3, 3});
                diagBox.NovoDialogo(new string[]
                {"* Ele finalmente chega ao caco gigante e sobe nele *",
                "* Vendo de cima do obelisco ele pode ver a ilha inteira, e percebe o Coração da Ilha *",
                "* Um vulcão no centro da ilha que usam como base de operação dos trabalhadores, ele está com mais fumaça do que o normal *",
                "Ali! Parece ter alguma coisa. Pode ser o que está causando esse tumulto.",
                "Eu vou ir lá ver, só preciso fazer o caminho de volta.",
                "Pasando por mais criaturas."});
                break;
            case 3: //Renan
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{4, 4, 0, 4});
                diagBox.NovoDialogo(new string[]
                {"Isso não vai adiantar, mais estão se corrompendo.",
                "Eu vou buscar ajuda. A Comunidade deve ter gente. Preciso ir para lá.",
                "* Uma Criatura Corrompida maior que as outras ataca um grupo de trabalhadores *",
                "Só essa maior, vou lidar com ela e vou para a Comunidade."});
                break;
            case 4: //Jayden
                control.emDialogo = true;
                diagBox.NovoPersonagens(new int[]{5, 5, 5, 0, 5});
                diagBox.NovoDialogo(new string[]
                {"Parece que as criaturas estão indo para uma direção específica.",
                "Elas atacam tudo em volta mas quando não estão atacando elas vão para aquela direção.",
                "Preciso de criaturas de outra região para ver se também estão indo para um mesmo ponto e triangular o local.",
                "* Mais uma criatura maior que as outras a ataca *",
                "Vou purifica-la e depois vou para a Costa de Cacos, é a região mais próxima daqui e verei o caminho das criaturas."});
                break;
            case 5: //Ana
                Debug.Log("id do boneco: " + id);
                break;
        }
    }
}
