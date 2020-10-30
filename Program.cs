using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace filesearch
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter The Word to be searched");
                String Search = Console.ReadLine();
                var watch = new System.Diagnostics.Stopwatch();
                string [] filePaths;
                var List = new List<String>() ;
                var OutputList = new List<String>();
                int TotalCount=0;
                String Ext;
                filePaths = Directory.GetFiles(@"C:\Users\LENOVO\source\repos\ConsoleApp3\ConsoleApp3\New folder\");
                foreach (var x in filePaths)
                {
                    Ext = Path.GetExtension(x);
                    if (Ext == ".txt")
                    {
                        List.Add(x);                                                                        //add all the file paths to the list
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }

                watch.Start();                                                                          //start execution timer

               
                foreach (var x in List)
                {
                   
                    string[] a = File.ReadAllLines(x);

                  //  Console.WriteLine(   $"count of the word  { a.Count(x => x.IndexOf(Search) != -1)}");
                    TotalCount += a.Count(x => x.IndexOf(Search) != -1);                                //increment the totalcount of the words


                    // Console.WriteLine(a.Any(x => x.IndexOf(Search) != -1));
                   if (a.Any(x => x.IndexOf(Search) != -1))                                            //finding if the word is present in the file
                    {
                        // Console.WriteLine($"Found In File {x}");
                        OutputList.Add(Path.GetFileName(x));//adding the found files to the output list
                    }
                    
                    

                }

                watch.Stop();                                                                            //stop execution timer
                Console.WriteLine($"Word Is Found in These Files:");
                foreach (var x in OutputList)
                Console.WriteLine($"{x}");
                Console.WriteLine($"Total Count = {TotalCount}");
                Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            }
            catch
            {
                Console.WriteLine("Error");
            }

        }
    }
}
