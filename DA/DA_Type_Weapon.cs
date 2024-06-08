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
    public class DA_Type_Weapon
    {

        public List<Type_Weapon> getTypeWeapons()
        {
            List<Type_Weapon> response = new List<Type_Weapon>();
            string sp = "sp_get_type_weapons";

            using (SqlConnection con = Connection.OriginConnection())
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand(sp, con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Type_Weapon type_Weapon = new Type_Weapon();

                            type_Weapon.id_type = dr.GetInt32(0);
                            type_Weapon.type = dr.GetString(1);
                            type_Weapon.state = dr.GetBoolean(2);
                            response.Add(type_Weapon);
                        }
                        dr.Close();
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally { con.Close(); }
            }
            return response;
        }

        public bool newTypeWeapon(Type_Weapon tw)
        {
            bool responseExecution = false;
            string sp = "sp_insert_Type_Weapon";
            using (SqlConnection con = Connection.OriginConnection())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {
                    SqlCommand cmd = new SqlCommand(sp, con, tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@type_weapon", tw.type);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    //if the insert be succesfull, commit the transaction and set the flag in true
                    if (filasAfectadas > 0)
                    {
                        tran.Commit();
                        responseExecution = true;
                    }

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
                finally
                {
                    tran.Dispose();
                    con.Close();
                }


                return responseExecution;
            }
        }

        public bool updateTypeWeapon(Type_Weapon tw)
        {
            bool responseExecution = false;
            string sp = "sp_update_Type_Weapon";

            using (SqlConnection con = Connection.OriginConnection())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {

                    SqlCommand cmd = new SqlCommand(sp, con, tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_type", tw.id_type);
                    cmd.Parameters.AddWithValue("@type", tw.type);
                    cmd.Parameters.AddWithValue("@state", tw.state);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    //if the update be succesfull, commit the transaction and set the flag in true
                    if (filasAfectadas > 0)
                    {
                        tran.Commit();
                        responseExecution = true;
                    }

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
                finally { tran.Dispose(); con.Close(); }
            }

            return responseExecution;
        }

        public bool deleteTypeWeapon(int id_type)
        {
            bool responseExecution = false;
            string sp = "sp_hide_type_weapon";

            using (SqlConnection con = Connection.OriginConnection())
            {
                con.Open();
                SqlTransaction tran = con.BeginTransaction();
                try
                {

                    SqlCommand cmd = new SqlCommand(sp, con, tran);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id_type", id_type);

                    int filasAfectadas = cmd.ExecuteNonQuery();

                    //if the hide be succesfull, commit the transaction and set the flag in true
                    if (filasAfectadas > 0)
                    {
                        tran.Commit();
                        responseExecution = true;
                    }

                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
                finally { tran.Dispose(); con.Close(); }
            }

            return responseExecution;
        }

    }
}
