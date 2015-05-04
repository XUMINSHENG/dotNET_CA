﻿using System;
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
        private static IUnitOfWork uow = new UnitOfWork();

        private static readonly Lazy<CategoryBLL> lazy =
            new Lazy<CategoryBLL>(() => new CategoryBLL());

        public static CategoryBLL Instance { get { return lazy.Value; } }

        public CategoryBLL(){

        }

        public IQueryable<Category> getAllCategories()
        {
            return uow.CategoryRepository.GetAll();
        }

        public Category getCourseById(int categoryId)
        {
            return uow.CategoryRepository.GetAll().Where<Category>(x => x.CategoryId == categoryId).Single();
        }


    }
}
