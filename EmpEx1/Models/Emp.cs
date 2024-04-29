using System.ComponentModel.DataAnnotations;

namespace EmpEx1.Models
{
	public class Emp
	{
		[Key]
		public Int64 EmpID {  get; set; }
		public string EmpName {  get; set; }

		public virtual List<EmpEducation> EmpEducations { get; set; }

		public Emp()
		{
			this.EmpEducations = new List<EmpEducation>();
		}
	}
}
