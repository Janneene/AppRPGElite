using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;


public class VisualizarFicha : NetworkBehaviour
{
    //ComboBox 
    public Dropdown dropDado;
    //public Dropdown m_Dropdown;
    List<string> m_DropOptions = new List<string> { "d4", "d6", "d8", "d10", "d12", "d20" };
    //This is the Dropdown
    int valorInputDado = 1;
    int valorBonusDano = 0;
    int m_DropdownValue;
    public string m_Message;
    //public static string msg;
    public static bool ok = false;
	public static Text infoDisplay;
	public static GameObject teste;
	public static Text txtMostrar;

	public Text labAcerto;
	public Text labAcrobacia;
	public Text labCharme;
	public Text labConcentracao;
	public Text labFurtividade;
	public Text labInvestigacao;
	public Text labIntimidacao;
	public Text labManipulacao;
	public Text labBruto;
	public Text labReflexo;
	public Text labSorte;
	public Text labVigor;
	public Text labVida;
	public Text labCarga;
	public Text labDeslocamento;
	public Text labNome;
	public Text lbRolagem;
    public Text lbRolagemAux;
	public Text lbInfo;

    

	public InputField inpVida;
	public InputField inpDef;
	public InputField inpRaca;
	public InputField inpClasse;
	public InputField inpIdade;
	public InputField inpNivel;
	public InputField inpSexo;
	public InputField inpXP;
	public InputField inpCarisma;
	public InputField inpForca;
	public InputField inpDestreza;
	public InputField inpInteligencia;
	public InputField inpConstituicao;
	public InputField inpPeso;
    public InputField inpQtdDado;
    public InputField inpBonusDano;

	public GameObject canvasRolagem;
	public GameObject canvasInfo;
    public GameObject canvasDado;
    public GameObject canvasRolagemAux;


    public Dropdown dropRaca, dropClasse, DropSexo;
    public String valueRaca, valueClasse, valueSexo;

    public int escRaca, escClass, escSexo;

    // a b c d e f g h i j k l m n o p q r s t u v w x y z
    List<string> m_DropRaca = new List<string> { "Anzy", "Cerumano", "Cyborgue", "Hayken", "Leopy", "Mayen", "Metamorfe", "Ravenney", "Sereia Espacial", "Targen", "Yahiel" };
    List<string> m_DropClasse = new List<string> { "Arqueologista", "Bombardeador", "Cientista", "Controladores", "Cômico", "Guerreiro", "Lutador", "Mágico", "Marauder", "Médico", "Pistoleiro" };
    List<string> m_DropSexo = new List<string> { "Masculino", "Feminino", "Não informado" };

    public string raca, sexo;
	public string classe;
	public int idade, nivel, forca, destreza, constituicao, inteligencia, carisma, def, vida, acerto, acrobacia,
		carga, charme, concentracao, furtividade, intimidacao, investigacao, manipulacao, poder_bruto, reflexo, sorte,
		vigor, deslocamento;
	public float peso, experiencia;
    public string auxString;
    public int auxValue;


    public int resultDano = 0, valorRolado = 0;
    public double auxiliar2;
	public int auxiliar, qtd, cont = 0;
	public int d, d2, c;
	public Button btnAcerto;
    public Button btnGirarDado;
	public string respostaValorRolado = null;
    public string respostaProMestre = null;


	public System.Random rmd = new System.Random ();

	Ficha ficha = new Ficha ();

	int idR = EscolhaFicha.id;

	void Start ()
	{
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        Debug.Log ("VisualizarFicha");
		teste = GameObject.Find ("canvasInfo");
		infoDisplay = GameObject.Find ("InfoDisplay").GetComponent<Text> ();
		canvasRolagem.SetActive (false);
		canvasInfo.SetActive (false);
        canvasRolagemAux.SetActive(false);
		carregaFicha ();

        
        //dropDado = GetComponent<Dropdown>();
        dropDado.ClearOptions();
        dropDado.AddOptions(m_DropOptions);

        dropRaca.ClearOptions();
        dropRaca.AddOptions(m_DropRaca);

        dropClasse.ClearOptions();
        dropClasse.AddOptions(m_DropClasse);

        DropSexo.ClearOptions();
        DropSexo.AddOptions(m_DropSexo);

        //showMessage ();

    }

