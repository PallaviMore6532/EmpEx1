using System.ComponentModel.DataAnnotations.Schema;

namespace EmpEx1.Models
{
	public class EmpEducation
	{
		public Int64 EmpEducationID {  get; set; }
		public string CollegeName { get; set; }
		public string Field { get; set; }
		public Int64 TotalMarks { get; set; }
		public Int64 ObtainMarks { get; set; }
		public string standard { get; set; }
		[ForeignKey("Emp")]
		public Int64 EmpID {  get; set; }
		public virtual Emp Emp { get; set; }
	}
}
