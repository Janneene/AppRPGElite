using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.SqliteClient;

public class Conexao : MonoBehaviour {

	public SqliteConnection conn = new SqliteConnection("Data Source = /Plugins/bdTeste.db");

	public void conectar(){
		conn.Open ();
	}
	public void desconectar(){
		conn.Close ();
	}
}
