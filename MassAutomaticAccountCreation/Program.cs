using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using OfficeOpenXml;
using System.Timers;
using OpenQA.Selenium.Interactions;

namespace SeleniumRev
{
    class Program
    {
       public static IWebDriver driver;

       public static void Main(string[] args)

        {

            driver = new ChromeDriver();
            



            Console.WriteLine(" please slect between the  two websites " +
                "");
            Console.WriteLine("1.Portuzzel");
            Console.WriteLine("2.Gulfzel");
            string input = Console.ReadLine();
            int value = int.Parse(input);
            switch(value)
                        {
                            case 1:
                                driver = new ChromeDriver();
                                driver.Url = "https://www.portuzzel.com/my-account/";
                                signUpPortuzzelexcel(driver.Url);

                                break;
                            case 2:
                                driver = new ChromeDriver();
                                driver.Url = "https://www.gulfuzel.com/login-register/?tab=register&v=ea8a1a99f6c9";
                                signUpgulfzel(driver.Url);
                                break;
                            default: Console.WriteLine("please enter a valid website "); break;
                        }


        }


   
        public static void signUpgulfzel(String url)
        {

            try
            {
                // Open the Excel file
                using (var package = new ExcelPackage(new FileInfo("Gulf.xlsx")))
                {
                    // Get the first worksheet in the file
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    // Find the last row in the worksheet
                    int lastRow = worksheet.Dimension.End.Row;

                    // Loop through each row in the worksheet
                    for (int row = 2; row <= lastRow; row++) // start from row 2 to skip the header row
                    {
                        // Extract the data from the row
                        string username = worksheet.Cells[row, 1].Value.ToString();
                        string email = worksheet.Cells[row, 2].Value.ToString();
                        string telephone = worksheet.Cells[row, 3].Value.ToString();
                        string psswrd = worksheet.Cells[row, 4].Value.ToString();
                        string firstname = worksheet.Cells[row, 5].Value.ToString();
                        string lastname = worksheet.Cells[row, 6].Value.ToString();
                        // Navigate to the registration page
                        driver.Navigate().GoToUrl(url);
                        driver.Manage().Window.Maximize();
                        WebElement usernameinput = (WebElement)driver.FindElement(By.Name("name"));
                        usernameinput.SendKeys(username);
                        WebElement mailinput = (WebElement)driver.FindElement(By.Name("email"));
                        mailinput.SendKeys(email);
                        WebElement phone = (WebElement)driver.FindElement(By.Name("phone"));
                        phone.SendKeys(telephone);
                        WebElement password = (WebElement)driver.FindElement(By.Name("password"));

                        password.SendKeys(psswrd);
                       
                        WebElement firstnameinput = (WebElement)driver.FindElement(By.XPath("//input[@placeholder='First Name']"));
                        WebElement Lastnameinput = (WebElement)driver.FindElement(By.XPath("//input[@placeholder='Last Name']"));
                        firstnameinput.SendKeys(firstname);
                        Lastnameinput.SendKeys(lastname);
                        WebElement chcbox = (WebElement)driver.FindElement(By.XPath("/html/body/div[1]/section[2]/div/div/div/div/div/div/section/div/div/div/div/div/div/div/div/div[2]/div/div/form/div[8]/div/div"));
                        chcbox.Click();
                        WebElement button = (WebElement)driver.FindElement(By.XPath("/html/body/div[1]/section[2]/div/div/div/div/div/div/section/div/div/div/div/div/div/div/div/div[2]/div/div/form/div[9]/button"));
                        button.Click();
                        Actions actions = new Actions(driver);
                        actions.SendKeys(Keys.Enter).Perform();

                        // Wait for the registration to complete
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                    }
                }
            }
            finally
            {
                // Close the browser
                driver.Quit();
            }
        }

     
        public  static void signUpPortuzzelexcel(String url)
        {
           

            try
            {
                // Open the Excel file
                using (var package = new ExcelPackage(new FileInfo("Port.xlsx")))
                {
                    // Get the first worksheet in the file
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                    // Find the last row in the worksheet
                    int lastRow = worksheet.Dimension.End.Row;

                    // Loop through each row in the worksheet
                    for (int row = 2; row <= lastRow; row++) // start from row 2 to skip the header row
                    {
                        // Extract the data from the row
                        string username = worksheet.Cells[row, 4].Value.ToString();
                        string email = worksheet.Cells[row, 5].Value.ToString();
                        string telephone = worksheet.Cells[row, 3].Value.ToString();
                        string psswrd = worksheet.Cells[row, 6].Value.ToString();
                        string firstname = worksheet.Cells[row, 1].Value.ToString();
                        string lastname = worksheet.Cells[row, 2].Value.ToString();
                        // Navigate to the registration page
                        driver.Navigate().GoToUrl(url);
                        WebElement usernameinput = (WebElement)driver.FindElement(By.Id("rtcl-reg-username"));
                        usernameinput.SendKeys(username);
                        WebElement mailinput = (WebElement)driver.FindElement(By.Id("rtcl-reg-email"));
                        mailinput.SendKeys(email);
                        WebElement phone = (WebElement)driver.FindElement(By.Name("phone"));
                        phone.SendKeys(telephone);
                        WebElement password = (WebElement)driver.FindElement(By.Id("rtcl-reg-password"));
                        WebElement confpassword = (WebElement)driver.FindElement(By.Id("rtcl-reg-confirm-password"));
                        password.SendKeys(psswrd);
                        confpassword.SendKeys(psswrd);
                        WebElement firstnameinput = (WebElement)driver.FindElement(By.Name("first_name"));
                        WebElement Lastnameinput = (WebElement)driver.FindElement(By.Name("last_name"));
                        firstnameinput.SendKeys(firstname);
                        Lastnameinput.SendKeys(lastname);
                        WebElement button = (WebElement)driver.FindElement(By.XPath("/html/body/div[1]/div[3]/div[2]/div/div/div/main/div/div/div/div/div[2]/form/div[7]/input"));
                        Actions actions = new Actions(driver);
                        actions.SendKeys(Keys.Enter).Perform();

                        // Wait for the registration to complete
                        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"File not found: {ex.FileName}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"IO error: {ex.Message}");
            }
            catch (Exception ex) // catch-all exception handler
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Close the browser
                driver.Quit();
            }
        }

    }


  





}
    

