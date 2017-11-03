using UnityEngine;
using System.Collections;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;
using System.IO;

public class BDClass : MonoBehaviour 
{
	void Start ()
	{
		if (!File.Exists (Application.persistentDataPath + "/StarWaveBD.db")) {
			CriarBD ();
		} 
		else 
		{
//			LerBD ();
			//carregar bd
		}
	}

	public static bool CriarBD ()
	{
		string dataSource = "Data Source = " + Application.persistentDataPath + "/StarWaveBD.db";
		string comandoTexto = "CREATE TABLE nome (nome_ID INTEGER PRIMARY KEY AUTOINCREMENT, nome VARCHAR(5) NOT NULL);" +
		                      "CREATE TABLE options (som INTEGER); " +
						      "INSERT INTO options VALUES (1);" +
		                      "CREATE TABLE score (score_ID INTEGER PRIMARY KEY AUTOINCREMENT, score INTEGER NOT NULL);";
		IDbConnection conexao = (IDbConnection)new SqliteConnection (dataSource);

		conexao.Open ();
		IDbCommand comando = conexao.CreateCommand ();
		comando.CommandText = comandoTexto;
		try
		{
			comando.ExecuteNonQuery ();
			Debug.Log("Banco de dados carregado com sucesso");
			return true;
		}

		catch (SqliteException e) 
		{
			Debug.Log (e.Message);
			return false;
		}

		finally 
		{
			conexao.Close ();
			conexao = null;
		}
	}

	public static void AlteraSom ()
	{
		int temp = 0;
		string dataSource = "Data Source = " + Application.persistentDataPath + "/StarWaveBD.db";
		string comandoTexto = "SELECT som FROM options WHERE som=1 OR som=0;";
		IDbConnection conexao = (IDbConnection)new SqliteConnection (dataSource);

		try
		{
			conexao.Open();
			IDbCommand comando = conexao.CreateCommand ();
			comando.CommandText = comandoTexto;
			IDataReader leitor = comando.ExecuteReader ();

			while (leitor.Read ()) 
			{
				temp = leitor.GetInt32(0);
			}
			Debug.Log ("DEU CERTO");

		}

		catch (SqliteException e) {
			Debug.Log (e.Message);
		}

		finally {
			conexao.Close ();
			conexao = null;
		}

		if (temp == 0) {
			string comandoTexto1 = "UPDATE options SET som = 1 WHERE som = 0;";
			IDbConnection conexaoOpt = (IDbConnection)new SqliteConnection (dataSource);

			conexaoOpt.Open ();
			IDbCommand comandoOpt = conexaoOpt.CreateCommand ();
			comandoOpt.CommandText = comandoTexto1;
			try {
				comandoOpt.ExecuteNonQuery ();
				Debug.Log ("ATIVOU SOM!!");
			} catch (SqliteException e) {
				Debug.Log (e.Message);
			} finally {
				conexaoOpt.Close ();
				conexaoOpt = null;
			}
		}
		else if (temp == 1)
		{
			string comandoTexto2 = "UPDATE options SET som = 0 WHERE som = 1;";
			IDbConnection conexaoOpt2 = (IDbConnection)new SqliteConnection (dataSource);

			conexaoOpt2.Open ();
			IDbCommand comandoOpt2 = conexaoOpt2.CreateCommand ();
			comandoOpt2.CommandText = comandoTexto2;
			try
			{
				comandoOpt2.ExecuteNonQuery ();
				Debug.Log("DESATIVOU SOM!!");
			}

			catch (SqliteException e) 
			{
				Debug.Log (e.Message);
			}

			finally 
			{
				conexaoOpt2.Close ();
				conexaoOpt2 = null;
			}
		}
	}

	public static void InsertBD (string nomeJogador, string scoreJogador)
	{ 
		string dataSource = "Data Source = " + Application.persistentDataPath + "/StarWaveBD.db";
		string comandoTexto = "INSERT INTO nome (nome) VALUES('" + nomeJogador + "');" +
							  "INSERT INTO score (score) VALUES (" + scoreJogador + ");";
		IDbConnection conexao = (IDbConnection)new SqliteConnection (dataSource);

		conexao.Open ();
		IDbCommand comando = conexao.CreateCommand ();
		comando.CommandText = comandoTexto;
		try
		{
			comando.ExecuteNonQuery ();
			Debug.Log("GRAVOU COM SUCESSO!!");
		}

		catch (SqliteException e) 
		{
			Debug.Log (e.Message);
		}

		finally 
		{
			conexao.Close ();
			conexao = null;
		}
	}

	public static void LerSom (ref int opt)
	{
		string dataSource = "Data Source = " + Application.persistentDataPath + "/StarWaveBD.db";
		string comandoTexto = "SELECT som FROM options WHERE som = 1 OR som = 2;";
		IDbConnection conexao = (IDbConnection)new SqliteConnection (dataSource);

		try
		{
			conexao.Open();
			IDbCommand comando = conexao.CreateCommand ();
			comando.CommandText = comandoTexto;
			IDataReader leitor = comando.ExecuteReader ();

			while (leitor.Read ()) 
			{
				opt = leitor.GetInt32(0);
			}
			Debug.Log ("DEU CERTO");

		}

		catch (SqliteException e) {
			Debug.Log (e.Message);
		}

		finally {
			conexao.Close ();
			conexao = null;
		}
	}

	public static void LerRanking (string[] nome, string[] score, ref int fieldCount)
	{
		string dataSource = "Data Source = " + Application.persistentDataPath + "/StarWaveBD.db";
		string comandoTexto = "SELECT nome.nome, score.score FROM nome INNER JOIN score ON nome.nome_ID = score.score_ID ORDER BY score.score DESC LIMIT 5;";
		IDbConnection conexao = (IDbConnection)new SqliteConnection (dataSource);
		try
		{
			conexao.Open();
			IDbCommand comando = conexao.CreateCommand ();
			comando.CommandText = comandoTexto;
			IDataReader leitor = comando.ExecuteReader ();
			fieldCount = leitor.FieldCount * 2;
			int i = 0;
			while (leitor.Read ()) 
			{
//				for (int i = 0 ; i < nome.Length; i++) 
//				{
					nome[i] = leitor.GetString(leitor.GetOrdinal("nome"));
					Debug.Log(nome[i].ToString());
//				}

//				for (int i = 0 ; i < score.Length; i++) 
//				{
					score[i] = leitor.GetInt32(leitor.GetOrdinal("score")).ToString();
					Debug.Log(score[i].ToString());
//				}
				i++;
			}
			Debug.Log ("Funcionou");

		}

		catch (SqliteException e) {
			Debug.Log (e.Message);
		}

		finally {
			conexao.Close ();
			conexao = null;					
		}
	}
}
