﻿
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

class Program
{
    static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();
        driver.Navigate().GoToUrl("https://web.whatsapp.com");
        
        Console.WriteLine("Escanear o QR Code e pressione Enter");
        Console.ReadLine();

        Console.WriteLine("Digite o nome do contato ou grupo:");
        string contactName = Console.ReadLine();
        var contact = driver.FindElement(By.XPath($"//span[@title='{contactName}']"));
        contact.Click();
        
        
    }
}