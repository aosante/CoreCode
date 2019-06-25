using CoreCode.DataAccess.Crud;
using CoreCode.Entities.POJO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreCode.API.Core
{
    public class CategoryManagement
    {
        private readonly CategoryCrudFactory crudCategory;

        public CategoryManagement()
        {
            crudCategory = new CategoryCrudFactory();
        }

        public void Create(Category category)
        {
            crudCategory.Create(category);
        }

        public List<Category> RetrieveAll()
        {
            return crudCategory.RetrieveAll<Category>();
        }

        public List<Category> RetrieveAvailable()
        {
            return crudCategory.RetrieveAvailable<Category>();
        }

        public List<Category> RetrieveUnavailable()
        {
            return crudCategory.RetrieveUnavailable<Category>();
        }

        public Category RetrieveById(Category category)
        {
            return crudCategory.Retrieve<Category>(category);
        }

        public void Update(Category category)
        {
            crudCategory.Update(category);
        }

        public void Delete(Category category)
        {
            crudCategory.Delete(category);
        }

    }
}
