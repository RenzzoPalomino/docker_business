using BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class DA_Element
    {
        public List<Element> GetElements()
        {
            List<Element> response =  new List<Element>();
            string sp = "sp_get_elements";

            using(SqlConnection con = Connection.OriginConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Element element = new Element();
                            element.id_element = dr.GetInt32(0);
                            element.element = dr.GetString(1);
                            element.state = dr.GetBoolean(2);

                            response.Add(element);
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
