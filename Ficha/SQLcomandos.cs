using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System;
public class SQLcomandos : MonoBehaviour {
	public static IDictionary<int, string> listaCombo = new Dictionary<int,string> ();
	public static List<Ficha> listaFicha = new List<Ficha> ();
	public bool ok;
	// Use this for initialization
	private const string Tag = "Riz: SqliteHelper:\t";

	private const string database_name = "my_db";

	public string db_connection_string;
	public IDbConnection db_connection;

	public SQLcomandos()
	{
		db_connection_string = "URI=file:" + Application.persistentDataPath + "/" + database_name;
		Debug.Log("db_connection_string" + db_connection_string);
		db_connection = new SqliteConnection(db_connection_string);
		db_connection.Open();
	}

	~SQLcomandos()
	{
		db_connection.Close();
	}



	//helper functions
	public IDbCommand getDbCommand()
	{
		return db_connection.CreateCommand();
	}

	public IDataReader getAllData(string table_name)
	{
		IDbCommand dbcmd = db_connection.CreateCommand();
		dbcmd.CommandText =
			"SELECT * FROM " + table_name;
		IDataReader reader = dbcmd.ExecuteReader();
		return reader;
	}

	public void tabela(){
		// Create table
		IDbCommand dbcmd = db_connection.CreateCommand();
		string q_createTable = "CREATE TABLE IF NOT EXISTS tb_ficha (id_ficha INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, nome_personagem TEXT NOT NULL, defesa INTEGER NOT NULL, raca TEXT NOT NULL, classe TEXT NOT NULL, idade  NUMERIC NOT NULL,  sexo  TEXT NOT NULL,  nivel  INTEGER NOT NULL,  experiencia  REAL NOT NULL,  vida  INTEGER NOT NULL,  acerto  INTEGER NOT NULL,  acrobacia  INTEGER NOT NULL,  carga  INTEGER NOT NULL,  charme  INTEGER NOT NULL,  concentracao  INTEGER NOT NULL,  furtividade  INTEGER NOT NULL,  intimidacao  INTEGER NOT NULL,  investigacao  INTEGER NOT NULL,  manipulacao  INTEGER NOT NULL,  poder_bruto  INTEGER NOT NULL,  reflexo  INTEGER NOT NULL,  sorte  INTEGER NOT NULL,  vigor  INTEGER NOT NULL,  deslocamento  INTEGER NOT NULL,  forca  INTEGER NOT NULL,  destreza  INTEGER NOT NULL,  constituicao  INTEGER NOT NULL,  inteligencia  INTEGER NOT NULL,  carisma  INTEGER NOT NULL,  peso  REAL NOT NULL)";

		dbcmd.CommandText = q_createTable;
		dbcmd.ExecuteReader();

	}

	public Ficha ConsultaUm (int idC)
	{
		int idConsulta = idC;
		string query = "SELECT * FROM tb_ficha WHERE id_ficha = " + idConsulta + ";";
		Ficha ficha = new Ficha ();
		IDbCommand dbcmd = db_connection.CreateCommand();
		dbcmd.CommandText = query;
		IDataReader reader = dbcmd.ExecuteReader();


		while (reader.Read ()) {
			//instanciar um id para receber o reader
			int id = reader.GetInt16 (0); //Primeira coluna da tabela
			string nome = reader.GetString (1);
			int def = reader.GetInt16 (2);
			string raca = reader.GetString (3);
			string classe = reader.GetString (4);
			int idade = reader.GetInt16 (5);
			string sexo = reader.GetString (6);
			int nivel = reader.GetInt16 (7);
			float experiencia = reader.GetFloat (8);
			int vida = reader.GetInt16 (9);
			int acerto = reader.GetInt16 (10);
			int acrobacia = reader.GetInt16 (11); 
			int carga = reader.GetInt16 (12); 
			int charme = reader.GetInt16 (13); 
			int concentracao = reader.GetInt16 (14); 
			int furtividade = reader.GetInt16 (15); 
			int intimidacao = reader.GetInt16 (16); 
			int investigacao = reader.GetInt16 (17); 
			int manipulacao = reader.GetInt16 (18); 
			int poder_bruto = reader.GetInt16 (19); 
			int reflexo = reader.GetInt16 (20); 
			int sorte = reader.GetInt16 (21); 
			int vigor = reader.GetInt16 (22); 
			int deslocamento = reader.GetInt16 (23);
			int forca = reader.GetInt16 (24); 
			int destreza = reader.GetInt16 (25);
			int constituicao = reader.GetInt16 (26);
			int inteligencia = reader.GetInt16 (27);
			int carisma = reader.GetInt16 (28);
			float peso = reader.GetFloat (29);


			ficha.setId_ficha (id); //idCont 
			ficha.setNome (nome);
			ficha.setDef (def);
			ficha.setDeslocamento (deslocamento);
			ficha.setDestreza (destreza);
			ficha.setAcerto (acerto);
			ficha.setCarga (carga);
			ficha.setRaca (raca);
			ficha.setClasse (classe);
			ficha.setIdade (idade);
			ficha.setSexo (sexo);
			ficha.setNivel (nivel);
			ficha.setExperiencia (experiencia);
			ficha.setVida (vida);
			ficha.setAcrobacia (acrobacia);
			ficha.setCharme (charme);
			ficha.setConcentracao (concentracao);
			ficha.setFurtividade (furtividade);
			ficha.setIntimidacao (intimidacao);
			ficha.setInvestigacao (investigacao);
			ficha.setManipulacao (manipulacao);
			ficha.setPoder_bruto (poder_bruto);
			ficha.setReflexo (reflexo);
			ficha.setSorte (sorte);
			ficha.setVigor (vigor);
			ficha.setForca (forca);
			ficha.setConstituicao (constituicao);
			ficha.setInteligencia (inteligencia);
			ficha.setCarisma (carisma);
			ficha.setPeso (peso);
			close ();

		}
		return ficha;
	}

