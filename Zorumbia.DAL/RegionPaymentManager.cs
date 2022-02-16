using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zorumbia.DAL
{
    class RegionPaymentManager
    {
        public void Create(RegionPayment c)
        {
            var connection = new SqlCeConnection("");
            try
            {
                var sql = $@"
                    INSERT INTO rp_region_payment (
                        rp_date_12162,
                        rp_region_12162,
                        rp_headcount_12162,
                        rp_limit_12162,
                        rp_paid_12162
                    ) 
                    VALUES(
                        '{c.Date}',
                        '{c.Region}',
                        '{c.Headcount}',
                        '{c.Limit}',
                        '{c.Paid}'
                    )";

                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }

            }
        }

        public void Update(RegionPayment c)
        {
            var connection = new SqlCeConnection("");
            try
            {
                var sql = $@"
                    UPDATE sw_social_worker SET
                    rp_date_12162 = '{c.Date}',
                    rp_region_12162 = '{c.Region}',
                    rp_headcount_12162 = '{c.Headcount}',
                    rp_limit_12162 = '{c.Limit}',
                    rp_paid_12162 = '{c.Paid}'
                    WHERE rp_id_12162 = {c.Id}";
                    
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public void Delete(int id)
        {
            var connection = new SqlCeConnection("");
            try
            {
                var sql = $"DELETE FROM rp_region_payment WHERE rp_id_12162 = {id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
        }

        public RegionPayment GetById(int id)
        {
            var connection = new SqlCeConnection("");
            try
            {
                var sql = $@"
                    SELECT 
                    rp_id_12162, 
                    rp_region_12162,
                    rp_headcount_12162,
                    rp_limit_12162,
                    rp_paid_12162
                    FROM rp_region_payment
                    WHERE rp_id_12162 = {id}";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    var c = new RegionPayment
                    {
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        Date = Convert.ToDateTime(reader.GetValue(1)),
                        Region = Convert.ToInt32(reader.GetValue(2)),
                        Headcount = Convert.ToInt32(reader.GetValue(3)),
                        Limit = Convert.ToInt32(reader.GetValue(4)),
                        Paid = Convert.ToInt32(reader.GetValue(5))
                    };
                    return c;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }

            // if we are here - something went wrong
            return null;
        }

        public List<RegionPayment> GetAll()
        {
            var connection = new SqlCeConnection("");
            var result = new List<RegionPayment>();
            try
            {
                var sql = "SELECT rp_id_12162, rp_date_12162, rp_region_12162, rp_headcount_12162, rp_limit_12162, rp_paid_12162 FROM rp_region_payment";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    var c = new RegionPayment { 
                        Id = Convert.ToInt32(reader.GetValue(0)),
                        Date = Convert.ToDateTime(reader.GetValue(1)),
                        Region = Convert.ToInt32(reader.GetValue(2)),
                        Headcount = Convert.ToInt32(reader.GetValue(3)),
                        Limit = Convert.ToInt32(reader.GetValue(4)),
                        Paid = Convert.ToInt32(reader.GetValue(5))
                    };
                    result.Add(c);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }
            }
            return result;
        }
    }
}
