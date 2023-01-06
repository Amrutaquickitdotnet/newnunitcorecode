using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Intrinsics.X86;

namespace QuickitdotnetSelenium
{
	public class Read_Excel
	{

		[Test, Order(1)]
		public void ReadData()
		{

			string path = @"D:\Trupti\TestData.xls";      // defining path of xls file

			FileStream fs = null;
			try
			{


				fs = new FileStream(path, FileMode.Open, FileAccess.Read);
			}
			catch(FileNotFoundException e)
			{
				   Console.WriteLine(e.ToString());
				Console.WriteLine(e.StackTrace);
			}
			
			//FileStream class responsible to read data from excel

			// create instance of HssFWorkbook
			HSSFWorkbook wb = new HSSFWorkbook(fs);

			// create Object of HssfSheet

			HSSFSheet sh = (HSSFSheet)wb.GetSheet("Data");
			// would like to know how many no. of rows exist in entire excel file

			int totalRows = sh.LastRowNum;
			//Console.WriteLine(totalRows);
			for(int i = 0; i < totalRows; i++)
			{

				// find single row from entire totalnoof rows

				IRow rObj  =sh.GetRow(i);
				rObj.GetCell(1);

				// Find out total no of columns


				// column dependecy is on rows

				int totalColumns = rObj.LastCellNum;

				//Console.WriteLine(totalColumns);  //Print number of columns 

				ICell Cell1 =rObj.GetCell(1);
				Console.WriteLine(Cell1 + " " + totalColumns);

				for (int j =0; j<= totalColumns; j++)
				{

					// get single column

					ICell ce =    rObj.GetCell(j);


					if(ce!=null)
					{


					string str = 	ce.StringCellValue;
				    if (!string.ReferenceEquals(str, null))
						{

							Console.Write(str+"\t");
						}
					} 
				}

				Console.WriteLine(" ");




			}





		}
	}
}