	void Update ()
	{
        updateFicha();
        getAndCalc ();

       
		
	}


	public void getAndCalc ()
	{
		//raca = inpRaca.text;
		//classe = inpClasse.text;

         raca = dropRaca.options[dropRaca.value].text;
         classe = dropClasse.options[dropClasse.value].text;
         sexo = DropSexo.options[DropSexo.value].text;


        bool res;

		res = int.TryParse (inpIdade.text, out idade);
		//sexo = inpSexo.text;
		res = int.TryParse (inpNivel.text, out nivel);
		res = float.TryParse (inpXP.text, out experiencia);

		res = float.TryParse  (inpPeso.text, out peso);


		//Atributos base
		res = int.TryParse (inpForca.text, out forca);
		res = int.TryParse(inpDestreza.text, out destreza);
		res = int.TryParse (inpConstituicao.text, out constituicao);
		res = int.TryParse (inpInteligencia.text, out inteligencia);
		res = int.TryParse (inpCarisma.text, out carisma);

		//Atributos extra
		//Calculados a partir dos atributos base 

		def = destreza + constituicao;
		vida = 5 + constituicao + nivel; 
		acerto = destreza * 2; 
		acrobacia = forca + destreza; 

		double aux = forca * 2;
		double aux2 = aux + (peso * 0.2);

		carga = Convert.ToInt16 (Math.Round (aux2));
		//Math.Round (carga, MidpointRounding.AwayFromZero);
		charme = carisma * 2; 
		concentracao = inteligencia * 2; 

		aux = destreza * 2;
		aux2 = aux + carisma;
		aux = aux2 / 2;

		//Convert.ToInt16 (Math.Floor( aux ));
		furtividade = Convert.ToInt16 (Math.Round (aux));
		intimidacao = (forca + carisma); 

		aux = inteligencia * 2;
		aux2 = destreza + aux;
		aux = aux2 / 2;

		investigacao = Convert.ToInt16 (Math.Round (aux));
		manipulacao = carisma + inteligencia; 
		poder_bruto = forca * 2; 
		reflexo = inteligencia + destreza; 
		sorte = carisma + destreza; 
		vigor = constituicao * 2; 

		aux = constituicao + destreza;
		aux2 = aux / 2;	

		deslocamento = Convert.ToInt16 (Math.Round (aux2));

	}

   

