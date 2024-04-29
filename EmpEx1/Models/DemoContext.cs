using Microsoft.EntityFrameworkCore;

namespace EmpEx1.Models
{
	public class DemoContext:DbContext
	{
		public DemoContext(DbContextOptions<DemoContext> opt) : base(opt) { }

		public DbSet<Emp> Emps { get; set; }
		public DbSet<EmpEducation> EmpEducations { get; set;}

	}
}
