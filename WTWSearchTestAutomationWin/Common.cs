using ExcelDataReader;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Search.Query;
using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace WTWSearchTestAutomationWin
{
    #region Common Class
    public static class Common
    {
        #region CreateOutput Excel
        public static void CreateOutputFile(DataTable ResultTable,String OutputDirectory)
        {
            string OutPutDirectory = OutputDirectory;

            var pck = new ExcelPackage();
            var wsDt = pck.Workbook.Worksheets.Add("Search Results");
            FileInfo fi = null;
            wsDt.Cells["A1"].LoadFromDataTable(ResultTable, true, TableStyles.Medium9);
            wsDt.Cells[2, 13, ResultTable.Rows.Count + 2, 15].Style.Numberformat.Format = "mm/dd/yy HH:mm";
            wsDt.Cells[wsDt.Dimension.Address].AutoFitColumns();

            Int32 col = 5;
            for (int row = 2; row <= ResultTable.Rows.Count + 1; row++)
            {
                var Value = wsDt.Cells[row, col].Value;
                var Formula = "HYPERLINK(\"" + Value + "\",\"" + Value + "\")";
                wsDt.Cells[row, col].Formula = Formula;

            }

            wsDt.Calculate();
            wsDt.Cells[2, 5, ResultTable.Rows.Count + 1, 5].Style.Font.UnderLine = true;
            wsDt.Cells[2, 5, ResultTable.Rows.Count + 1, 5].Style.Font.Color.SetColor(Color.Blue);

            wsDt.Column(5).Width = 50;
            wsDt.Column(5).Style.WrapText = true;

            wsDt.Column(7).Width = 50;
            wsDt.Column(7).Style.WrapText = true;

            wsDt.Column(8).Width = 50;
            wsDt.Column(8).Style.WrapText = true;

            wsDt.Cells[1, 1].Value = "Keyword";
            wsDt.Cells[1, 5].Value = "Path";
            wsDt.Cells[1, 6].Value = "DeepLinks";
            wsDt.Cells[1, 7].Value = "Highlighted Summary";
            wsDt.Cells[1, 10].Value = "Result Heading";
            wsDt.Cells[1, 13].Value = "Content created on";
            wsDt.Cells[1, 14].Value = "Last Modified Date";
            wsDt.Cells[1, 15].Value = "Report Created On";

            if (!String.IsNullOrEmpty(OutPutDirectory))
            {
                fi = new FileInfo(OutPutDirectory + "\\SearchResults-" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".xlsx");
            }
            else
            {
                fi = new FileInfo("output\\SearchResults-" + DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + ".xlsx");
            }
            pck.SaveAs(fi);
        }
        #endregion

        #region DataTable Operations
        static DataTable CreateResultDataTable()
        {
            DataTable table = new DataTable();

            table.Columns.Add("SearchKeyword", typeof(string));
            table.Columns.Add("Rank", typeof(Decimal));
            table.Columns.Add("DocId", typeof(string));
            table.Columns.Add("Title", typeof(string));
            table.Columns.Add("SearchPath", typeof(string));
            table.Columns.Add("deeplinks", typeof(string));
            table.Columns.Add("HitHighlightedSummary", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Author", typeof(string));
            table.Columns.Add("ResultHeading", typeof(string));
            table.Columns.Add("RenderTemplateId", typeof(string));
            table.Columns.Add("Culture", typeof(string));
            table.Columns.Add("ContentCreatedOn", typeof(DateTime));
            table.Columns.Add("LastModifiedDate", typeof(DateTime));
            table.Columns.Add("ReportCreatedOn", typeof(DateTime));

            return table;
        }

        private static DataTable UpdateDataTable(DataTable ResultTable, ClientResult<ResultTableCollection> results, String Keyword)
        {
            Int32 intNumberOfResults = 0;
            try
            {
                intNumberOfResults = Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfResults"]);

            }
            catch (Exception ex)
            {
                intNumberOfResults = 10;
            }

            int count = 1;
            
            foreach (ResultTable RTable in results.Value)
            {
                if (RTable.TableType == "RelevantResults" || RTable.TableType == "SpecialTermResults")
                {
                    foreach (var resultRow in RTable.ResultRows)
                    {

                        if (count > intNumberOfResults)
                        { break; }
                        count++;
                        DataRow newItem = ResultTable.NewRow();

                        if(resultRow.Keys.Contains("Title"))
                        {
                            newItem["Title"] = resultRow["Title"];
                        }
                        else if(resultRow.Keys.Contains("PreferredName"))
                        {
                            newItem["Title"] = resultRow["PreferredName"];
                        }
                        if (resultRow.Keys.Contains("Path"))
                        {
                            newItem["SearchPath"] = resultRow["Path"];

                        }
                        else if(resultRow.Keys.Contains("Url"))
                        {
                            newItem["SearchPath"] = resultRow["Url"];
                        }
                        if (resultRow.Keys.Contains("Author"))
                        {
                            newItem["Author"] = resultRow["Author"];
                        }
                        if (resultRow.Keys.Contains("Write"))
                        {
                            if (resultRow["Write"] != null && resultRow["Write"].ToString() != "")
                            {
                                newItem["ContentCreatedOn"] = Convert.ToDateTime(resultRow["Write"].ToString());
                            }
                        }
                        if (resultRow.Keys.Contains("Description"))
                        {
                            if (resultRow["Description"] != null && resultRow["Description"].ToString() != "")
                            {
                                newItem["Description"] = resultRow["Description"];
                            }
                        }
                      
                        if(resultRow.Keys.Contains("HitHighlightedSummary"))
                        {
                           if (resultRow["HitHighlightedSummary"] != null && resultRow["HitHighlightedSummary"].ToString() != "")
                            {
                               newItem["HitHighlightedSummary"] = resultRow["HitHighlightedSummary"].ToString().Replace("<ddd/>","...").Replace("<c0>","").Replace("</c0>","");
                            }
                        }
                        
                        if (resultRow.Keys.Contains("Rank"))
                        {
                            newItem["Rank"] = resultRow["Rank"];

                        }
                        if (resultRow.Keys.Contains("LastModifiedTime"))
                        {
                            if (resultRow["LastModifiedTime"] != null && resultRow["LastModifiedTime"].ToString() != "")
                            {
                                newItem["LastModifiedDate"] = Convert.ToDateTime(resultRow["LastModifiedTime"].ToString());
                            }

                        }
                        newItem["SearchKeyword"] = Keyword;
                        newItem["ResultHeading"] = RTable.ResultTitle;
                        newItem["ReportCreatedOn"] = DateTime.Now.ToString();

                        if (resultRow.Keys.Contains("DocId"))
                        {
                            if (resultRow["DocId"] != null && resultRow["DocId"].ToString() != "")
                            {
                                newItem["DocId"] = resultRow["DocId"].ToString();
                            }

                        }
                        if (resultRow.Keys.Contains("deeplinks"))
                        {
                            if (resultRow["deeplinks"] != null && resultRow["deeplinks"].ToString() != "")
                            {
                                newItem["deeplinks"] = resultRow["deeplinks"].ToString();
                            }
                        }

                        if (resultRow.Keys.Contains("RenderTemplateId"))
                        {
                            if (resultRow["RenderTemplateId"] != null && resultRow["RenderTemplateId"].ToString() != "")
                            {
                                newItem["RenderTemplateId"] = resultRow["RenderTemplateId"].ToString();
                            }
                        }

                        if (resultRow.Keys.Contains("Culture"))
                        {
                            if (resultRow["Culture"] != null && resultRow["Culture"].ToString() != "")
                            {
                                newItem["Culture"] = resultRow["Culture"].ToString();
                            }

                        }




                        ResultTable.Rows.Add(newItem);
                    }
                }

            }


            return ResultTable;

        }
        #endregion

        #region Error Logging
        public static void ErrorLog(String ErrorMessage)
        {
            string strLogText = ErrorMessage;
            string ErrorFolderLocation = ConfigurationManager.AppSettings["LogFolderLocation"];
            string ErrorFileLocation = String.Empty;

            if (!String.IsNullOrEmpty(ErrorFolderLocation))
            {
                ErrorFileLocation = ErrorFolderLocation + "\\WTWSearchTestlogfile.txt";

            }
            else
            {
                ErrorFileLocation = "WTWSearchTestlogfile.txt";
            }

            // Create a writer and open the file:
            StreamWriter log;

            if (!System.IO.File.Exists(ErrorFileLocation))
            {
                log = new StreamWriter(ErrorFileLocation);
            }
            else
            {
                log = System.IO.File.AppendText(ErrorFileLocation);
            }

            // Write to the file:
            log.WriteLine(DateTime.Now);
            log.WriteLine(strLogText);
            log.WriteLine();

            // Close the stream:
            log.Close();

        }

        #endregion

        #region ReadInputExcel
        public static List<string> ReadInputFile(string InputFilePath)
        {

            string filePath = InputFilePath;
            string SheetIndex = ConfigurationManager.AppSettings["InputFileSheetIndex"];
            string RowstoDelete = ConfigurationManager.AppSettings["NoOfRowsToIgnoreInInputFile"];
            string COlumnIndex = ConfigurationManager.AppSettings["CoumnIndexOfKeyword"];


            Int32 intSheetIndex = 0;
            Int32 intRowsToDelete = 0;
            Int32 intColumnIndex = 0;
            if (!string.IsNullOrEmpty(SheetIndex))
            {
                intSheetIndex = Convert.ToInt32(SheetIndex);

            }
            else
            {
                intSheetIndex = 1;
            }
            if (!string.IsNullOrEmpty(RowstoDelete))
            {
                intRowsToDelete = Convert.ToInt32(RowstoDelete);

            }
            else
            {
                intRowsToDelete = 8;
            }
            if (!string.IsNullOrEmpty(COlumnIndex))
            {
                intColumnIndex = Convert.ToInt32(COlumnIndex);

            }
            else
            {
                intColumnIndex = 2;
            }
            List<string> Keywords = null;
            using (var stream = System.IO.File.Open(filePath, FileMode.Open, FileAccess.Read))
            {

                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // 2. Use the AsDataSet extension method
                    DataSet result = reader.AsDataSet();
                    if(intSheetIndex > result.Tables.Count)
                    {
                        throw new Exception("Sheet index "+intSheetIndex +" does not exists in the selected Input file");
                    }

                    if (result != null && result.Tables.Count > 0)
                    {
                        if (intSheetIndex > result.Tables.Count)
                        {
                            throw new Exception("Sheet index " + intSheetIndex + " does not exists in the selected Input file");
                        }
                        if(result.Tables[intSheetIndex - 1].Rows.Count==0)
                        {
                            throw new Exception("No data found in selected file at sheet "+intSheetIndex);

                        }
                        if (result.Tables[intSheetIndex - 1].Rows.Count == intRowsToDelete)
                        {
                            throw new Exception("No data found in selected file at sheet " + intSheetIndex);

                        }

                        if (result.Tables[intSheetIndex-1].Rows.Count > intRowsToDelete)
                        {
                            intColumnIndex = intColumnIndex - 1;
                            Keywords = new List<string>();
                            for (int i = intRowsToDelete; i < result.Tables[intSheetIndex-1].Rows.Count; i++)
                            {
                                DataRow dr = result.Tables[intSheetIndex-1].Rows[i];
                                if (dr[intColumnIndex] != null)
                                {
                                    string keyword = dr[intColumnIndex].ToString();
                                    Keywords.Add(keyword);
                                }

                            }


                        }
                        else
                        {
                            throw new Exception("Number of rows in the input file is less that than 'number of rows to ingnore' defined in settings ");
                        }

                    }
                    else
                    {
                        throw new Exception("Unable to read Input file");

                    }
                    // The result of each spreadsheet is in result.Tables
                }
            }

            return Keywords;
        }

        #endregion

        #region Search Logic
        public static void SearchMethod(ClientContext clientContext, List<String> Keywords,string SearchPath,string KeywordQuery,string sourceID,string outputDir,string RankingMOdelID,string RefinedBy,string SortBy,string strSortDirection, string groupBy,string useQueryRule,string Scope,string siteURL)
        {
            Int32 intNumberOfResults = Convert.ToInt32(ConfigurationManager.AppSettings["NumberOfResults"]);


            String CurrentQuery = String.Empty;
            //Search for each Keyword and write into Sharepoint List
            KeywordQuery keywordQuery = new KeywordQuery(clientContext);
            

             Guid guid = Guid.Empty;

            // Set Result Source if specifed in the Configuration File
            if (sourceID != null && sourceID != "" && sourceID != string.Empty)
            {
                guid = new Guid(sourceID.Trim());

            }

            DataTable ResultTable = CreateResultDataTable();
            foreach (string keyword in Keywords)
            {

                CurrentQuery = String.Empty;
               
                if (guid != Guid.Empty)
                {
                    keywordQuery.SourceId = guid;
                }
                if (!String.IsNullOrEmpty(KeywordQuery))
                {
                    if (KeywordQuery.Contains("{SearchBoxQuery}"))
                    {
                        CurrentQuery = KeywordQuery.Replace("{SearchBoxQuery}", keyword);
                    }
                    else
                    {
                        CurrentQuery = keyword;
                    }
        
                }
                else
                {
                    CurrentQuery = keyword;
                }

                if (!String.IsNullOrEmpty(SearchPath))
                {
                    CurrentQuery = String.Format("{0} AND Path:\"{1}\"", CurrentQuery, SearchPath.Trim());
                }



                //if (sourceID != "b09a7990-05ea-4af9-81ef-edfab16c4e31" && Scope != "This Site") //if source is not People search Or This Site
                //{
                //    if (!CurrentQuery.Contains("-ContentClass=urn:content-class:SPSPeople"))
                //    {
                //        CurrentQuery = CurrentQuery + " -ContentClass=urn:content-class:SPSPeople";
                //    }
                //}

                keywordQuery.RowLimit = intNumberOfResults;
                keywordQuery.QueryText = CurrentQuery;


                if (!String.IsNullOrEmpty(RankingMOdelID))
                {
                 keywordQuery.RankingModelId = RankingMOdelID;
                }
                if(!string.IsNullOrEmpty(RefinedBy))
                {
                    keywordQuery.RefinementFilters.Add(RefinedBy);
                }
                if (!string.IsNullOrEmpty(SortBy))
                {
                    if(strSortDirection=="Ascending")
                    {
                        keywordQuery.SortList.Add(SortBy, SortDirection.Ascending);
                    }
                    else
                    {
                        keywordQuery.SortList.Add(SortBy, SortDirection.Descending);
                    }
                }
                if(!string.IsNullOrEmpty(groupBy))
                {
                    keywordQuery.CollapseSpecification = groupBy;
                    
                }
               
                if (useQueryRule=="True")
                {
                    keywordQuery.EnableQueryRules = true;
                }
                else
                {
                    keywordQuery.EnableQueryRules = false;
                }
                keywordQuery.ProcessBestBets = true;
                if (Scope == "This Site")
                {
                    if(!String.IsNullOrEmpty(siteURL))
                    {
                        keywordQuery.HiddenConstraints = String.Format("site:\"{0}\"", siteURL);
                    }
                   
                }
                else if (Scope == "People")
                {
                    keywordQuery.SourceId = new Guid("b09a7990-05ea-4af9-81ef-edfab16c4e31"); // This is GUID for People Source 
                }
                SearchExecutor searchExecutor = new SearchExecutor(clientContext);

                ClientResult<ResultTableCollection> results = searchExecutor.ExecuteQuery(keywordQuery);
                clientContext.ExecuteQuery();
                ResultTable = UpdateDataTable(ResultTable, results, keyword);
                if(ResultTable.Rows.Count==0)
                {
                    throw new Exception("No Results Found!!!");
                }

            }

            Common.CreateOutputFile(ResultTable, outputDir.Trim());
        }

        #endregion

        #region Encode/Decode Password
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }

        public static string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }
        #endregion

        #region Update App Config
        public static void UpdateConfig(String KeyName, String Value)
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            foreach (XmlElement element in xmlDoc.DocumentElement)
            {
                if (element.Name.Equals("appSettings"))
                {
                    foreach (XmlNode node in element.ChildNodes)
                    {
                        if (node.Attributes[0].Value.Equals(KeyName))
                        {
                            node.Attributes[1].Value = Value;
                        }
                    }
                }
            }

            xmlDoc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);

            ConfigurationManager.RefreshSection("appSettings");
        }
        #endregion

        #region
        public static List<ResultSource> ReadSourceFile()
        {
            XDocument doc = XDocument.Load("SourceList.xml");
            List<ResultSource> list = new List<ResultSource>();

            foreach (XElement el in doc.Root.Elements())
            {

                list.Add(new ResultSource(el.Attribute("Name").Value, el.Attribute("ID").Value));
            }
            return list;
        }

        public static List<Rank> ReadRankListFile()
        {
            XDocument doc = XDocument.Load("RankList.xml");
            List<Rank> list = new List<Rank>();

            foreach (XElement el in doc.Root.Elements())
            {

                list.Add(new Rank(el.Attribute("Name").Value, el.Attribute("ID").Value));
            }
            return list;
        }
        #endregion
    }
    #endregion

    #region Result Source Class
    public class ResultSource
    {
        public String Name { get; set; }
        public String ID { get; set; }
        public ResultSource(String Name,String ID)
        {
            this.Name = Name;
            this.ID = ID;
        }
    }
    #endregion

    #region Rank Class
    public class Rank
    {
        public String Name { get; set; }
        public String ID { get; set; }
        public Rank(String Name, String ID)
        {
            this.Name = Name;
            this.ID = ID;
        }
    }
    #endregion
}
