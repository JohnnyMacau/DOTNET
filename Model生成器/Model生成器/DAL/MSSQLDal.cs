﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using DAL;
using Model生成器.DBUtil;

namespace Model生成器.DAL
{
    /// <summary>
    /// MSSQL数据库DAL
    /// </summary>
    public class MSSQLDal : IDal
    {
        #region 获取所有表信息
        /// <summary>
        /// 获取所有表信息
        /// </summary>
        public List<Dictionary<string, string>> GetAllTables()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MSSQLConnection"].ToString();
            MSSQLHelper dbHelper = new MSSQLHelper();
            DataTable dt = dbHelper.Query(string.Format(@"
                SELECT tbs.name as TABLE_NAME,ds.value as COMMENTS 
                FROM sys.tables tbs 
                left join sys.extended_properties ds on ds.major_id=tbs.object_id "));
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("table_name", dr["TABLE_NAME"].ToString());
                dic.Add("comments", dr["COMMENTS"].ToString());
                result.Add(dic);
            }
            return result;
        }
        #endregion

        #region 获取表的所有字段名及字段类型
        /// <summary>
        /// 获取表的所有字段名及字段类型
        /// </summary>
        public List<Dictionary<string, string>> GetAllColumns(string tableName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ToString();
            MSSQLHelper dbHelper = new MSSQLHelper();
            DataTable dt = dbHelper.Query(string.Format(@"
                select c.name,c.is_nullable,ds.value,ts.name as column_type,c.max_length,c.precision,c.scale
                from sys.columns c
                left join sys.extended_properties ds on ds.major_id=c.object_id and ds.minor_id=c.column_id
                left join sys.types ts on c.system_type_id=ts.system_type_id and ts.user_type_id=c.user_type_id
                left join sys.tables tbs on tbs.object_id=c.object_id
                where tbs.name='{0}' 
                order by c.column_id", tableName));
            DataTable dtPK = dbHelper.Query(string.Format(@"
                select b.column_name 
                from  information_schema.table_constraints a
                inner join information_schema.constraint_column_usage b
                on a.constraint_name = b.constraint_name
                where a.constraint_type = 'PRIMARY KEY' 
                and a.table_name = '{0}'", tableName));
            string strPK = string.Empty;
            if (dtPK.Rows.Count > 0)
            {
                strPK = dtPK.Rows[0]["column_name"].ToString();
            }
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>>();
            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("columns_name", dr["name"].ToString());
                dic.Add("notnull", dr["is_nullable"].ToString() == "False" ? "1" : "0");
                dic.Add("comments", dr["value"].ToString());
                string dataType = dr["column_type"].ToString();
                dic.Add("data_type", dataType);
                dic.Add("data_scale", dr["scale"].ToString());
                dic.Add("data_precision", dr["precision"].ToString());

                if (dr["name"].ToString() == strPK)
                {
                    dic.Add("constraint_type", "P");
                }
                else
                {
                    dic.Add("constraint_type", "");
                }
                result.Add(dic);
            }
            return result;
        }
        #endregion

        #region 类型转换
        /// <summary>
        /// 类型转换
        /// </summary>
        public string ConvertDataType(Dictionary<string, string> column)
        {
            string data_type = "string";
            switch (column["data_type"])
            {
                case "int":
                    if (column["notnull"] == "1")
                    {
                        data_type = "int";
                    }
                    else
                    {
                        data_type = "int?";
                    }
                    break;
                case "float":
                    if (column["notnull"] == "1")
                    {
                        data_type = "float";
                    }
                    else
                    {
                        data_type = "float?";
                    }
                    break;
                case "bigint":
                    if (column["notnull"] == "1")
                    {
                        data_type = "long";
                    }
                    else
                    {
                        data_type = "long?";
                    }
                    break;
                case "decimal":
                    if (column["notnull"] == "1")
                    {
                        data_type = "decimal";
                    }
                    else
                    {
                        data_type = "decimal?";
                    }
                    break;
                case "nvarchar":
                    data_type = "string";
                    break;
                case "varchar":
                    data_type = "string";
                    break;
                case "text":
                    data_type = "string";
                    break;
                case "ntext":
                    data_type = "string";
                    break;
                case "datetime":
                    if (column["notnull"] == "1")
                    {
                        data_type = "DateTime";
                    }
                    else
                    {
                        data_type = "DateTime?";
                    }
                    break;
                case "varbinary":
                    data_type = "string";
                    break;
                case "bit":
                    data_type = "Boolean";
                    break;
                default:
                    throw new Exception("Model生成器未实现数据库字段类型" + column["data_type"] + "的转换");
            }
            return data_type;
        }
        #endregion

    }
}
