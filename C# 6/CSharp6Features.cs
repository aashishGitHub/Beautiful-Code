using System;
using static System.Console;  //using static qualifier
using static ConsoleApplication1.CustomClass;
using System.Threading.Tasks;
using System.Net.Http;

namespace ConsoleApplication1
{
    class CSharp6Features
    {      
        public static void Main()
        {          
            /*
            In C# 6, you can now add the using static qualifier and reference the WriteLine method by itself as shown below:
            
             */
            WriteLine("Hello");
            HelloCshrpStar();

            //String Interpolation 
            string firstName = "Hacker";
            string lastName = "Kumar";
            Employee emp = new Employee();

            firstName = emp?.Name;
            firstName = emp?.Name ?? "Gadha";


            WriteLine($"{firstName} {lastName} is my name!");

            Task.Factory.StartNew(() => GetSite());
            var httpStatusCode = 402;
            Write("HTTP Error: ");
            
            try
            {
                throw new Exception(httpStatusCode.ToString());
            }
            catch (InvalidOperationException ex)
            {
                // Earlier we could have conditions only in catch block like below
                if (ex.Message.Equals("500"))
                    Write("Bad Request");
                else if (ex.Message.Equals("401"))
                    Write("Unauthorized");
                else if (ex.Message.Equals("402"))
                    Write("Exception Occurred");
                else if (ex.Message.Equals("403"))
                    Write("Forbidden");
                else if (ex.Message.Equals("404"))
                    Write("Not Found");
            }

            catch (Exception ex) when (ex.Message.Equals("400"))
            {
                Write("Bad Request");
                ReadLine();
            }
            catch (Exception ex) when (ex.Message.Equals("401"))
            {
                Write("Unauthorized C#6");
                ReadLine();
            }
            catch (Exception ex) when (ex.Message.Equals("402"))
            {
                Write("Exception Occurred C#6");
                ReadLine();
            }
            catch (Exception ex) when (ex.Message.Equals("403"))
            {
                Write("Forbidden");
                ReadLine();
            }
            catch (Exception ex) when (ex.Message.Equals("404"))
            {
                Write("Not Found");
                ReadLine();
            }
            Read();
        }
    }
    class Employee
    {
        public string Name { get; set; } = "Aashish";
    }
    //Since you have declared CustomClass with the static keyword, you can run the method by just calling the method name. 
    static class CustomClass
    {       
        public static void HelloCshrpStar()
        {
            WriteLine("Hello CsharpStar!");
        }
        public async static Task GetSite()
        {
            HttpClient client = new HttpClient();
            try
            {
                var result = await client.GetStringAsync
                             ("http://www.CsharpStar.com");
                WriteLine(result);
            }
            catch (Exception exception)
            {
                try
                {
                    //This asynchronous request will invoked 
                    // if the first request is failed. 
                    var result = await client.GetStringAsync
                                 ("http://www.easywcf.com");
                    WriteLine(result);
                }

                catch
                {
                    WriteLine("Entered Catch Block");
                }
                finally
                {
                    WriteLine("Entered Finally Block");
                }
            }
        }
    }   
}
