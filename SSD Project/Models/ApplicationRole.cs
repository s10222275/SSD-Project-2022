using System;

namespace SSD_Project.Models
{
	public class ApplicationRole :IdentityRole
	{
		public string Description { get; set; }
		public DateTime CreatedDate { get; set; }
		//default properties(Name) in Identity class
		//ApplicationRole stores additional role values
	}
}