	public void updateFicha ()
	{
		labAcerto.text = Convert.ToString (acerto);
		labAcrobacia.text = Convert.ToString (acrobacia);
		labCarga.text = Convert.ToString (carga);
		labCharme.text = Convert.ToString (charme);
		labConcentracao.text = Convert.ToString (concentracao);
		labDeslocamento.text = Convert.ToString (deslocamento);
		labFurtividade.text = Convert.ToString (furtividade);
		labIntimidacao.text = Convert.ToString (intimidacao);
		labInvestigacao.text = Convert.ToString (investigacao);
		labManipulacao.text = Convert.ToString (manipulacao);
		labBruto.text = Convert.ToString (poder_bruto);
		labReflexo.text = Convert.ToString (reflexo);
		labSorte.text = Convert.ToString (sorte);
		labVida.text = Convert.ToString (vida);
		labVigor.text = Convert.ToString (vigor);
		inpDef.text = Convert.ToString (def);
	}
    public void btnRodarDano()
    {
        m_DropdownValue = dropDado.value;
        m_Message = dropDado.options[m_DropdownValue].text;
        Debug.Log(m_DropdownValue);
        Debug.Log(m_Message);
        valorInputDado = Int32.Parse(inpQtdDado.text);
        valorBonusDano = Int32.Parse(inpBonusDano.text);
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
        respostaValorRolado = "";
        switch (m_DropdownValue)
        {
            case 0:
                //d4
                for (int i = 1; i <= valorInputDado; i++)
                {
                    valorRolado = numeroRandomicos(0, 4);
                    respostaValorRolado += " ( " + valorRolado + " ) + ";
                    resultDano += valorRolado;
                }
                resultDano += valorBonusDano;
                respostaValorRolado += " ( " + valorBonusDano + " ) = " + resultDano;
                showPopOutAux(respostaValorRolado);

                break;

            case 1:
                //d6
                for (int i = 1; i <= valorInputDado; i++)
                {
                    valorRolado = numeroRandomicos(0, 6);
                    respostaValorRolado += " ( " + valorRolado + " ) + ";
                    resultDano += valorRolado;
                }
                resultDano += valorBonusDano;
                respostaValorRolado += " ( " + valorBonusDano + " ) = " + resultDano;
                showPopOutAux(respostaValorRolado);
                break;

            case 2:
                //d8
                for (int i = 1; i <= valorInputDado; i++)
                {
                    valorRolado = numeroRandomicos(0, 8);
                    respostaValorRolado += " ( " + valorRolado + " ) + ";
                    resultDano += valorRolado;
                }
                resultDano += valorBonusDano;
                respostaValorRolado += " ( " + valorBonusDano + " ) = " + resultDano;
                showPopOutAux(respostaValorRolado);
                break;

            case 3: //d10
                for (int i = 1; i <= valorInputDado; i++)
                {
                    valorRolado = numeroRandomicos(0, 10);
                    respostaValorRolado += " ( " + valorRolado + " ) + ";
                    resultDano += valorRolado;
                }
                resultDano += valorBonusDano;
                respostaValorRolado += " ( " + valorBonusDano + " ) = " + resultDano;
                showPopOutAux(respostaValorRolado);
                break;

            case 4: //d12
                for (int i = 1; i <= valorInputDado; i++)
                {
                    valorRolado = numeroRandomicos(0, 12);
                    respostaValorRolado += " ( " + valorRolado + " ) + ";
                    resultDano += valorRolado;
                }
                resultDano += valorBonusDano;
                respostaValorRolado += " ( " + valorBonusDano + " ) = " + resultDano;
                showPopOutAux(respostaValorRolado);

                break;

            case 5: //d20
                for (int i = 1; i <= valorInputDado; i++)
                {
                    valorRolado = numeroRandomicos(0, 20);
                    respostaValorRolado += " ( " + valorRolado + " ) + ";
                    resultDano += valorRolado;
                }
                resultDano += valorBonusDano;
                respostaValorRolado += " ( " + valorBonusDano + " ) = " + resultDano;
                showPopOutAux(respostaValorRolado);

                break;

        }

    }
	public void btnAlterar ()
	{
		FichaDAO dao = new FichaDAO ();
		//Recebe do input

		dao.UpdateColuna (idR, def, raca, classe, idade, sexo,
			nivel, experiencia, vida, acerto, acrobacia, carga, charme, 
			concentracao, furtividade, intimidacao, investigacao, manipulacao, 
			poder_bruto, reflexo, sorte, vigor, deslocamento, forca, destreza,
			constituicao, inteligencia, carisma, peso);

	}

   

	public void carregaFicha ()
	{
		
		FichaDAO dao = new FichaDAO ();
		ficha = dao.ConsultaUm (idR);

		Debug.Log (ficha.exibir ());


       

        auxString = Convert.ToString(ficha.getRaca());
        auxValue = SolucoesElegantes.switchElegante(auxString);
        dropRaca.value = auxValue;
        Debug.Log(auxValue);


        auxString = Convert.ToString(ficha.getClasse());
        auxValue = SolucoesElegantes.switchElegante(auxString);
        dropClasse.value = auxValue;
        Debug.Log(auxValue);

        auxString = Convert.ToString(ficha.getSexo());
        auxValue = SolucoesElegantes.switchElegante(auxString);
        DropSexo.value = auxValue;
        Debug.Log(auxValue);



        labAcerto.text = Convert.ToString (ficha.getAcerto ());
		labAcrobacia.text = Convert.ToString (ficha.getAcrobacia ());
		labCarga.text = Convert.ToString (ficha.getCarga ());
		inpCarisma.text = Convert.ToString (ficha.getCarisma ());
		labCharme.text = Convert.ToString (ficha.getCharme ());
		labConcentracao.text = Convert.ToString (ficha.getConcentracao ());
		inpConstituicao.text = Convert.ToString (ficha.getConstituicao ());
		inpDef.text = Convert.ToString (ficha.getDef ());
		inpDestreza.text = Convert.ToString (ficha.getDestreza ());
		labDeslocamento.text = Convert.ToString (ficha.getDeslocamento ());
		inpXP.text = Convert.ToString (ficha.getExperiencia ());
		inpForca.text = Convert.ToString (ficha.getForca ());
		labFurtividade.text = Convert.ToString (ficha.getFurtividade ());
		inpIdade.text = Convert.ToString (ficha.getIdade ());
		inpInteligencia.text = Convert.ToString (ficha.getInteligencia ());
		labIntimidacao.text = Convert.ToString (ficha.getIntimidacao ());
		labInvestigacao.text = Convert.ToString (ficha.getInvestigacao ());
		labManipulacao.text = Convert.ToString (ficha.getManipulacao ());
		inpNivel.text = Convert.ToString (ficha.getNivel ());
		labNome.text = Convert.ToString (ficha.getNome ());
		inpPeso.text = Convert.ToString (ficha.getPeso ());
		labBruto.text = Convert.ToString (ficha.getPoder_bruto ());
        labReflexo.text = Convert.ToString (ficha.getReflexo ());       
        labSorte.text = Convert.ToString (ficha.getSorte ());
		labVida.text = Convert.ToString (ficha.getVida ());
		labVigor.text = Convert.ToString (ficha.getVigor ());
				
	}

