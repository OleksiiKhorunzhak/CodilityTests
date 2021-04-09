using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UiTests
{
	public class Task2
	{
		// Create a valid login
		private static string validLogin = "login@codility.com";
		// Create a not valid login
		private static string notValidLogin = "unknown@codility.com";
		// Create a email in an invalid form
		private static string notEmailLogin = "unknown";
		// Create a password
		private static string password = "password";
		// Create a main test page url
		private static string url = "https://codility-frontend-prod.s3.amazonaws.com/media/task_static/qa_csharp_login_page/9a83bda125cd7398f9f482a3d6d45ea4/static/attachments/reference_page.html";
		// Create a driver instance for chromedriver
		private static IWebDriver driver = new ChromeDriver();

		public static void Main(string[] args)
		{
			[Test]
			void testLoginFormPresent()
			{
				//Navigate to main test page
				driver.Navigate().GoToUrl(url);
				//Maximize the window
				driver.Manage().Window.Maximize();
				//Find the email input text box using Id
				IWebElement emailInput = driver.FindElement(By.Id("email-input"));
				//Find the password input text box using Id
				IWebElement passwordInput = driver.FindElement(By.Id("password-input"));
				//Find the login Button box using Id
				IWebElement loginButton = driver.FindElement(By.Id("login-button"));

				//Verify if email and password fields and login button displayed on the main page
				Assert.IsTrue(emailInput.Displayed && passwordInput.Displayed && loginButton.Displayed );
				//Close the browser
				driver.Close();
			}

			[Test]
			void testValidCredential()
			{
				// Create a valid text message
				string expectedText = "Welcome to Codility";

				//Navigate to main test page
				driver.Navigate().GoToUrl(url);
				//Maximize the window
				driver.Manage().Window.Maximize();
				//Find the email input text box using Id
				IWebElement emailInput = driver.FindElement(By.Id("email-input"));
				//Enter valid email in email input text box
				emailInput.SendKeys(validLogin);
				//Find the password input text box using Id
				IWebElement passwordInput = driver.FindElement(By.Id("password-input"));
				//Enter valid email in email input text box
				passwordInput.SendKeys(password);
				//Find the login Button box using Id
				IWebElement loginButton = driver.FindElement(By.Id("login-button"));
				//Click Login button
				loginButton.Click();
				//Find the password input text box using Id
				IWebElement successmessage = driver.FindElement(By.CssSelector("#container > div.message.success"));
				//Get text from successmessage
				string actualText = successmessage.Text;

				//Verify if message succes match expected text
				Assert.IsTrue(actualText == expectedText);
				//Close the browser
				driver.Close();
			}

			[Test]
			void testCredentialNotValid()
			{
				string expectedText = "You shall not pass! Arr!";

				//Navigate to google page
				driver.Navigate().GoToUrl(url);
				//Maximize the window
				driver.Manage().Window.Maximize();
				//Find the email input text box using Id
				IWebElement emailInput = driver.FindElement(By.Id("email-input"));
				//Enter valid email in email input text box
				emailInput.SendKeys(notValidLogin);
				//Find the password input text box using Id
				IWebElement passwordInput = driver.FindElement(By.Id("password-input"));
				//Enter valid email in email input text box
				passwordInput.SendKeys(password);
				//Find the login Button box using Id
				IWebElement loginButton = driver.FindElement(By.Id("login-button"));
				//Click Login button
				loginButton.Click();
				//Find the password input text box using Id
				IWebElement unsuccessmessage = driver.FindElement(By.CssSelector("#messages > div.message.error"));
				//Get text from unsuccessmessage
				string actualText = unsuccessmessage.Text;
				//Verify if message error match expected text

				Assert.IsTrue(actualText == expectedText);
				//Close the browser
				driver.Close();
			}

			[Test]
			void testEmailValidation()
			{
				string expectedText = "Enter a valid email";

				//Navigate to google page
				driver.Navigate().GoToUrl(url);
				//Maximize the window
				driver.Manage().Window.Maximize();
				//Find the email input text box using Id
				IWebElement emailInput = driver.FindElement(By.Id("email-input"));
				//Enter valid email in email input text box
				emailInput.SendKeys(notEmailLogin);
				//Find the password input text box using Id
				IWebElement passwordInput = driver.FindElement(By.Id("password-input"));
				//Enter valid email in email input text box
				passwordInput.SendKeys(password);
				//Find the login Button box using Id
				IWebElement loginButton = driver.FindElement(By.Id("login-button"));
				//Click Login button
				loginButton.Click();
				//Get text from emailmessage
				IWebElement emailmessage = driver.FindElement(By.CssSelector("#messages > div.validation.error"));
				//Enter valid email in email input text box
				string actualText = emailmessage.Text;

				//Verify if validation error match expected text
				Assert.IsTrue(actualText == expectedText);
				//Close the browser
				driver.Close();
			}

			[Test]
			void testEmptyCredentials()
			{
				string expectedText = "Email is required";
				string expectedText2 = "Email is required";

				//Navigate to google page
				driver.Navigate().GoToUrl(url);
				//Maximize the window
				driver.Manage().Window.Maximize();
				//Find the login Button box using Id
				IWebElement loginButton = driver.FindElement(By.Id("login-button"));
				//Click Login button
				loginButton.Click();
				//Find the unsucces message using Css
				IWebElement unsuccesmessage = driver.FindElement(By.CssSelector("#messages > div:nth-child(1)"));
				//Get text from emailmessage
				string actualText = unsuccesmessage.Text;
				//Find the unsucces message using Css
				IWebElement unsuccesmessage2 = driver.FindElement(By.CssSelector("#messages > div:nth-child(1)"));
				//Get text from emailmessage 2
				string actualText2 = unsuccesmessage2.Text;

				//Verify if email and password message errors match expected text
				Assert.IsTrue(actualText == expectedText && actualText2 == expectedText2);
				//Close the browser
				driver.Close();
			}
			testLoginFormPresent();
			testValidCredential();
			testCredentialNotValid();
			testEmailValidation();
			testEmptyCredentials();
		}
	}
}
