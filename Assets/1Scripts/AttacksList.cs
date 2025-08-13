using System.Collections.Generic;
using UnityEngine;

public class AttacksList : MonoBehaviour
{
    public List<Attacks> listaAtaques = new List<Attacks>();
    public Attacks attacks;


    void Awake()
    {
        //int Id, string Nome, string Desc, tipo1, tipo2, int Material, int Dano, bool Phispe, bool Alvo, int Quantidade, int Carga, bool TemEfeito, bool IsPassiva
        //Tipo {Attacks.Tipo.golpe, Attacks.Tipo.suporte, Attacks.Tipo.bloqueio, Attacks.Tipo.passiva, Attacks.Tipo.cura, Attacks.Tipo.cura}
        listaAtaques.Add(new Attacks(0, "- -", "Esse ataque não existe", Attacks.Tipo.zero, Attacks.Tipo.zero, 0, 0, true, true, 0, 0, false, false));
        listaAtaques.Add(new Attacks(1, "Ataque purificador", "Ataque físico comum com o mesmo material de quem o utiliza", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 2, true, true, 1, 1, false, false));
        listaAtaques.Add(new Attacks(2, "Disparo purificador", "Ataque a distância comum com o mesmo material de quem o utiliza", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 2, false, true, 1, 1, false, false));
        listaAtaques.Add(new Attacks(3, "Bloquear", "Recebe 2 bloqueio", Attacks.Tipo.bloqueio, Attacks.Tipo.zero, 0, 0, false, false, 0, 2, true, false));
        listaAtaques.Add(new Attacks(4, "Expor inimigo", "Faz o inimigo não poder aumentar sua quantidade de bloqueio por 2 turnos", Attacks.Tipo.negativo, Attacks.Tipo.zero, 0, 0, true, true, 0, 2, true, false));
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
        listaAtaques.Add(new Attacks(24, "Bloqueio vivo", "Recebe duas cargas de bloqueio e aumenta o ganho de conhecimento por 2 turnos", Attacks.Tipo.bloqueio, Attacks.Tipo.cura, 5, 0, false, false, 0, 3, true, false));
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
        listaAtaques.Add(new Attacks(37, "Martelo de brinquedo", "Ataque com bastante dano que deixa o inimigo com 2 exposto", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 2, 5, true, true, 1, 4, true, false));
        listaAtaques.Add(new Attacks(38, "Tiro de canudo", "Ataque com dano razoável porém que remove 2 bloqueio ao invés de 1 (3 com carga R)", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 2, 3, false, true, 1, 4, true, false));
        listaAtaques.Add(new Attacks(39, "Aprendendo", "Ataque fraco de papel que deixa o inimigo com 2 exposto", Attacks.Tipo.golpe, Attacks.Tipo.negativo, 1, 3, false, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(40, "Tapa leve", "Ataque muito fraco sem elemento sem custo e sem efeito", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 1, true, true, 1, 0, false, false));
        listaAtaques.Add(new Attacks(41, "Barreira Perfeita", "Uma barreira poderosa, coloca 5 bloqueio em si mesmo", Attacks.Tipo.bloqueio, Attacks.Tipo.zero, 0, 0, false, false, 1, 5, true, false));
        listaAtaques.Add(new Attacks(42, "Troca de postura", "O personagem troca de postura de combate, trocando entre metal/Ataque físico e Papel/Defesa a Distância", Attacks.Tipo.troca, Attacks.Tipo.suporte, 0, 0, false, false, 0, 3, true, false));
        listaAtaques.Add(new Attacks(43, "Katana de alma", "O personagem corta com a katana ignorando defesa física", Attacks.Tipo.golpe, Attacks.Tipo.zero, 4, 2, true, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(44, "Composto", "Se cura uma pequena quantidade usando matéria orgânica", Attacks.Tipo.cura, Attacks.Tipo.zero, 5, -3, false, false, 1, 2, false, false));
        listaAtaques.Add(new Attacks(45, "Avião de papel", "Ataque fraco de papel sem efeito extra", Attacks.Tipo.golpe, Attacks.Tipo.zero, 1, 1, false, true, 1, 0, false, false));
        listaAtaques.Add(new Attacks(46, "Roubar Nutrientes", "Coloca cacos no inimigo e nutrindo em si mesmo por 3 turnos", Attacks.Tipo.cura, Attacks.Tipo.negativo, 5, 0, false, true, 0, 4, true, false));
        listaAtaques.Add(new Attacks(47, "Atacar ponto fraco", "Esse ataque causa mais dano caso o inimigo esteja exposto", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 2, true, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(48, "Armadura de espinhos", "Enquanto tiver escudo causa um pequeno dano de volta a ser atacado mas perde +1 escudo", Attacks.Tipo.passiva, Attacks.Tipo.golpe, 0, 0, true, true, 0, 0, true, true));
        listaAtaques.Add(new Attacks(49, "Corte", "Golpe fraco de metal sem efeito extra", Attacks.Tipo.golpe, Attacks.Tipo.zero, 4, 1, true, true, 1, 0, false, false));
        listaAtaques.Add(new Attacks(50, "Batida energizada", "Ataque médio que causa mais dano em alvos de metal", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 3, true, true, 1, 3, true, false));
        listaAtaques.Add(new Attacks(51, "Ataque poluente", "Ataque físico comum com o mesmo material de quem o utiliza", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 2, true, true, 1, 1, false, false));
        listaAtaques.Add(new Attacks(52, "Disparo poluente", "Ataque a distância comum com o mesmo material de quem o utiliza", Attacks.Tipo.golpe, Attacks.Tipo.zero, 0, 2, false, true, 1, 1, false, false));
        listaAtaques.Add(new Attacks(53, "Passar óleo", "Cura uma pequena quantidade de vida e aumenta seu dano físico por 3 turnos", Attacks.Tipo.cura, Attacks.Tipo.suporte, 4, -3, false, false, 1, 4, true, false));
        listaAtaques.Add(new Attacks(54, "Campo magnético", "Caso esteja contra um inimigo de metal, recebe +1 defesa física e defesa a distância no início do turno", Attacks.Tipo.passiva, Attacks.Tipo.suporte, 4, 0, false, false, 0, 0, true, true));
        listaAtaques.Add(new Attacks(55, "Entortar", "Ataques que causam dano físico em inimigos de metal fazem eles ficarem com menos defesa física", Attacks.Tipo.passiva, Attacks.Tipo.negativo, 0, 0, true, true, 0, 0, true, true));
    }

    public Attacks CriarAtaques(int id)
    {
        return listaAtaques[id];
    }
}
