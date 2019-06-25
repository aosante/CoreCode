using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class FAQManagement
    {
        private readonly FAQCrudFactory crudFaq;

        public FAQManagement()
        {
            crudFaq = new FAQCrudFactory();

        }

        public void Create(FAQ Faq)
        {
            
                var c = crudFaq.Retrieve<FAQ>(Faq);

                if (c != null)
                {
                    //FAQ already exist
                    
                } else { crudFaq.Create(Faq); }

                
          
        }

        public List<FAQ> RetrieveAll()
        {
            return crudFaq.RetrieveAll<FAQ>();
        }

        public List<FAQ> RetrieveAvailable()
        {
            return crudFaq.RetrieveAvailable<FAQ>();
        }

        public List<FAQ> RetrieveUnavailable()
        {
            return crudFaq.RetrieveUnavailable<FAQ>();
        }

        public FAQ RetrieveById(FAQ Faq)
        {
            return crudFaq.Retrieve<FAQ>(Faq);
        }

        public void Update(FAQ Faq)
        {
            crudFaq.Update(Faq);
        }

        public void Delete(FAQ Faq)
        {
            crudFaq.Delete(Faq);
        }
    }
}
