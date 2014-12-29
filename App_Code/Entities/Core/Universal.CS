using System.Configuration;
namespace DBL
{

    public class Universal
    {
        public static string GetConnectionString()
        {
            // TODO: Need to decide on connection string requirements and pick a method below
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
        }
    }
}
