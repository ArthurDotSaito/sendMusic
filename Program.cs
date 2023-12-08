
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

        string folder = Path.Combine("musics");
        var musicFiles = Directory.GetFiles(folder, "*.mp3").Select(Path.GetFileNameWithoutExtension).ToArray();
        
        Console.WriteLine("Escolha uma música para enviar");
        for (int i = 0; i < musicFiles.Length; i++)
        {
            Console.WriteLine($"{i + 1}: {musicFiles[i]}");
        }
        int choice = Convert.ToInt32(Console.ReadLine()) - 1;
        string selectedMusic = musicFiles[choice];
        string lyricsFilePath = Path.Combine(folder, selectedMusic + ".txt");

        if (File.Exists(lyricsFilePath))
        {
            string[] lyricsLines = File.ReadAllLines(lyricsFilePath);
            SendLyricsInParts(driver, lyricsLines);
        }
        else
        {
            Console.WriteLine("Arquivo de rota não encontrado/Música não encontrada");
        }
        driver.Quit();
    }

    static void SendLyricsInParts(IWebDriver driver, string[] lyricsLines)
    {
        foreach(string line in lyricsLines)
        {
            var sendBox = driver.FindElement(By.CssSelector("div[data-tab='6']"));
            sendBox.SendKeys(line);
            sendBox.SendKeys(Keys.Enter);
            
            Thread.Sleep(1000);
        }
    }
}