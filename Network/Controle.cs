using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Controle : NetworkBehaviour
{
	string mensagem;
	bool teste;
	Text txtM, txtMostrar;
    GameObject canvasInfo;
	// Use this for initialization
	void Start ()
	{
		DontDestroyOnLoad (gameObject);
	}
	 
	// Update is called once per frame
	void Update ()
	{
		teste = VisualizarFicha.ok;
		canvasInfo = VisualizarFicha.teste;
		txtMostrar = VisualizarFicha.infoDisplay;
		if (teste) {
			
			//canvasInfo = VisualizarFicha.teste;
			
			if (isLocalPlayer && !isServer) { //Se eu sou somente cliente 
				
				//assignAuthorityObj.GetComponente<NetworkIdentity> ().AssignClientAuthority (this.Componente<NetworkIdentify> ().ConnectionToClient);
				//txtMostrar.text = mensagem;
				txtM = GameObject.Find ("txtMsg").GetComponent<Text> ();
				mensagem = txtM.GetComponent<Text> ().text;
				Debug.Log (mensagem);
				Debug.Log ("localplayer");
				teste = false;
				canvasInfo.SetActive (false);
				//if (hasAuthority)
				//canvasInfo.GetComponent<NetworkIdentity>().AssignClientAuthority(connectionToClient);
				CmdshowMessage (mensagem);

			} else if (isClient && isServer) {
				if (canvasInfo != null)
					canvasInfo.SetActive (false);
				
			}

		}
	}

	[Command]
	public void CmdshowMessage (string mensagem)
	{
		Debug.Log (txtMostrar);
		Debug.Log ("Entrou no command");
		canvasInfo.SetActive (true);
		txtMostrar.text = mensagem;
		teste = false;
		//canvasInfo.SetActive (false);
	}
}
