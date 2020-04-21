using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IDocumentRepository
    {
        void CreateForFeedBack(List<string> fileName, Guid feedBackId);
        void CreateForFeedBack(string fileName, Guid feedBackId);
        void CreateForDesign(List<string> listFileName, Guid designId);
        void CreateForDesign(string fileName, Guid designId);
        void Delete(Guid designId);
    }
}
