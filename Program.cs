
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Escolha o navegador (1 para Chrome, 2 para Firefox):");
        string browserChoice = Console.ReadLine();
        IWebDriver driver;
        if (browserChoice == "1")
        {
            driver = new ChromeDriver();
        }
        else if (browserChoice == "2")
        {
            driver = new FirefoxDriver();
        }
        else
        {
            Console.WriteLine("Opção inválida.");
            return;
        }
        
        driver.Navigate().GoToUrl("https://web.whatsapp.com");
        driver.Navigate().GoToUrl("https://web.whatsapp.com");

        Console.WriteLine("Escanear o QR Code e pressione Enter");
        Console.ReadLine();

        Console.WriteLine("Digite o nome do contato ou grupo:");
        string contactName = Console.ReadLine();
        var contact = driver.FindElement(By.XPath($"//span[@title='{contactName}']"));
        contact.Click();
        
        
    }
}