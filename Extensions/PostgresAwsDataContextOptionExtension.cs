using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace RdsPostgreSqlAwsIamAuthenticationDotNet6Demo.Extensions
{
    public static class PostgresAwsDataContextOptionExtension
    {
		public static NpgsqlDbContextOptionsBuilder UseAwsIamAuthentication(this NpgsqlDbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.ProvidePasswordCallback(RequestAwsIamAuthToken);
			return optionsBuilder;
		}

		static string RequestAwsIamAuthToken(string host, int port, string database, string username)
		{
			if (host.EndsWith("rds.amazonaws.com"))
			{
				return Amazon.RDS.Util.RDSAuthTokenGenerator.GenerateAuthToken(host, port, username);
			}
			else
			{
				return $"{username}";
			}
		}
	}
}
