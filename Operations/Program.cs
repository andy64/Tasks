using System;
using System.IO;
using ModuleLib;

namespace OperationsModule
{

	public static class OperationsModuleHelper {
		public static void FirstTask() { 
		   string curPath = Directory.GetCurrentDirectory();
			string filePath = Path.GetFullPath(Path.Combine(curPath, @"..\..\", "sampleFile.txt"));
			Console.WriteLine("Enter the folder name. It will be created in the current directory:\n{0}", curPath);
			string folderName = Console.ReadLine();
			string folderPath = Path.Combine(curPath, folderName);
			Directory.CreateDirectory(folderPath);
			string newFilePath = Path.Combine(folderPath, "newFile.txt");
			File.Open(newFilePath, FileMode.Create).Dispose();


			int counter = 0;
			string line;
			string[] lines20 = new string[20];

			// Read the file and display it line by line.
			var file = new StreamReader(filePath);	
			while ((line = file.ReadLine()) != null && counter < 20)
			{
				lines20[counter] = line;
				counter++;
			}
			file.Close();


			FileStream fs = null;
			try
			{
				fs = new FileStream(newFilePath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
				using (var tw = new StreamWriter(fs))
				{
					foreach (var l in lines20)
					{
						tw.WriteLine(l);
					}
				}
			}
			finally
			{
				if (fs != null)
					fs.Dispose();
			}		
		}


		public static void SecondTask() { 
		string type = null;
			string coef = "";
			Func<bool> meetConditions = new Func<bool>(() => {
				bool rez = false;
				string[] coefs = coef.Split(' ');
				if (type.Equals("L")) { rez = coefs[1] == "0";		
				}
				else {
					rez = coefs[0] == "0";
				}
				return !rez;
			});
			do
			{
				Console.WriteLine("Enter the equation type: L-linear, Q-square");
				type = Console.ReadLine();
			} while (type != "L" && type != "Q");

			do
			{
				Console.WriteLine("Enter the coefs devided by space ' '");
				coef = Console.ReadLine();
			} while (!System.Text.RegularExpressions.Regex.IsMatch(coef, @"-?(\d+|\d+\.\d+)\s-?(\d+|\d+\.\d+)\s-?(\d+|\d+\.\d+)") || !meetConditions());

			Equation eq;
			try
			{
				if (type == "L"){ eq = new LinearEquation(coef); }
				else { eq = new QuadraticEquation(coef); }
				Console.WriteLine(eq.Solve());
			}
			catch (Exception e) { Console.WriteLine(e.Message); }


		}
	}





	class MainClass
	{
		public static void Main(string[] args)
		{
			//OperationsModuleHelper.FirstTask();
			OperationsModuleHelper.SecondTask();
			Console.Read();
		}


	}
}
