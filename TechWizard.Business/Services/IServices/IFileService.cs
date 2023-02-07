using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechWizard.Business.Services.IServices
{
    public interface IFileService
    {
        Task<string> EditFile(byte[] content, string extension, string containerName, string fileRoute);
        Task<string> SaveFile(byte[] content, string extension, string containerName);
    }
}
