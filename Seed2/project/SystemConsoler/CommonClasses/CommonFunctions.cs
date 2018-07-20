using SystemConsoler.BLL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using SystemConsoler.BLL.Context;

namespace SystemConsoler.CommonClasses
{
    public class CommonFunctions
    {
        private ConsolerContext db = null;
        public CommonFunctions(ConsolerContext db)
        {
            this.db = db;
        }
        public string ConvertInvalidJson(string oldJson)
        {
            string newJson = "{" + oldJson + "}";
            newJson = newJson.Replace("=", ":");

            newJson = newJson.Replace("&", ",");
            newJson = newJson.Replace("+", " ");
            newJson = newJson.Replace(":", @":""");
            newJson = newJson.Replace(",", @""",");
            newJson = newJson.Replace("}", @"""}");
            newJson = newJson.Replace("%2F", "-");
            newJson = newJson.Replace("%3A", ":");
            newJson = newJson.Replace("%20", " ");
            //int index=newJson.IndexOf(":");
            // newJson[8] = '"';
            return newJson;
        }

        public SystemConsoler.Models.UserType GetUserType(string UserName)
        {
            string query = @"select usr.id as UserID, ut.Name as Type, usr.Name as UserName from usertypes ut 
inner join Users usr on usr.UserType_Id = ut.Id
where usr.Name='{0}'";
            string parameterizedquery = string.Format(query, UserName);
            SystemConsoler.Models.UserType UserType = db.Database.SqlQuery<SystemConsoler.Models.UserType>(parameterizedquery).FirstOrDefault();
            return UserType;
        }
        public DataTable CreateDataTable<T>(IEnumerable<T> list)
        {
            Type type = typeof(T);
            var properties = type.GetProperties();

            DataTable dataTable = new DataTable();
            foreach (PropertyInfo info in properties)
            {
                dataTable.Columns.Add(new DataColumn(info.Name, Nullable.GetUnderlyingType(info.PropertyType) ?? info.PropertyType));
            }

            foreach (T entity in list)
            {
                object[] values = new object[properties.Length];
                for (int i = 0; i < properties.Length; i++)
                {
                    values[i] = properties[i].GetValue(entity);
                }

                dataTable.Rows.Add(values);
            }

            return dataTable;
        }
    }


    public class ApplicationFunctions : CommonFunctions
    {
        private ConsolerContext db = null;

        public ApplicationFunctions(ConsolerContext db) : base(db)
        {
            this.db = db;
        }
 
    }
}