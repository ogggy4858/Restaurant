using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementation
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly RestaurantDbContext _context;

        public DocumentRepository(RestaurantDbContext context)
        {
            _context = context;
        }

        public void CreateForFeedBack(List<string> fileName, Guid feedBackId)
        {
            if (fileName == null || feedBackId == null)
            {
                throw new NullReferenceException();
            }
            foreach (var item in fileName)
            {
                Document docu = new Document()
                {
                    FeedBackId = feedBackId,
                    Stauts = Common.CommonStatus.Active,
                    FileName = item
                };

                _context.Documents.Add(docu);
            }
            _context.SaveChanges();
        }

        public void CreateForFeedBack(string fileName, Guid feedBackId)
        {
            throw new NotImplementedException();
        }
    }
}
