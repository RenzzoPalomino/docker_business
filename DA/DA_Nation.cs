using BE;
using System.Data.SqlClient;
using System.Data;

namespace DA
{
    public class DA_Nation
    {

        public List<Nation> getNations()
        {
            string sp = "sp_get_nations";
            List<Nation> response = new List<Nation>(); 
            using(SqlConnection con = Connection.OriginConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand (sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Nation nation = new Nation();

                            nation.id_nation = dr.GetInt32(0);
                            nation.nation = dr.GetString(1);
                            nation.state = dr.GetBoolean(2);

                            response.Add(nation);
                        }
                        dr.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }
            }

            return response;
        }

    }
}
