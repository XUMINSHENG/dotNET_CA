using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseRegistration.Models;
using CourseRegistration.Data;

namespace CourseRegistration.BLL
{
    public class CategoryBLL
    {

        private static readonly Lazy<CategoryBLL> lazy =
            new Lazy<CategoryBLL>(() => new CategoryBLL());

        public static CategoryBLL Instance { get { return lazy.Value; } }

        private CategoryBLL(){

        }

        public List<Category> GetAllCategories()
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                return uow.CategoryRepository.GetAll().ToList();
            }
        }

        public Category GetCourseById(int categoryId)
        {
            using (IUnitOfWork uow = new UnitOfWork())
            {
                return uow.CategoryRepository.GetById(categoryId);
            }
        }


    }
}
