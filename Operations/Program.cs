using System;
using System.IO;


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
	}




	class MainClass
	{
		public static void Main(string[] args)
		{
			//OperationsModuleHelper.FirstTask();

			Console.WriteLine("Enter the equation type: L-linear, Q-square");
			string type = Console.ReadLine();
			Console.WriteLine("Enter the coefs devided by space ' '");
			string coef = Console.ReadLine();

			//Console.WriteLine("Result: {0}", new Equation(type,coef).Solve());


			Console.Read();
		}


	}
}