	public int numeroRandomicos (int min, int max)
	{

		return rmd.Next (min+1, max+1);
	}

	public int calcQtdDados (int atributo)
	{
		auxiliar2 = 0;
		auxiliar2 = atributo / 10;
		auxiliar = Convert.ToInt16 (System.Math.Round (auxiliar2));

		return auxiliar;
	}

	public void rolaAcerto ()
	{
		int c = calcQtdDados (acerto) + 1;
        qtd = c;
		Debug.Log (c);
		respostaValorRolado = "Acerto ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);

    }

    public void animacaoDado()
    {
        
        Debug.Log(qtd);
         
        /*
         - Receber quantidades que pode girar o dado
         - Desabilitar botão quando terminar essa quantidade
         
         */
        if (cont < qtd)
        {
            Debug.Log("cont " + cont);
            Debug.Log("qtd" + qtd);
            respostaValorRolado += System.Environment.NewLine + " Dado " + cont + " = " + numeroRandomicos(0, 20);
            cont++;
            showPopOut(respostaValorRolado);
        }
        if (cont >= qtd)
            btnGirarDado.interactable = false;

    }

    public void animacaoDadoAttBase()
    {
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
        respostaValorRolado += System.Environment.NewLine + "| d20 ( " + d + " ) + destreza ( " + destreza + " ) = " + d2;
        showPopOut(respostaValorRolado);
        btnGirarDado.interactable = false;
    }

    public void rolaAcrob ()
	{
		int c = calcQtdDados (acrobacia) + 1;
        qtd = c;
        Debug.Log (c);
		respostaValorRolado = "Acrobacia ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
    }

	public void rolaCharme ()
	{
		int c = calcQtdDados (charme) + 1;
        qtd = c;
        Debug.Log (c);
		respostaValorRolado = "Charme ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
    }

	public void rolaConcentracao ()
	{
		int c = calcQtdDados (concentracao) + 1;
        qtd = c;
        Debug.Log (c);
		respostaValorRolado = "Concentração ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
    }

	public void rolaFurtividade ()
	{
		int c = calcQtdDados (furtividade) + 1;
        qtd = c;
        Debug.Log (c);
		respostaValorRolado = "Furtividade ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
    }

	public void rolaIntimidacao ()
	{
		int c = calcQtdDados (intimidacao) + 1;
        qtd = c;
        Debug.Log (c);
		respostaValorRolado = "Intimidação ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
    }

	public void rolaInvestigacao ()
	{
		int c = calcQtdDados (investigacao) + 1;
        qtd = c;
        Debug.Log (c);
		respostaValorRolado = "Investigação ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
    }

	public void rolaManipulacao ()
	{
		int c = calcQtdDados (manipulacao) + 1;
        qtd = c;
        Debug.Log (c);
		respostaValorRolado = "Manipulação ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
    }

	public void rolaPoderBruto ()
	{
		int c = calcQtdDados (poder_bruto) + 1;
        qtd = c;
        Debug.Log (c);
		respostaValorRolado = "Poder Bruto ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
    }

