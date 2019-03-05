using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TempTestSSD_LOGINALONE.Models;


namespace TempTestSSD_LOGINALONE.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Retreive(Upload file)
        {

            if (ModelState.IsValid && CheckModelStateCustom(file)) //checking model state as well as our custom checks
            {

                ReportOutputModel Model = CodeReview(file);
                return View("Report", Model);

            }
            else
            {

                return View("Index", file);

            }

        }

        public IActionResult About()
        {
            ViewData["Message"] = "About Us";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Contact Information";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(string errorsss)
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        #region utility

        /// <summary>
        /// Parses a code file into a list of strings of code per instance
        /// </summary>
        /// <param name="file">IFormFile of code that has been uploaded</param>
        /// <returns>List of strings with a line of code in each instance</returns>
        private List<string> FileRead(IFormFile file)
        {
            var result = new List<string>();
            int counter = 1; 

            using (var reader = new StreamReader(file.OpenReadStream())) //Reader allows iteration to add line numbers
            {
                while (reader.Peek() >= 0)
                {
                    result.Add("<b>Line " + counter + " |</b> " + @reader.ReadLine());
                    counter++;
                }

            }

            return result;
        }

        /// <summary>
        /// Parses a code snippet string of code to a list of strings of code per instance 
        /// </summary>
        /// <param name="file">String containing code from textarea</param>
        /// <returns>List of strings with a line of code in each instance</returns>
        private List<string> SnippetRead(string file)
        {
            var result = new List<string>();
            int counter = 1;

            using (System.IO.StringReader reader = new System.IO.StringReader(file)) //Read using reader so that it iterates and we can add line numbers
            {
                while (reader.Peek() >= 0)
                {
                    result.Add("<b>Line " + counter + " |</b> " + @reader.ReadLine());
                    counter++;
                }
            }

            return result;

        }

        /// <summary>
        /// Checks submitted code for vunrabilities and keeps track of any found
        /// </summary>
        /// <param name="file">Viewmodel containg a iformfile or string from textarea</param>
        /// <returns>ReportOutputModel detailing all lines of code with a vunrability, the number of them and a description of vunrabilities</returns>
        private ReportOutputModel CodeReview(Upload file)
        {

            ReportOutputModel Model = new ReportOutputModel();
            Dictionary<string, string> Vunrabilities = SetUpVunrabilities();
            List<string> result;

            //Calls the specific method to handle input parsing
            if (file.codeFile != null)
            {
                result = FileRead(file.codeFile);
            }
            else //if one is null then must be the other
            {
                result = SnippetRead(file.codeSnippet);
            }


            foreach (string Code in result) //Outer loop tracks each specific line of code
            {
                foreach (KeyValuePair<string, string> Vunrabilitie in Vunrabilities)//inner loop checks current line of code for each specific vunrability
                {
                    Regex regexName = new Regex((@"^(.*?(" + Vunrabilitie.Key + @"\b)[^$]*)$"), RegexOptions.IgnoreCase);

                    if ((regexName.Match(Code)).Success)
                    {
                        Model.OutputDictionary.Add(Code + new string(' ', Model.Counter), Vunrabilitie.Value); //adds to model, new string function used to allow duplicate lines with multiple errors
                        Model.Counter++;
                    }
                }
            }

            return Model;
        }

        /// <summary>
        /// Sets up a dictionary with a list of vunrabilities and descriptions
        /// </summary>
        /// <returns>Dictionary containing a vunrability string key and description string value</returns>
        private Dictionary<string, string> SetUpVunrabilities() {

            Dictionary<string, string> Vunrabilities = new Dictionary<string, string>();

            Vunrabilities.Add(".SelectSingleNode", " .SelectSingleNode is a misnamed function and actually selects the first element even if there is multiple matching elements");
            Vunrabilities.Add("Microsoft.AspNetCore", "Versions of Microsoft.AspNetCore before 2.0.9 are vunerable and should be upgraded");
            Vunrabilities.Add("Request.QueryString", "Request.QueryString can accept an injection attack and should not be used for data manipulation");
            Vunrabilities.Add("unsafe", "unsafe methods should be used with caution as this code cannot be verified by the CLR and introduces security and stability risks");
            Vunrabilities.Add("ProcessStartInfo", "Concatanted strings and string references in ProcessStartInfo declerations can be exploited for OS Commnad Injections");
            Vunrabilities.Add("HashPasswordForStoringInConfigFile", "Outdated hashing system that only makes use of MD5 and SHA-1 hashes");
            Vunrabilities.Add("DirectorySearcher", "LDAP injections can occur when input validation to the query is not used");
            Vunrabilities.Add("FormsAuthentication.SignOut", ".SignOut does not kill the authorization token serverside so a replay attack may occur");
            //Add more using the same format if the project is to be expanded

            return Vunrabilities;
        }

        /// <summary>
        /// A Custom check validation to ensure two files or no files are being uploaded
        /// </summary>
        /// <param name="file">View Model containing a iformfile or string from text area</param>
        /// <returns>True or false depending if it is valid</returns>
        private bool CheckModelStateCustom(Upload file)
        {

            bool valid = true;

            if ((file.codeFile == null && file.codeSnippet == null) || (file.codeFile != null && file.codeSnippet != null))
            {
                //Add errors to model state so that user knows what has went wrong
                ModelState.AddModelError("codeSnippet", "You must upload EITHER a code file or snippet");
                ModelState.AddModelError("codeFile", "You must upload EITHER a code file or snippet");
                valid = false;
            }

            return valid;
        }

        #endregion
    }
}
