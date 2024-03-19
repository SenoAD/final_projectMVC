using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BLL.DTO;
using RoamLab.BLL.Interface;
using RoamLab.DAL;
using RoamLab.DAL.Interface;

namespace RoamLab.BLL
{
	public class CategoryBLL : ICategoryBLL
	{
		private readonly ICategory _categoryDAL;
		public CategoryBLL()
		{
			_categoryDAL = new CategoryDAL();
		}
		public IEnumerable<CategoryDTO> GetAll()
		{
			var listCategoryDTO = new List<CategoryDTO>();
			var listCategory = _categoryDAL.GetAll();
			foreach (var item in listCategory)
			{
				listCategoryDTO.Add(new CategoryDTO
				{
					CategoryID = item.CategoryID,
					Name = item.Name,
					Description = item.Description,
				});
			}
			return listCategoryDTO;
		}
	}
}
