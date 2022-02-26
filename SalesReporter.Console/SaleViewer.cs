class SaleViewer{

    public int totalNumberSales { get; set; }
    public int totalItemSold { get; set; }
    public double totalSoldAmount { get; set; }

    public SaleViewer(){
        totalNumberSales = 0;
        totalItemSold = 0;
        totalSoldAmount = 0.0;
    } 

    

    public void printSalesViewer(){

        double averageSalesAmount = Math.Round(totalSoldAmount / totalNumberSales,2);
        double averageItemSoldAmount = Math.Round(totalSoldAmount / totalItemSold,2);
			 
            printLimiterLine(); 
            printInlineAmount("Number of sales",totalNumberSales.ToString());
            //printInlineAmount("Number of clients",clients.Count.ToString());
            printInlineAmount("Total items sold",totalItemSold.ToString());
            printInlineAmount("Total sales amount",Math.Round(totalSoldAmount,2).ToString());
            printInlineAmount("Average amount/sale",averageSalesAmount.ToString());
            printInlineAmount("Average item price",averageItemSoldAmount.ToString());
            printLimiterLine();

    }

    public void printInlineAmount(string columName, string amount){
         Console.WriteLine($"| {columName.PadLeft(30)} | {amount.PadLeft(10)} |");
    }

    public void printLimiterLine(){
        Console.WriteLine($"+{new String('-',45)}+");
    }

    public void incrementSales(){
        this.totalNumberSales++;
    }

    public void addItemNumber(int itemNumber){
        this.totalItemSold += itemNumber;
    }

    public void addBasketAmount(double basketAmount){
        this.totalSoldAmount += basketAmount;
    }


}