using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System.IO;
using static System.Console;
using System.Threading.Tasks;

namespace scraper
{
    class Program
    {
        static void Main(string[] args)
        {
			//Insert website URL here:
            var webGet = new HtmlWeb();
            var document = webGet.Load("https://signal.nfx.com/investor-lists/top-fintech-pre-seed-investors");
            
            //To ouput entire HTML in console uncomment line below
            //WriteLine(document.DocumentNode.OuterHtml);

            //Selects everything after div tags
            var htmlNodes = document.DocumentNode.SelectNodes("//div/a");

			//Creates .txt file in folder
			//Writes console output in .txt file instead of console
			//Only works once; must delete .txt file in folder if program already ran once
            FileStream filestream = new FileStream("ListOfFintechVCs.txt", FileMode.Create);
			var streamwriter = new StreamWriter(filestream);
			streamwriter.AutoFlush = true;
			SetOut(streamwriter);
			SetError(streamwriter);
            
            //Writes each line of venture capitalist firms
            foreach (var node in htmlNodes)
			{
				WriteLine(node.Attributes["href"].Value);
			}	
        }
    }
}

/* ========== OLD CODE THAT DIDN'T WORK ==========
		
		const string path = "hi.txt";
        const FileMode mode = FileMode.CreateNew;
        const FileAccess access = FileAccess.Write;
            
        using FileStream file = new FileStream( path, mode, access );
        using StreamWriter writer = new StreamWriter( file );
        
        
        //creates a new .txt file
            const string path = "hi.txt";
            const FileMode mode = FileMode.CreateNew;
            const FileAccess access = FileAccess.Write;
            
            using FileStream file = new FileStream( path, mode, access );
            using StreamWriter writer = new StreamWriter( file );
            
        //writes all of website HTML in .txt file
            var writeMe = document.DocumentNode.OuterHtml;
			File.WriteAllText("hi.txt", writeMe);
            
		//reads HTML from previous file that was created
            const string path1 = "hi.txt";
            const FileMode mode1 = FileMode.Open;
            const FileAccess access1 = FileAccess.Read;
            
            using FileStream fs = new FileStream( path1, mode1, access1 );
            using StreamReader sr = new StreamReader( fs );
			
			for (int i = 0; i < 6; i++) sr.ReadLine();
			
		//writes HTML to console
			while( ! sr.EndOfStream )
            {
				string line = sr.ReadLine();
				WriteLine(line);
            }
        
        
        //OUTPUTS JOHN, TONY, JAMS; CODE FROM GOOGLE
		public static void Main()
		{
			var html = 
			@"<TD class=texte width=""50%"">
				<DIV align=right>Name :<B> </B></DIV>
			</TD>
			<TD width=""50%"">
				<INPUT class=box value=John maxLength=16 size=16 name=user_name>
				<INPUT class=box value=Tony maxLength=16 size=16 name=user_name>
				<INPUT class=box value=Jams maxLength=16 size=16 name=user_name>
			</TD>
			<TR vAlign=center>";

			var htmlDoc = new HtmlDocument();
			htmlDoc.LoadHtml(html);

			var htmlNodes = htmlDoc.DocumentNode.SelectNodes("//td/input");
			
			foreach (var node in htmlNodes)
			{
				Console.WriteLine(node.Attributes["value"].Value);
			}
		}
*/
        
           
