using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Botoes : MonoBehaviour
{
	/*
Cenas
5 - Tela principal
1 - Tela criar personagem
2 - Tela visualizar ficha
3 - Tela Rolar Dado
4 - Tela para escolher ficha
0 - MenuOnline
	*/

	public void btnHome ()
	{
		SceneManager.LoadScene (5);
		//NetworkManager.singleton.ServerChangeScene ("telaPrincipal");
	}

	public void btnPassarFicha ()
	{
        SceneManager.LoadScene(1);
        //NetworkManager.singleton.ServerChangeScene ("fichaPersonagem");
    }

	public void btnAccFicha ()
	{
		SceneManager.LoadScene (2);
		//NetworkManager.singleton.ServerChangeScene ("visuFicha");
	}

	public void btnPassarRolarDado ()
	{
        SceneManager.LoadScene(3);
        //NetworkManager.singleton.ServerChangeScene ("rolarDado");
	}

	public void btnEscolherFicha ()
	{
		SceneManager.LoadScene (4);
		//NetworkManager.singleton.ServerChangeScene ("escolhaFicha");
	}


}
