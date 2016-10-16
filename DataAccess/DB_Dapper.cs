using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess
{
    public class DB_Dapper
    {
        public int CommandTimeout = 0;
        private SqlConnection conn = null;

        public DB_Dapper()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MainConnection"].ToString());
        }

        public List<T> QueryList<T>(string sql, Dictionary<String, Object> param)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            var list = conn.Query<T>(sql, param, commandType: CommandType.Text).ToList<T>();
            
            conn.Close();

            return list;
        }

        public List<T> ModelListSP<T>(string spName)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            var list = conn.Query<T>(spName, commandType: CommandType.StoredProcedure).ToList<T>();
            
            conn.Close();

            return list;
        }
        public List<T> ModelListSP<T>(string spName, Dictionary<String, Object> param)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            var list = conn.Query<T>(spName, param: param, commandType: CommandType.StoredProcedure).ToList<T>();
            conn.Close();
            return list;
        }

        public int NonQuerySP(string spName, Dictionary<String, Object> param)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();

            int result = conn.Execute(spName, param: param, commandType: CommandType.StoredProcedure);

            return result;
        }
        public List<T> ModelListSPOutput<T>(string spName, Dictionary<String, Object> param, Dictionary<String, DbType> Outputparam,out  Dictionary<String, Object> output)
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            var parameters = new DynamicParameters();
            foreach (var p in param)
            {
                parameters.Add(p.Key, p.Value);
            }
            foreach (var p in Outputparam)
            {
                parameters.Add(p.Key, null, dbType: Outputparam[p.Key], direction: ParameterDirection.Output, size: 200);
            }
            var list = conn.Query<T>(spName, param: parameters, commandType: CommandType.StoredProcedure).ToList<T>();
            output = new Dictionary<string, object>();
            foreach (var item in Outputparam)
            {
                output.Add(item.Key, getValue(item.Key, item.Value, parameters));
            }
            conn.Close();
            return list;
        }
        public int NonQuerySPOutput(string spName, Dictionary<String, Object> param, Dictionary<String, DbType> Outputparam, out  Dictionary<String, Object> output)
        {
            var parameters = new DynamicParameters();
            foreach (var p in param)
            {
                parameters.Add(p.Key, p.Value);
            }
            foreach (var p in Outputparam)
            {
                parameters.Add(p.Key, null, dbType: Outputparam[p.Key], direction: ParameterDirection.Output, size: 200);
            }
            int result = conn.Execute(spName, parameters, commandType: CommandType.StoredProcedure);
             output = new Dictionary<string, object>();
            foreach (var item in Outputparam)
            {
                output.Add(item.Key, getValue(item.Key, item.Value, parameters));
            }
            return result;
        }

        private object getValue(string Name, DbType dbtype, DynamicParameters parameters) {
            object val=null;
            switch (dbtype)
            {
                case DbType.AnsiString:
                    val = parameters.Get<string>(Name);
                    break;
                case DbType.AnsiStringFixedLength:
                    val = parameters.Get<string>(Name);
                    break;
                case DbType.Binary:
                    break;
                case DbType.Boolean:
                    val = parameters.Get<bool>(Name);
                    break;
                case DbType.Byte:
                    break;
                case DbType.Currency:
                    break;
                case DbType.Date:
                    break;
                case DbType.DateTime:
                    break;
                case DbType.DateTime2:
                    break;
                case DbType.DateTimeOffset:
                    break;
                case DbType.Decimal:
                    val = parameters.Get<decimal>(Name);
                    break;
                case DbType.Double:
                    break;
                case DbType.Guid:
                    break;
                case DbType.Int16:
                    val = parameters.Get<int>(Name);
                    break;
                case DbType.Int32:
                    val = parameters.Get<int>(Name);
                    break;
                case DbType.Int64:
                    val = parameters.Get<int>(Name);
                    break;
                case DbType.Object:
                    break;
                case DbType.SByte:
                    break;
                case DbType.Single:
                    val = parameters.Get<Single>(Name);
                    break;
                case DbType.String:
                    val = parameters.Get<string>(Name);
                    break;
                case DbType.StringFixedLength:
                    val = parameters.Get<string>(Name);
                    break;
                case DbType.Time:
                    break;
                case DbType.UInt16:
                    break;
                case DbType.UInt32:
                    break;
                case DbType.UInt64:
                    break;
                case DbType.VarNumeric:
                    break;
                case DbType.Xml:
                    break;
                default:
                    break;
            }
            return val;
        }
       
    }
}
