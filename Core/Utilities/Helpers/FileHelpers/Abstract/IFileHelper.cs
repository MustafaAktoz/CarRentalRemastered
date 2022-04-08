using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Helpers.FileHelpers.Abstract
{
    public interface IFileHelper
    {
        string Add(IFormFile file);
        string Update(IFormFile file,string oldFilePath);
        void Delete(string filePath);
    }
}
