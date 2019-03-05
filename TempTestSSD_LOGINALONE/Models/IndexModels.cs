using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace TempTestSSD_LOGINALONE.Models
{
    public class Upload
    {

        [Display(Name = "Upload File - .CS files only")]
        [ValidateFile]//This is custom Attribute class, Can be removed
        public IFormFile codeFile { get; set; }


        public string codeSnippet { get; set; }
    }

    public class ValidateFileAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            string[] AllowedFileExtensions = new
                string[] { ".cs" };

            var file = value as IFormFile;

            if (value == null)
            {
                return true;
            }

            if (!AllowedFileExtensions.Contains((file != null) ?
                file.FileName.Substring(file.FileName.LastIndexOf('.')).ToLower()
                : string.Empty))
            {
                ErrorMessage = "Please upload Your code of type: " +
                    string.Join(", ", AllowedFileExtensions);
                return false;
            }
            else
                return true;
        }
    }

}
