﻿using BusinessObjects.Models;
using DataAccessLayer;

namespace Repositories;

public class CategoryRepository : ICategoryRepository
{
    public List<Category> GetCategories() => CategoryDAO.GetCategories();
}