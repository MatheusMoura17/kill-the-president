using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using System.IO;
using Accord.Statistics.Filters;
using Accord.Math;
using Accord.MachineLearning.DecisionTrees.Learning;
using Accord.MachineLearning.DecisionTrees;
using Accord.Math.Optimization.Losses;
using Accord.MachineLearning;
using System.Threading;
using ExcelDataReader;
using System;
using System.Globalization;

public class TreeDecision : MonoBehaviour {

	public string trainData;
	public string treeLocation;
	DecisionTree tree;
	Codification codebook;

	// Use this for initialization
	void Start () {
		Train ();
	}

	private void Train() {
		DataTable data = GetDataTable(Application.dataPath +"/"+ trainData);
		DebugTable(data);
		codebook = new Codification(data);
		DataTable symbols = codebook.Apply(data);

		int[][] inputs = symbols.ToArray<int>("LIFE","TOWERS","MELIANTS","TIME","ENEMY_COINS");
		int[] outputs = symbols.ToArray<int>("POSITION");

		var id3learning = new ID3Learning();
		id3learning.Attributes = DecisionVariable.FromData(inputs);

		tree = id3learning.Learn(inputs, outputs);

		double error = new ZeroOneLoss(outputs).Loss(tree.Decide(inputs));
		tree.Save(Application.dataPath +"/"+ treeLocation);
	}

	public void DebugTable(DataTable table) {
		string a = "";
		a += ("--- DebugTable(" + table.TableName + ") ---\n");
		int zeilen = table.Rows.Count;
		int spalten = table.Columns.Count;

		// Header
		for (int i = 0; i < table.Columns.Count; i++) {
			string s = table.Columns[i].ToString();
			a += (String.Format("{0,-20} | ", s));
		}
		a += (Environment.NewLine);
		for (int i = 0; i < table.Columns.Count; i++) {
			a += ("---------------------|-");
		}
		a += (Environment.NewLine);

		// Data
		for (int i = 0; i < zeilen; i++) {
			DataRow row = table.Rows[i];
			//Debug.WriteLine("{0} {1} ", row[0], row[1]);
			for (int j = 0; j < spalten; j++) {
				string s = row[j].ToString();
				if (s.Length > 20) s = s.Substring(0, 17) + "...";
				a += (String.Format("{0,-20} | ", s));
			}
			a += (Environment.NewLine);
		}
		for (int i = 0; i < table.Columns.Count; i++) {
			a += ("---------------------|-");
		}
		a += (Environment.NewLine);
		Debug.Log(a);
	}

	private DataTable GetDataTable(string patch) {
		DataTable dt = new DataTable();

		FileStream stream = File.Open(patch, FileMode.Open, FileAccess.Read);
		IExcelDataReader excelReader;

		if (patch.Contains(".xlsx"))
			excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
		else
			excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

		DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration() {
			ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration() {
				UseHeaderRow = true,
			}
		});
		excelReader.Close();

		return result.Tables[0];
	}

	public Vector2 Compute(int presidentLife,int towers,int meliants,int time,int playerMoney){
		string presidentLifeString = presidentLife >= 500 ? ">=500" : "<500";
		string towersString = towers >= 2 ? ">=2" : "<2";
		string meliantsString = meliants >= 2 ? ">=2" : "<2";
		string timeString = time >= 60 ? ">=60" : "<60";
		string playerMoneyString = playerMoney >= 300 ? ">=300" : "<300";
		return Rank (presidentLifeString, towersString, meliantsString, timeString, playerMoneyString);
	}

	private Vector2 Rank(string presidentLife,string towers,string meliants,string time,string playerMoney) {
		try {
			int[] query = codebook.Transform(new[,]
				{
					{ "LIFE",		presidentLife },
					{ "TOWERS",		towers},
					{ "MELIANTS",	meliants },
					{ "TIME",		time},
					{ "ENEMY_COINS",playerMoney},
				});

			int predicted = tree.Decide(query);

			string answer = codebook.Revert("POSITION", predicted);
			Debug.Log(name + " : " + answer);
			string[] splited=answer.Split('x');
			print(float.Parse(splited[0],CultureInfo.InvariantCulture.NumberFormat));
			print(splited[1]);
			return new Vector2(
				float.Parse(splited[0],CultureInfo.InvariantCulture.NumberFormat),
				float.Parse(splited[1],CultureInfo.InvariantCulture.NumberFormat)
			);
		} catch (Exception) {
			return Vector2.zero;
		}
	}

	/*private bool Rank(string presidentLife,string towers,string meliants,string time,string playerMoney) {
		try {
			int[] query = codebook.Transform(new[,]
				{
					{ "LIFE",		presidentLife },
					{ "TOWERS",		towers},
					{ "MELIANTS",	meliants },
					{ "TIME",		time},
					{ "ENEMY_COINS",playerMoney},
				});

			int predicted = tree.Decide(query);

			string answer = codebook.Revert("POSITION", predicted);
			Debug.Log(name + " : " + answer);
			//return answer == "True" ? true : false;
		} catch (Exception) {
			return null;
		}
	}*/
}
