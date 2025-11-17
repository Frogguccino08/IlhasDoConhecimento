using System.Collections.Generic;
using UnityEngine;

public class AttacksList : MonoBehaviour
{
    public List<Attacks> listaAtaques = new List<Attacks>();
    public List<Attacks> listaHabilidades = new List<Attacks>();
    public List<Attacks> listaRegiao = new List<Attacks>();
    public Attacks attacks;


    void Awake()
    {
        //int Id, string Nome, string Desc, tipo1, tipo2, int Material, int Dano, bool Phispe, bool Alvo, int Quantidade, int Carga, bool TemEfeito, bool IsPassiva
        //Tipo {Attacks.Tipo.golpe, Attacks.Tipo.suporte, Attacks.Tipo.bloqueio, Attacks.Tipo.passiva, Attacks.Tipo.cura, Attacks.Tipo.cura}
        listaAtaques.Add(new Attacks(0, "- -", "Esse habilidade não existe", Attacks.Tipo.zero, Attacks.Tipo.zero, 0, 0, true, true, 0, 0, false, false));
        listaAtaques.Add(new Attacks(1, "Ataque purificador", "Ataque físico comum com o mesmo material de quem o utiliza", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 2, true, true, 1, 1, false, false));
        listaAtaques.Add(new Attacks(2, "Disparo purificador", "Ataque a distância comum com o mesmo material de quem o utiliza", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 2, false, true, 1, 1, false, false));
        listaAtaques.Add(new Attacks(3, "Bloquear", "Recebe 2 bloqueio", Attacks.Tipo.bloqueio, Attacks.Tipo.zero, 0, 0, false, false, 0, 2, true, false));
        listaAtaques.Add(new Attacks(4, "Expor inimigo", "Faz o inimigo não poder aumentar sua quantidade de bloqueio por 2 turnos", Attacks.Tipo.exposto, Attacks.Tipo.zero, 0, 0, true, true, 0, 2, true, false));
        listaAtaques.Add(new Attacks(5, "Leitura", "Após ser atacado tem chance de aumentar sua defesa a distância", Attacks.Tipo.passiva, Attacks.Tipo.suporte, 1, 0, false, false, 0, 0, true, true));
        listaAtaques.Add(new Attacks(6, "Corte de papel", "Ataque mais forte de papel que diminue o dano a distância do inimigo", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 1, 2, false, true, 3, 3, true, false));
        listaAtaques.Add(new Attacks(7, "Tornado de origami", "Um ataque poderoso de papel sem efeito extra", Attacks.Tipo.golpe, Attacks.Tipo.zero, 1, 4, false, true, 3, 4, false, false));
        listaAtaques.Add(new Attacks(8, "Capa Grossa", "Recebe 2 cargas de bloqueio e aumenta sua defesa a distância", Attacks.Tipo.suporte, Attacks.Tipo.bloqueio, 1, 0, false, false, 0, 3, true, false));
        listaAtaques.Add(new Attacks(9, "Material Resistênte", "Após ser atacado tem chance de aumentar sua defesa física", Attacks.Tipo.passiva, Attacks.Tipo.suporte, 2, 0, false, false, 0, 0, true, true));
        listaAtaques.Add(new Attacks(10, "Arremesso de material", "Ataque mais forte de plástico que diminue dano físico do alvo", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 2, 2, true, true, 3, 3, true, false));
        listaAtaques.Add(new Attacks(11, "Lançamento de brinquedos", "Ataque poderoso de plástico sem efeito extra", Attacks.Tipo.golpe, Attacks.Tipo.zero, 2, 4, true, true, 3, 4, false, false));
        listaAtaques.Add(new Attacks(12, "Barreira de montar", "Recebe 2 cargas de bloqueio e aumenta sua defesa física", Attacks.Tipo.suporte, Attacks.Tipo.bloqueio, 2, 0, true, false, 0, 3, true, false));
        listaAtaques.Add(new Attacks(13, "Quebrar espelho", "Ao fazer um ataque de vidro tem chance de aumentar seu dano a distância", Attacks.Tipo.passiva, Attacks.Tipo.suporte, 3, 0, false, false, 0, 0, true, true));
        listaAtaques.Add(new Attacks(14, "Atirar agulhas", "Ataque mais forte de vidro que diminue a defesa a distância do alvo", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 3, 2, false, true, 3, 3, true, false));
        listaAtaques.Add(new Attacks(15, "Raio refletido", "Ataque poderoso de vidro sem efeito extra", Attacks.Tipo.golpe, Attacks.Tipo.zero, 3, 4, false, true, 3, 4, false, false));
        listaAtaques.Add(new Attacks(16, "Barreira refletora", "Recebe duas cargas de bloqueio e aumenta seu ataque a distância", Attacks.Tipo.suporte, Attacks.Tipo.bloqueio, 3, 0, false, false, 0, 3, true, false));
        listaAtaques.Add(new Attacks(17, "Pontas afiadas", "Ao fazer um ataque de metal tem chance de aumentar seu dano físico", Attacks.Tipo.passiva, Attacks.Tipo.suporte, 4, 0, true, false, 0, 0, true, true));
        listaAtaques.Add(new Attacks(18, "Lâmina afiada", "Ataque mais forte de metal que diminue a defesa física do alvo", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 4, 2, true, true, 3, 3, true, false));
        listaAtaques.Add(new Attacks(19, "batida pesada", "Ataque poderoso de metal sem efeito extra", Attacks.Tipo.golpe, Attacks.Tipo.zero, 4, 4, true, true, 3, 4, false, false));
        listaAtaques.Add(new Attacks(20, "Casca de metal", "Recebe duas cargas de bloqueio e aumenta seu ataque físico", Attacks.Tipo.suporte, Attacks.Tipo.bloqueio, 4, 0, false, false, 0, 3, true, false));
        listaAtaques.Add(new Attacks(21, "Absorção", "Após usar um ataque Orgânico no inimigo tem uma chance de aumentar seu ganho de conhecimento", Attacks.Tipo.passiva, Attacks.Tipo.suporte, 5, 0, false, false, 0, 0, true, true));
        listaAtaques.Add(new Attacks(22, "Golpe de restos", "Ataque mais forte Orgânico que diminue o ganho de conhecimento do inimigo", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 5, 2, true, true, 3, 3, true, false));
        listaAtaques.Add(new Attacks(23, "Batida de sujeira", "Um ataque poderoso Orgânico sem efeito extra", Attacks.Tipo.golpe, Attacks.Tipo.zero, 5, 4, true, true, 3, 4, false, false));
        listaAtaques.Add(new Attacks(24, "Bloqueio vivo", "Recebe duas cargas de bloqueio e aumenta o ganho de conhecimento por 2 turnos", Attacks.Tipo.bloqueio, Attacks.Tipo.suporte, 5, 0, false, false, 0, 3, true, false));
        listaAtaques.Add(new Attacks(25, "Aumentar Marcha", "Aumenta seu dano físico por 2 turnos mas diminue a defesa física pelo mesmo tempo", Attacks.Tipo.suporte, Attacks.Tipo.zero, 4, 0, false, false, 0, 2, true, false));
        listaAtaques.Add(new Attacks(26, "Espalhar cacos", "Ataque extremamente fraco de vidro que coloca cacos no inimigo (causa dano no final do turno)", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 3, 1, false, true, 1, 2, true, false));
        listaAtaques.Add(new Attacks(27, "Reciclar vida", "Cura parte da própria vida e continua curando por mais 2 turnos", Attacks.Tipo.cura, Attacks.Tipo.zero, 5, -3, false, false, 1, 4, true, false));
        listaAtaques.Add(new Attacks(28, "Estilhaços", "Ataque fraco de metal que causa cacos no inimigo", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 4, 1, false, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(29, "Suco ácido", "diminue a defesa física e a distância do alvo por 3 turnos", Attacks.Tipo.negativo, Attacks.Tipo.zero, 5, 0, false, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(30, "Folhas soltas", "Ataque extremamente fraco de papel porém que ataca várias vezes", Attacks.Tipo.golpe, Attacks.Tipo.zero, 1, 1, false, true, 5, 3, false, false));
        listaAtaques.Add(new Attacks(31, "Desisformação", "Diminue o dano a distância do inimigo por 3 turnos", Attacks.Tipo.negativo, Attacks.Tipo.zero, 1, 0, false, true, 1, 2, true, false));
        listaAtaques.Add(new Attacks(32, "Estagnado", "Diminue o dano físico do inimigo por 3 turnos", Attacks.Tipo.negativo, Attacks.Tipo.zero, 2, 0, false, true, 1, 2, true, false));
        listaAtaques.Add(new Attacks(33, "Tenderizar", "Diminue a defesa a distância do inimigo por 3 turnos", Attacks.Tipo.negativo, Attacks.Tipo.zero, 3, 0, false, true, 1, 2, true, false));
        listaAtaques.Add(new Attacks(34, "Derreter", "Diminue a defesa física do inimigo por 3 turnos", Attacks.Tipo.negativo, Attacks.Tipo.zero, 4, 0, false, true, 1, 2, true, false));
        listaAtaques.Add(new Attacks(35, "Desperdício", "Diminue o ganho de conhecimento do inimigo por 3 turnos", Attacks.Tipo.negativo, Attacks.Tipo.zero, 5, 0, false, true, 1, 2, true, false));
        listaAtaques.Add(new Attacks(36, "Arremesso de garrafa", "Ataque mediano de Vidro que causa cacos", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 3, 3, false, true, 3, 5, true, false));
        listaAtaques.Add(new Attacks(37, "Martelo de brinquedo", "Ataque com bastante dano que deixa o inimigo com 2 exposto", Attacks.Tipo.golpe, Attacks.Tipo.exposto, 2, 5, true, true, 1, 4, true, false));
        listaAtaques.Add(new Attacks(38, "Tiro de canudo", "Ataque com dano razoável porém que remove 2 bloqueio ao invés de 1 (3 com carga R)", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 2, 3, false, true, 1, 4, true, false));
        listaAtaques.Add(new Attacks(39, "Aprendendo", "Ataque fraco de papel que deixa o inimigo com 2 exposto", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 1, 3, false, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(40, "Tapa leve", "Ataque muito fraco sem elemento sem custo e sem efeito", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 1, true, true, 1, 0, false, false));
        listaAtaques.Add(new Attacks(41, "Barreira Perfeita", "Uma barreira poderosa, coloca 5 bloqueio em si mesmo", Attacks.Tipo.bloqueio, Attacks.Tipo.zero, 0, 0, false, false, 1, 5, true, false));
        listaAtaques.Add(new Attacks(42, "Troca de postura", "O personagem troca de postura de combate, trocando entre metal/Ataque físico e Papel/Defesa a Distância", Attacks.Tipo.troca, Attacks.Tipo.suporte, 0, 0, false, false, 0, 3, true, false));
        listaAtaques.Add(new Attacks(43, "Katana de alma", "O personagem corta com a katana ignorando defesa física", Attacks.Tipo.golpe, Attacks.Tipo.zero, 4, 2, true, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(44, "Composto", "Se cura uma pequena quantidade usando matéria orgânica", Attacks.Tipo.cura, Attacks.Tipo.zero, 5, -4, false, false, 1, 3, false, false));
        listaAtaques.Add(new Attacks(45, "Empurrar", "Ataque fraco de papel sem efeito extra", Attacks.Tipo.golpe, Attacks.Tipo.zero, 1, 1, false, true, 1, 0, false, false));
        listaAtaques.Add(new Attacks(46, "Roubar Nutrientes", "Coloca cacos no inimigo e nutrindo em si mesmo", Attacks.Tipo.cura, Attacks.Tipo.negativo, 5, 0, false, true, 0, 4, true, false));
        listaAtaques.Add(new Attacks(47, "Atacar ponto fraco", "Esse ataque causa mais dano caso o inimigo esteja exposto", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 2, true, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(48, "Armadura de espinhos", "Enquanto tiver escudo causa um pequeno dano de volta a ser atacado mas perde +1 escudo", Attacks.Tipo.passiva, Attacks.Tipo.golpe, 0, 0, true, true, 0, 0, true, true));
        listaAtaques.Add(new Attacks(49, "Corte", "Golpe fraco de metal sem efeito extra", Attacks.Tipo.golpe, Attacks.Tipo.zero, 4, 1, true, true, 1, 0, false, false));
        listaAtaques.Add(new Attacks(50, "Batida energizada", "Ataque médio que causa mais dano em alvos de metal", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 3, true, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(51, "Ataque poluente", "Ataque físico comum com o mesmo material de quem o utiliza", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 2, true, true, 1, 1, false, false));
        listaAtaques.Add(new Attacks(52, "Disparo poluente", "Ataque a distância comum com o mesmo material de quem o utiliza", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 2, false, true, 1, 1, false, false));
        listaAtaques.Add(new Attacks(53, "Passar óleo", "Cura uma pequena quantidade de vida e aumenta seu dano físico por 3 turnos", Attacks.Tipo.cura, Attacks.Tipo.suporte, 4, -3, false, false, 1, 4, true, false));
        listaAtaques.Add(new Attacks(54, "Campo magnético", "Caso esteja contra um inimigo de metal, recebe +1 defesa física e defesa a distância no início do turno", Attacks.Tipo.passiva, Attacks.Tipo.suporte, 4, 0, false, false, 0, 0, true, true));
        listaAtaques.Add(new Attacks(55, "Entortar", "Ataques que causam dano físico em inimigos de metal fazem eles ficarem com menos defesa física", Attacks.Tipo.passiva, Attacks.Tipo.negativo, 0, 0, true, true, 0, 0, true, true));
        listaAtaques.Add(new Attacks(56, "Derrubar", "Golpe fraco orgânico sem efeito extra", Attacks.Tipo.golpe, Attacks.Tipo.zero, 5, 1, true, true, 1, 0, false, false));
        listaAtaques.Add(new Attacks(57, "Criar fungos", "Ataque médio que causa mais dano em alvos de orgânico", Attacks.Tipo.golpe, Attacks.Tipo.zero, 5, 3, false, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(58, "Espirro de chorume", "Ataque poderoso orgânico que deixa o alvo exposto", Attacks.Tipo.golpe, Attacks.Tipo.exposto, 5, 4, false, true, 2, 4, true, false));
        listaAtaques.Add(new Attacks(59, "Solo ruim", "Remove todo o nutrindo que o alvo tenha", Attacks.Tipo.negativo, Attacks.Tipo.zero, 5, 0, false, true, 0, 3, true, false));
        listaAtaques.Add(new Attacks(60, "Enxame de pragas", "Ataque fraco orgânico que causa cacos no alvo", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 5, 3, false, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(61, "Limpar terreno", "Limpa todos os efeitos, negativos e positivos dos dois lados do combate", Attacks.Tipo.negativo, Attacks.Tipo.suporte, 0, 0, false, false, 0, 5, true, false));
        listaAtaques.Add(new Attacks(62, "Corpo quente", "Ataques físicos contra você tem chance de diminuir a defesa física e a distância do atacante", Attacks.Tipo.passiva, Attacks.Tipo.negativo, 0, 0, true, false, 0, 0, true, true));
        listaAtaques.Add(new Attacks(63, "Estômago forte", "Atacar um alvo orgânico consome uma parte do inimigo recuperando uma pequena parcela de vida", Attacks.Tipo.passiva, Attacks.Tipo.cura, 0, 0, true, true, 0, 0, true, true));
        listaAtaques.Add(new Attacks(64, "Guia", "Pequenos ajudantes usam um segundo ataque menor após você usar um ataque", Attacks.Tipo.passiva, Attacks.Tipo.golpe, 0, 0, false, true, 0, 0, true, true));
        listaAtaques.Add(new Attacks(65, "Perfurar", "Golpe fraco de vidro sem efeito extra", Attacks.Tipo.golpe, Attacks.Tipo.zero, 3, 1, false, true, 1, 0, false, false));
        listaAtaques.Add(new Attacks(66, "Superfície com tensão", "Ataque médio que causa mais dano em alvos de Vidro", Attacks.Tipo.golpe, Attacks.Tipo.zero, 3, 3, false, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(67, "Tiro Fragmentado", "Ataque que altera o dano aleatóriamente entre 1 e 5", Attacks.Tipo.golpe, Attacks.Tipo.zero, 3, 1, false, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(68, "Molotov", "Esse ataque causa dano duas vezes, uma no ataque e uma no final do turno do alvo", Attacks.Tipo.golpe, Attacks.Tipo.zero, 3, 2, false, true, 1, 4, true, false));
        listaAtaques.Add(new Attacks(69, "Refletir", "Ataque que causa o mesmo tanto de dano do último ataque inimigo uma vez, Falha de não foi um ataque de dano", Attacks.Tipo.golpe, Attacks.Tipo.zero, 3, 1, false, true, 1, 4, true, false));
        listaAtaques.Add(new Attacks(70, "Ataques frágeis", "Ataques a distância causam -1 de dano mas todos tem chance de causar cacos", Attacks.Tipo.negativo, Attacks.Tipo.passiva, 3, 0, false, false, 0, 0, true, true));
        listaAtaques.Add(new Attacks(71, "Espeto Perfurante", "Ataque físico que faz o alvo ficar exposto", Attacks.Tipo.golpe, Attacks.Tipo.exposto, 3, 1, true, true, 4, 4, true, false));
        listaAtaques.Add(new Attacks(72, "Ponta infectada", "Ao usar ataques físicos tem uma chance pequena de diminuir algum atributo", Attacks.Tipo.negativo, Attacks.Tipo.passiva, 3, 0, true, true, 0, 0, true, true));
        listaAtaques.Add(new Attacks(73, "Bater", "Golpe fraco de Plástico sem efeito extra", Attacks.Tipo.golpe, Attacks.Tipo.zero, 2, 1, true, true, 1, 0, false, false));
        listaAtaques.Add(new Attacks(74, "Mistura de Materiais", "Ataque médio que causa mais dano em alvos de Plástico", Attacks.Tipo.golpe, Attacks.Tipo.zero, 2, 3, true, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(75, "Apagar conteúdo", "Ataque médio que causa mais dano em alvos de Papel", Attacks.Tipo.golpe, Attacks.Tipo.zero, 1, 3, false, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(76, "Gole de conhecimento", "Zera a quantidade de conhecimento do alvo, mantendo apenas o ganho inicial do turno", Attacks.Tipo.negativo, Attacks.Tipo.zero, 1, 0, false, true, 0, 3, true, false));
        listaAtaques.Add(new Attacks(77, "Avião de papel", "Ataque fraco que pórem ignora escudos", Attacks.Tipo.golpe, Attacks.Tipo.zero, 1, 2, false, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(78, "Remendar", "Cura pequena que também aumenta defesa física", Attacks.Tipo.cura, Attacks.Tipo.suporte, 1, -3, false, false, 1, 4, true, false));
        listaAtaques.Add(new Attacks(79, "Saco Plástico", "Prende o inimigo fazendo ele perder o próximo ataque", Attacks.Tipo.negativo, Attacks.Tipo.zero, 2, 0, false, true, 0, 3, true, false));
        listaAtaques.Add(new Attacks(80, "Infectar material", "Ataque bem fraco que diminue o dano físico do alvo por bastante tempo", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 2, 2, true, true, 1, 4, true, false));
        listaAtaques.Add(new Attacks(81, "Reutilizar escudo", "Remove o escudo do alvo e adiciona a você", Attacks.Tipo.negativo, Attacks.Tipo.bloqueio, 2, 0, false, true, 0, 5, true, false));
        listaAtaques.Add(new Attacks(82, "Fusão pet", "Aumenta seu dano físico e sua defesa física", Attacks.Tipo.suporte, Attacks.Tipo.zero, 2, 0, false, false, 0, 3, true, false));
        listaAtaques.Add(new Attacks(83, "Chuva de canudos", "Ataque fraco que ataca várias vezes", Attacks.Tipo.golpe, Attacks.Tipo.zero, 2, 1, false, true, 5, 3, false, false));
        listaAtaques.Add(new Attacks(84, "Bastão de filme", "Ataque médio que tem uma chance pequena de fazer o inimigo errar o próximo ataque", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 2, 2, true, true, 2, 4, true, false));
        listaAtaques.Add(new Attacks(85, "projétil de tampa", "Ataque fraco que deixa o alvo exposto e com menos defesa a distância", Attacks.Tipo.negativo, Attacks.Tipo.exposto, 2, 2, false, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(86, "Explosão de pressão", "Um ataque muito forte que causa um pouco de dano em você também", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 5, true, true, 2, 5, true, false));
        listaAtaques.Add(new Attacks(87, "Material reforçado", "Aumenta seu dano físico e a distância, porém coloca uma chance de errar ataques", Attacks.Tipo.passiva, Attacks.Tipo.suporte, 0, 0, false, false, 0, 0, true, true));
        listaAtaques.Add(new Attacks(88, "Amassar", "Ataques contra Papel ou Metal removem um escudo a mais antes do ataque", Attacks.Tipo.passiva, Attacks.Tipo.zero, 0, 0, true, true, 0, 0, true, true));
        listaAtaques.Add(new Attacks(89, "Torre de papel", "Ataques de bloqueio adicionam um bloqueio a mais, o ataque Avião de papel contra você também remove escudo não apenas ignora", Attacks.Tipo.passiva, Attacks.Tipo.zero, 1, 0, true, false, 0, 0, true, true));
        listaAtaques.Add(new Attacks(90, "Recolar", "Para cada ataque de papel cura 1/8 da vida, para cada ataque sem material que virou papel cura 1/10", Attacks.Tipo.cura, Attacks.Tipo.zero, 1, -1, false, false, 0, 4, true, false));
        listaAtaques.Add(new Attacks(91, "Virar a página", "Efeitos negativos são removidos em 2 por turno, porém sua defesa, física e a distância, sempre estão baixas", Attacks.Tipo.passiva, Attacks.Tipo.zero, 1, 0, false, false, 0, 0, true, true));
        listaAtaques.Add(new Attacks(92, "Pintura nova", "Cura uma pequena quantidade de vida e aumenta sua defesa a distância", Attacks.Tipo.cura, Attacks.Tipo.suporte, 1, -3, false, false, 1 , 4, true, false));
        listaAtaques.Add(new Attacks(93, "Planilha aberta", "Ataque médio de papel que causa um efeito negativo aleátorio", Attacks.Tipo.negativo, Attacks.Tipo.golpe, 1, 2, false, true, 2, 3, true, false));
        listaAtaques.Add(new Attacks(94, "Casca com farpas", "Coloca escudo em si mesmo e cacos no inimigo", Attacks.Tipo.negativo, Attacks.Tipo.bloqueio, 1, 0, false, true, 0, 3, true, false));
        //int Id, string Nome, string Desc, tipo1, tipo2, int Material, int Dano, bool Phispe, bool Alvo, int Quantidade, int Carga, bool TemEfeito, bool IsPassiva

        listaHabilidades.Add(new Attacks(0, "Conhecimento amplo", "Ao usar o 3R em um ataque sem nenhum efeito ganha +3 de defesa a distância", Attacks.Tipo.zero, Attacks.Tipo.zero, 1, 0, true, true, 0, 0, true, true));
        listaHabilidades.Add(new Attacks(1, "Camuflagem de lixo", "Ao usar o 3R em um ataque apenas de efeito ganha +1 escudo", Attacks.Tipo.zero, Attacks.Tipo.zero, 2, 0, true, true, 0, 0, true, true));
        listaHabilidades.Add(new Attacks(2, "Vidro de Cal-Soda", "Ao usar o 3R em um ataque a distância causa 1 ponto de cacos no alvo", Attacks.Tipo.zero, Attacks.Tipo.zero, 3, 0, true, true, 0, 0, true, true));
        listaHabilidades.Add(new Attacks(3, "Sobreaquecer", "Ao usar o 3R com um ataque físico aumenta o dano em +1", Attacks.Tipo.zero, Attacks.Tipo.zero, 4, 0, true, true, 0, 0, true, true));
        listaHabilidades.Add(new Attacks(4, "Mistura energética", "Ao usar o 3R com um ataque apenas de efeito recupera uma parcela de vida", Attacks.Tipo.zero, Attacks.Tipo.zero, 5, 0, true, true, 0, 0, true, true));
        listaHabilidades.Add(new Attacks(5, "- -", "Esse habilidade não existe", Attacks.Tipo.zero, Attacks.Tipo.zero, 0, 0, true, true, 0, 0, true, true));

        listaRegiao.Add(new Attacks(0, "Piso Afiado", "Chance pequena de causar cacos no personagem, não afeta personagens de vidro", Attacks.Tipo.zero, Attacks.Tipo.zero, 3, 0, true, true, 0, 0, true, true));
        listaRegiao.Add(new Attacks(1, "Calor de derreter", "Personagens não metal perder defesa física", Attacks.Tipo.zero, Attacks.Tipo.zero, 4, 0, true, true, 0, 0, true, true));
        listaRegiao.Add(new Attacks(2, "Névoa de microplásticos", "Personagens que não são de plástico tem uma chance bem pequena de errar ataques", Attacks.Tipo.zero, Attacks.Tipo.zero, 2, 0, true, true, 0, 0, true, true));
        listaRegiao.Add(new Attacks(3, "Área de desinformação", "Personagens não papel ficam com -1 de conhecimento máximo", Attacks.Tipo.zero, Attacks.Tipo.zero, 1, 0, true, true, 0, 0, true, true));
        listaRegiao.Add(new Attacks(4, "Nutrientes do chão", "Chance de aumentar ou diminuir conhecimento, Orgânicos só são afetados pelo aumento", Attacks.Tipo.zero, Attacks.Tipo.zero, 5, 0, true, true, 0, 0, true, true));
    }

    public Attacks CriarAtaques(int id, bool habilidade)
    {
        if (habilidade == false)
        {
            return listaAtaques[id];
        }
        else
        {
            return listaHabilidades[id];
        }
    }
}
