public static class Program
{
	public struct RowInfos {
		public RowInfos(int index, int size, string name) {
			Index = index;
			Size = size;
			Name = name;
		}

		public int Index;
		public int Size;
		public string Name;
	}

	public static List<RowInfos> fillRows(string row) {
		var rowInfos = new List<RowInfos>();

		int i = 0;
		foreach (var columName in row.Split(',')) {
			rowInfos.Add(new RowInfos(i++, columName.Length, columName));
		}

		return rowInfos;
	}

	//lots of comments!
	public static void Main(string[] args)
	{
		//add a title to our app  
		Console.WriteLine("=== Sales Viewer ===");
		//extract the command name from the args  
		string command = args.Length > 0 ? args[0] : "unknown";  
		string file = args.Length >= 2 ? args[1] : "./data.csv";
		//read content of our data file  
		//[2012-10-30] rui : actually it only works with this file, maybe it's a good idea to pass file //name as parameter to this app later?  
		string[] dataContentString = File.ReadAllLines(file);  
		//if command is print  
		if (command == "print")  
		{  
			//Print header line
			string headerLine = dataContentString[0];
			var headerInfos = fillRows(headerLine);  
			
			var headerString = String.Join(
				" | ", 
				headerInfos.Select(x=>x.Name).Select(
					(val,ind) => val.PadLeft(16)));
			Console.WriteLine("+" + new String('-', headerString.Length + 2) + "+");
			Console.WriteLine("| " + headerString + " |");
			Console.WriteLine("+" + new String('-', headerString.Length + 2) + "+");
			
			//Print content lines
			var contentLines = dataContentString.Skip(1);
			
			foreach (string line in contentLines) { 
				var contentInfos = fillRows(line);

				 //extract columns from our csv line and add all these cells to the line  
				 var cells = line.Split(',');
				 var tableLine  = String.Join(
		            " | ", 
		            
		            line.Split(',').Select(
			            (val,ind) => val.PadLeft(16)));
	            Console.WriteLine($"| {tableLine} |");
			 } 
			 Console.WriteLine("+" + new String('-', headerString.Length+2) + "+");

			// if command is report
		} 
		else if (command == "report")  
		{  
		 //get all the lines without the header in the first line  
			 var otherLines = dataContentString.Skip(1);
			 SaleViewer saleViewer = new SaleViewer();

			 //declare variables for our conters  
			 int number1 = 0, number2 = 0;  
			 double number4 = 0.0, number5 = 0.0, number3 = 0;  
			 HashSet<string> clients = new HashSet<string>();  
			 DateTime last = DateTime.MinValue;  
			 //do the counts for each line  
			 foreach (var line in otherLines)  
			 {   
	 			var cells = line.Split(',');  

				// Increment Number of Sales 
	 			saleViewer.incrementSales(); 
	 			// Add the number of item solds at the total
				saleViewer.addItemNumber(int.Parse(cells[2]));  
				// Add the amount of basket at the total
				saleViewer.addBasketAmount(double.Parse(cells[3]));   
			 } 
			 saleViewer.printSalesViewer();
		}  
		else  
		{  
 			 Console.WriteLine("[ERR] your command is not valid ");  
			 Console.WriteLine("Help: ");  
			 Console.WriteLine("    - [print]  : show the content of our commerce records in data.csv");  
			 Console.WriteLine("    - [report] : show a summary from data.csv records ");  
		}
	}
}
