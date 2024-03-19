using System;
using System.Collections.Generic;
using System.Text;

namespace RoamLab.BLL.DTO
{
	public class CreateHotelPlaceDTO
	{
		public string Name { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public int LocationID { get; set; }
		public int CategoryID { get; set; }
		public string Facilitation {  get; set; }
	}
}
