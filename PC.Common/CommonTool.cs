using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PC.Common
{
    public class CommonTool
    {
        public static List<T> DataTableConvertToList<T>(DataTable dt) where T : new()
        {
            List<T> list = new List<T>();
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                foreach (DataColumn dc in dt.Columns)
                {
                    PropertyInfo[] properties = t.GetType().GetProperties();
                    foreach (var pro in properties)
                    {
                        if (pro.Name.ToLower() == dc.ColumnName.ToLower() && pro.CanWrite)
                        {
                            pro.SetValue(t, dr[dc],null);
                            break;
                        }
                    }
                }
                list.Add(t);
            }
            return list;
        }

        public static T DataTableConvertToModel<T>(DataTable dt) where T : new()
        {
            T t = default(T);
            try
            {
                if (dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];
                    t = new T();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        PropertyInfo[] properties = typeof(T).GetProperties();
                        foreach (var pro in properties)
                        {
                            if (pro.Name.ToLower() == dc.ColumnName.ToLower() && pro.CanWrite)
                            {                                
                                pro.SetValue(t, dr[dc],null);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                t = default(T);
            }
            return t;
        }

        public static List<M_Prizes> GetPrizeListByDataTable(DataTable dt)
        {
            List<M_Prizes> m_Prizes = new List<M_Prizes>();
            foreach (DataRow row in dt.Rows)
            {
                M_Prizes _Prizes = new M_Prizes();
                _Prizes.DateLine = Convert.ToDateTime(row["DateLine"]).ToString("yyyy-MM-dd HH:mm:ss");
                _Prizes.Member_HandPhone = PhoneStr(row["Member_HandPhone"] + "");
                _Prizes.Name = row["Name"] + "";
                m_Prizes.Add(_Prizes);
            }            
            return m_Prizes;           
        }

        /// <summary>
        /// 手机字符串处理
        /// </summary>
        /// <returns></returns>
        public static string PhoneStr(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return "***";

            if (phone.Length > 10)
            {
                return phone.Substring(0, 3) + "****" + phone.Substring(7);
            }
            else return "***";
        }

        /// <summary>
        /// 是否数字字符串
        /// </summary>
        /// <param name="inputData">字符串</param>
        /// <returns></returns>
        public static bool IsNumber(string str)
        {
            Regex RegNumber = new Regex(@"^[0-9]+$");
            return RegNumber.IsMatch(str);
        }

        /// <summary>
        /// HTTP 请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string HttpGetByUrl(string url)
        {
            using (WebClient client = new WebClient() { Encoding = System.Text.Encoding.UTF8 })
            {
                return client.DownloadString(url);
            }
        }

    }
}
