using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using AdoDemo.Models;
using DBUtil;

namespace DAL
{
    /// <summary>
    /// 模板
    /// </summary>
    public class ClassDal
    {
        #region 分页获取模板集合
        /// <summary>
        /// 分页获取模板集合
        /// </summary>
        public DataTable GetList(int classid)
        {
            StringBuilder sql = new StringBuilder(string.Format(@"
                select *
                from Classes t
                where 1=1 "));
            if (classid>0)
            {
                sql.AppendFormat(" and t.classid = @classid", classid);

                SqlParameter[] para =  new SqlParameter[]{
                    new SqlParameter("@classsid", classid)
               };
                sql.AppendFormat(" order by classid");

                DataSet ds = DBHelper.Query(sql.ToString(), para);
                return ds.Tables["ds"];
            }
            else
            {
                sql.AppendFormat(" order by classid");
                DataSet ds = DBHelper.Query(sql.ToString());
                return ds.Tables["ds"];
            }
        }
        #endregion


        #region GetMaxId
        /// <summary>
        /// GetMaxId
        /// </summary>
        public int GetMaxId()
        {
            return DBHelper.GetMaxID<Classes>("classid");
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        public void Insert(object obj)
        {
            DBHelper.Insert(obj);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        public void Update(object obj)
        {
            DBHelper.Update(obj);
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        public void Del(int id)
        {
            DBHelper.Delete<Classes>(id);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void BatchDelete(string ids)
        {
            DBHelper.BatchDelete<Classes>(ids);
        }
        /// <summary>
        /// 删除
        /// </summary>
        public void Delete(string conditions)
        {
            DBHelper.Delete<Classes>(conditions);
        }
        #endregion

    }
}
