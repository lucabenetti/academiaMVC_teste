using System.Threading;
using System.Threading.Tasks;
using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CS.Test
{
    public class LoginTest
    {
        public IWebDriver InstanciarWebDriver()
        {
            var chromeOptions = new ChromeOptions();
            return new ChromeDriver(chromeOptions);
        }

        [Fact]
        public void Teste_Login()
        {
            var driver = InstanciarWebDriver();
            try
            {
                driver.Navigate().GoToUrl("https://localhost:7187/login");

                Thread.Sleep(5000);

                driver.FindElement(By.Id("Email")).SendKeys("admin@ufg.br");
                driver.FindElement(By.Id("Senha")).SendKeys("admin@UFG123");

                var btnLogar = driver.FindElement(By.Id("btnLogar"));
                btnLogar.Click();

                Thread.Sleep(5000);

                Assert.NotNull(driver.FindElement(By.Id("sair")));
            }
            catch
            {

            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