	public List<Ficha> getListaFicha ()
	{

		return listaFicha;
	}

	public IDictionary<int,string> ConsultaProDrop ()
	{
		string query = "SELECT id_ficha, nome_personagem FROM tb_ficha";
		IDbCommand dbcmd = db_connection.CreateCommand();
		dbcmd.CommandText = query;
		IDataReader reader = dbcmd.ExecuteReader();
		listaCombo.Clear ();
		while (reader.Read ()) {
			int id = reader.GetInt32 (0);
			string nome = reader.GetString (1);
			listaCombo.Add (id, nome);

		}

		close ();
		return listaCombo;
	}

	public void Inserir (string nome, int def, string raca, string classe, int idade, string sexo,
		int nivel, float experiencia, int vida, int acerto, int acrobacia, int carga, int charme, 
		int concentracao, int furtividade, int intimidacao, int investigacao, int manipulacao, 
		int poder_bruto, int reflexo, int sorte, int vigor, int deslocamento, int forca, int destreza,
		int constituicao, int inteligencia, int carisma, float peso)
	{
		
			Debug.Log ("Inserindo");

			string query = "INSERT INTO tb_Ficha( nome_personagem, defesa, raca, classe, idade, sexo, nivel, experiencia," +
				"vida, acerto, acrobacia, carga, charme, concentracao, furtividade, intimidacao," +
				"investigacao, manipulacao, poder_bruto, reflexo, sorte, vigor, forca, destreza, constituicao, " +
				"inteligencia, carisma, peso, deslocamento) " +
				"VALUES ( '" + nome + "' , " + def + ", '" + raca + "', '" + classe + "', " + idade + ", '" + sexo + "', " + nivel + "," +
				" " + experiencia + ", " + vida + ", " + acerto + ", " + acrobacia + ", " + carga + ", " + charme + ", " + concentracao + "," +
				" " + furtividade + ", " + intimidacao + ", " + investigacao + ", " + manipulacao + ", " + poder_bruto + "," +
				" " + reflexo + ", " + sorte + ", " + vigor + ", " + forca + ", " + destreza + ", " + constituicao + ", " + inteligencia + "," +
				" " + carisma + ", " + peso + " , " + deslocamento + ");";
			IDbCommand dbcmd = db_connection.CreateCommand();
			dbcmd.CommandText = query;
			IDataReader reader = dbcmd.ExecuteReader();

			if (query == null) { 
				Debug.Log ("nao tem query" + query);
			} else {
				Debug.Log ("tem query" + query);
			}





		Debug.Log ("Cadastrado com sucesso");
		ok = true;

	}

	public void UpdateColuna (int idAt, int def, string raca, string classe, int idade, string sexo,
		int nivel, float experiencia, int vida, int acerto, int acrobacia, int carga, int charme, 
		int concentracao, int furtividade, int intimidacao, int investigacao, int manipulacao, 
		int poder_bruto, int reflexo, int sorte, int vigor, int deslocamento, int forca, int destreza,
		int constituicao, int inteligencia, int carisma, float peso)
	{

		string query = "UPDATE tb_Ficha SET defesa = " + def +
			", raca = '" + raca + "', classe = '" + classe + "', idade = " + idade +
			", sexo = '" + sexo + "', nivel = " + nivel + ", experiencia = " + experiencia +
			", vida = " + vida + ", acerto = " + acerto + ", acrobacia = " + acrobacia +
			", carga = " + carga + ", charme = " + charme + ", concentracao = " + concentracao +
			", furtividade = " + furtividade + ", intimidacao = " + intimidacao +
			", investigacao = " + investigacao + ", manipulacao = " + manipulacao +
			", poder_bruto = " + poder_bruto + ", reflexo = " + reflexo + ", sorte = " + sorte +
			", vigor = " + vigor + ", forca = " + forca + ", destreza = " + destreza +
			", constituicao = " + constituicao + ", inteligencia = " + inteligencia +
			", carisma = " + carisma + ", peso = " + peso + ", deslocamento = " + deslocamento +
			" WHERE id_ficha = " + idAt + ";";

		Debug.Log (query);
		IDbCommand dbcmd = db_connection.CreateCommand();
		dbcmd.CommandText = query;
		IDataReader reader = dbcmd.ExecuteReader();
		close ();
	}

	public void Deletar (int id)
	{
		int idDeletar = id;
		string query = "DELETE FROM tb_Ficha WHERE id_ficha = " + idDeletar + ";";
		Debug.Log (query);
		IDbCommand dbcmd = db_connection.CreateCommand();
		dbcmd.CommandText = query;
		IDataReader reader = dbcmd.ExecuteReader();
		close ();
	}


	public void close ()
	{
		db_connection.Close ();
	}
}
