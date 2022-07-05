using System.Collections;
using System.Collections.Generic;
using System.Data;
using Mono.Data.SqliteClient;
using System;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscolhaFicha: MonoBehaviour
{
	public static int id = 0;
	public Dropdown dropEscolher;

	List<Dropdown.OptionData> m_Messages = new List<Dropdown.OptionData> ();
	List<int> control = new List<int> ();
	int aux = 0;

	void Start ()
	{
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        Debug.Log ("EscolhaFicha");
		CarregaDropDownList ();
	}
	//método que carrega o DropDownLIst
	public void CarregaDropDownList ()
	{ 
		
		IDictionary<int, string> listaC = new Dictionary<int,string> ();
		FichaDAO dficha = new FichaDAO ();

		listaC.Clear ();
		listaC = dficha.ConsultaProDrop ();
		dropEscolher.ClearOptions ();

		foreach (int strKey in listaC.Keys) {
			Dropdown.OptionData data = new Dropdown.OptionData ();
			data.text = listaC [strKey];
			m_Messages.Add (data);
			control.Add (strKey);
			aux++;	
		}
		dropEscolher.AddOptions (m_Messages);
	}

	public void retornaId ()
	{
		string teste = dropEscolher.captionText.text;
		int valor = dropEscolher.value;
		EscolhaFicha.id = control [valor];
	}

	public void btnExcluir ()
	{
		retornaId ();
		FichaDAO dao = new FichaDAO ();
		dao.Deletar (id);
		dropEscolher.options.RemoveAt (dropEscolher.value);
		dropEscolher.value = 0;
	}

	public void btnVisualizar ()
	{
		retornaId ();
		SceneManager.LoadScene (2);
	}




}
