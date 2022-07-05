using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CriarFicha : MonoBehaviour
{

	public InputField inpNome;
	public InputField inpRaça;
	public InputField inpClasse;
	public InputField inpIdade;
	public InputField inpNivel;
	public InputField inpSexo;
	public InputField inpXP;
	public InputField inpForça;
	public InputField inpDestreza;
	public InputField inpConst;
	public InputField inpCarisma;
	public InputField inpInt;
	public InputField inpPeso;

    public GameObject panelMensagem;

    public Dropdown dropRaca, dropClasse, DropSexo;
    public String valueRaca, valueClasse, valueSexo;

  

    // a b c d e f g h i j k l m n o p q r s t u v w x y z
    List<string> m_DropRaca = new List<string> { "Anzy", "Cerumano", "Cyborgue", "Hayken", "Leopy", "Mayen", "Metamorfe", "Ravenney", "Sereia Espacial", "Targen", "Yahiel" };
    List<string> m_DropClasse = new List<string> { "Arqueologista", "Bombardeador", "Cientista", "Controladores", "Cômico", "Guerreiro", "Lutador", "Mágico", "Marauder", "Médico", "Pistoleiro" };
    List<string> m_DropSexo = new List<string> { "Masculino", "Feminino", "Não informado" };


    public void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        panelMensagem.SetActive(false);

        dropRaca.ClearOptions();
        dropRaca.AddOptions(m_DropRaca);

        dropClasse.ClearOptions();
        dropClasse.AddOptions(m_DropClasse);

        DropSexo.ClearOptions();
        DropSexo.AddOptions(m_DropSexo);

    }

    public void salvaDados ()

	{
    
        string raca = dropRaca.options[dropRaca.value].text; 
        string classe = dropClasse.options[dropClasse.value].text;
        string sexo = DropSexo.options[DropSexo.value].text;
        //Recebe do input
        string nome = inpNome.text;
        //string raca = inpRaça.text;
        
        Debug.Log(raca);
      // string classe = inpClasse.text;
		int idade = Int16.Parse (inpIdade.text);
		//string sexo = inpSexo.text;
		int nivel = Int16.Parse (inpNivel.text);
		float experiencia = float.Parse (inpXP.text); 
		float peso = float.Parse (inpPeso.text);


		//Atributos base
		int forca = Int16.Parse (inpForça.text);
		int destreza = Int16.Parse (inpDestreza.text);
		int constituicao = Int16.Parse (inpConst.text);
		int inteligencia = Int16.Parse (inpInt.text);
		int carisma = Int16.Parse (inpCarisma.text);

		//Atributos extra
		//Calculados a partir dos atributos base 

		int def = destreza + constituicao;
		int vida = 5 + constituicao + nivel; 
		int acerto = destreza * 2; 
		int acrobacia = forca + destreza; 

		double aux = forca * 2;
		double aux2 = aux + (peso * 0.2);

		int carga = Convert.ToInt16 (Math.Round (aux2));
		//Math.Round (carga, MidpointRounding.AwayFromZero);
		int charme = carisma * 2; 
		int concentracao = inteligencia * 2; 

		aux = destreza * 2;
		aux2 = aux + carisma;
		aux = aux2 / 2;

		//Convert.ToInt16 (Math.Floor( aux ));
		int furtividade = Convert.ToInt16 (Math.Round (aux));
		int intimidacao = (forca + carisma); 

		aux = inteligencia * 2;
		aux2 = destreza + aux;
		aux = aux2 / 2;

		int investigacao = Convert.ToInt16 (Math.Round (aux));
		int manipulacao = carisma + inteligencia; 
		int poder_bruto = forca * 2; 
		int reflexo = inteligencia + destreza; 
		int sorte = carisma + destreza; 
		int vigor = constituicao * 2; 

		aux = constituicao + destreza;
		aux2 = aux / 2;	

		int deslocamento = Convert.ToInt16 (Math.Round (aux2));

		//Insert na tabela

		FichaDAO dao = new FichaDAO ();

		//dao.ConsultaTudo ();

		dao.Inserir (nome, def, raca, classe, idade, sexo,
			nivel, experiencia, vida, acerto, acrobacia, carga, charme, 
			concentracao, furtividade, intimidacao, investigacao, manipulacao, 
			poder_bruto, reflexo, sorte, vigor, deslocamento, forca, destreza,
			constituicao, inteligencia, carisma, peso);


        panelMensagem.SetActive(true);


	}

}
