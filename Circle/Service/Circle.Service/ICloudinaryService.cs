using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Circle.Service
{
    public interface ICloudinaryService
    {

        Task<Dictionary<string, object>> UploadFile(IFormFile file);
    }
}
