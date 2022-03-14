using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RdsPostgreSqlAwsIamAuthenticationDotNet6Demo.Models
{
    public class ToDo
    {
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }
		public string? Title { get; set; }

		public DateTime CreatedOn { get; set; }
	}
	public class User : IdentityUser
	{
		public bool FirstLogin { get; set; }
	}
	}
	