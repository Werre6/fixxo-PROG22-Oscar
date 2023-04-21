namespace Api.Models.Entities
{
	public class CustomerCommentEntity
	{
		// Låtsas att den här entityn går till en NoSql-Databas
		public int Id { get; set; }
		public string CustomerName { get; set; } = null!;
		public string CustomerEmail { get; set; } = null!;
		public string Comment { get; set; } = null!;

	}
}
