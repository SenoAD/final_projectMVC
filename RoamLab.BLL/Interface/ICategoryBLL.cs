using System;
using System.Collections.Generic;
using System.Text;
using RoamLab.BLL.DTO;

namespace RoamLab.BLL.Interface
{
	public interface ICategoryBLL
	{
		IEnumerable<CategoryDTO> GetAll();
	}
}