	public void rolaReflexo ()
	{
		int c = calcQtdDados (reflexo) + 1;
        qtd = c;
        Debug.Log (c);
		respostaValorRolado = "Reflexo ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
    }

	public void rolaSorte ()
	{
		int c = calcQtdDados (sorte) + 1;
        qtd = c;
        Debug.Log (c);
		respostaValorRolado = "Sorte ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
    }

	public void rolaVigor ()
	{
		int c = calcQtdDados (vigor) + 1;
        qtd = c;
        Debug.Log (c);
		respostaValorRolado = "Vigor ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
    }

	public void rolaDeslocamento ()
	{
		int c = calcQtdDados (deslocamento) + 1;
        qtd = c;
        Debug.Log (c);
		respostaValorRolado = "Deslocamento ";
        lbRolagem.text = "";
        canvasRolagem.SetActive(true);
    }

	public void rolaDestreza ()
	{

		respostaValorRolado = "Destreza: ";
		d = numeroRandomicos (0, 20);
		d2 = d + destreza;
		respostaValorRolado += System.Environment.NewLine + "| d20 ( " + d + " ) + destreza ( " + destreza + " ) = " + d2;
        showPopOutAux(respostaValorRolado);

    }

	public void rolaForca ()
	{
		respostaValorRolado = "Força: ";
		d = numeroRandomicos (0, 20);
		d2 = d + forca;
		respostaValorRolado += System.Environment.NewLine + "| d20 ( " + d + " ) + força ( " + forca + " ) = " + d2;
        showPopOutAux(respostaValorRolado);
    }

	public void rolaInteligencia ()
	{
		respostaValorRolado = "Inteligência: ";
		d = numeroRandomicos (0, 20);
		d2 = d + inteligencia;
		respostaValorRolado += System.Environment.NewLine + "| d20 ( " + d + " ) + inteligencia ( " + inteligencia + " ) = " + d2;
        showPopOutAux(respostaValorRolado);
    }

	public void rolaConstituicao ()
	{
		respostaValorRolado = "Constituição: ";
		d = numeroRandomicos (0, 20);
		d2 = d + constituicao;
		respostaValorRolado += System.Environment.NewLine + "| d20 ( " + d + " ) + constituição ( " + constituicao + " ) = " + d2;
        showPopOutAux(respostaValorRolado);
	}

	public void rolaCarisma ()
	{
		respostaValorRolado = "Carisma: ";
		d = numeroRandomicos (0, 20);
		d2 = d + carisma;
		respostaValorRolado += System.Environment.NewLine + "| d20 ( " + d + " ) + carisma ( " + carisma + " ) = " + d2;
        showPopOutAux(respostaValorRolado);
	}

	public void showPopOut (string messagem)
	{
		lbRolagem.text = labNome.text + System.Environment.NewLine + messagem;
		//canvasRolagem.SetActive (true);
		lbInfo.text = labNome.text + System.Environment.NewLine + messagem;
		canvasInfo.SetActive (true);
        canvasRolagem.SetActive(true);
		ok = true; 


		//enviar informações ao mestre
	}
    
    public void showPopOutAux (string messagem)
    {
        lbRolagemAux.text = labNome.text + System.Environment.NewLine  + messagem;
        lbInfo.text = labNome.text + System.Environment.NewLine +  messagem;
        canvasRolagemAux.SetActive(true);
        canvasRolagem.SetActive(false);
        ok = true;
    }

	public void falsePopOut ()
	{
        resultDano = 0;
        btnGirarDado.interactable = true;
        respostaValorRolado = "";
        canvasRolagem.SetActive (false);
        canvasRolagemAux.SetActive(false);
		Debug.Log ("PAUSA");
		ok = false;
        cont = 0;
       
    }

	public void falsePopOutInfo ()
	{
        resultDano = 0;
        btnGirarDado.interactable = true;
        respostaProMestre += respostaValorRolado;
        respostaValorRolado = "";
        canvasRolagemAux.SetActive(false);
		canvasInfo.SetActive (false);
		Debug.Log ("PAUSA");
		ok = false;
        cont = 0;
      //canvasDado.SetActive(false);
    }

}
