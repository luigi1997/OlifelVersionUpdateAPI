using Dapper;
//using Dapper.Contrib.Extensions;

//using System;
//using System.Collections.Generic;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VgNetDapperDataExtended.Helpers
{
    public static class DapperQueryHelper
    {
        //        public static string generateUpdate<T>(Snapshotter.Snapshot<T> snapshot, T obj)
        //        {
        //            List<string> listDiff = snapshot.Diff().ParameterNames.ToList();
        //            if (listDiff.Count == 0)
        //            {
        //                return null;
        //            }
        //            string tableName = typeof(T).GetAttributeValue((TableAttribute dna) => dna.Name);
        //            //var ass = typeof(T).GetAttributeValue((KeyAttribute dna) => dna.Name);

        //            List<PropertyInfo> keyProps = typeof(T).GetProperties().Where(
        //                prop => Attribute.IsDefined(prop, typeof(ExplicitKeyAttribute))).ToList();

        //            if (keyProps == null || keyProps.Count == 0)
        //            {
        //                keyProps = typeof(T).GetProperties().Where(
        //                    prop => Attribute.IsDefined(prop, typeof(KeyAttribute))).ToList();
        //            }

        //            if (keyProps == null || keyProps.Count == 0)
        //            {
        //                throw new Exception($"Class for the table name {tableName} must have [Key] or [ExplicitKey] defined in class!");
        //            }

        //            // begining of update query
        //            string sql = $"UPDATE {tableName} SET";
        //            // build SET ATTRIBUTES: "SET FIELD1 = 'VAL1'"
        //            List<string> attribuitions = new List<string>();
        //            foreach (string prop in listDiff)
        //            {
        //                attribuitions.Add($"[{prop}] = {GetPropValue(obj, prop)}");
        //            }
        //            sql += String.Join(", ", attribuitions.ToArray());

        //            sql += " WHERE ";
        //            List<string> whereConditions = new List<string>();
        //            foreach (PropertyInfo prop in keyProps)
        //            {
        //                whereConditions.Add($"[{prop.Name}] = {GetPropValue(obj, prop.Name)}");
        //            }
        //            sql += String.Join(" AND ", whereConditions.ToArray());
        //            return sql;
        //        }
        //        public static bool IsNumber(this object value)
        //        {
        //            return value is sbyte
        //                    || value is byte
        //                    || value is short
        //                    || value is ushort
        //                    || value is int
        //                    || value is uint
        //                    || value is long
        //                    || value is ulong
        //                    || value is float
        //                    || value is double
        //                    || value is decimal;
        //        }
        //        public static string GetPropValue(object src, string propName)
        //        {
        //            var value = src.GetType().GetProperty(propName).GetValue(src, null);
        //            DateTime dateTime;
        //            if (DateTime.TryParse(value.ToString(), out dateTime))
        //            {
        //                DateTime d = DateTime.Parse(value.ToString());
        //                return $"CAST('{d.ToString("yyyy-MM-dd HH:mm:ss.fff")}' AS DATETIME)";
        //            }
        //            else if (IsNumber(value))
        //            {
        //                return $"{value.ToString()}";
        //            }
        //            else
        //            {
        //                return $"'{value.ToString()}'";
        //            }
        //        }
        //        public static TValue GetAttributeValue<TAttribute, TValue>(
        //            this Type type,
        //            Func<TAttribute, TValue> valueSelector)
        //            where TAttribute : Attribute
        //        {
        //            var att = type.GetCustomAttributes(
        //                typeof(TAttribute), true
        //            ).FirstOrDefault() as TAttribute;
        //            if (att != null)
        //            {
        //                return valueSelector(att);
        //            }
        //            return default(TValue);
        //        }
        public static string GenerateSqlUpdateSetClause<T>(T existingObj, T newObj)
        {
            // check if DocLines has changed
            Type myType = existingObj.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            var tableNameAttribute = typeof(T).GetCustomAttributes(typeof(TableAttribute), true).FirstOrDefault() as TableAttribute;

            List<string> setClauses = new List<string>();
            List<string> whereClauses = new List<string>();

            foreach (PropertyInfo prop in props)
            {
                var isComputed = prop.GetCustomAttribute(typeof(ComputedAttribute), true) as ComputedAttribute;
                var isKey = prop.GetCustomAttribute(typeof(KeyAttribute), true) as KeyAttribute;
                var isExplicitKey = prop.GetCustomAttribute(typeof(ExplicitKeyAttribute), true) as ExplicitKeyAttribute;
                var isWritable = prop.GetCustomAttribute(typeof(WriteAttribute), true) as WriteAttribute;

                if (isComputed == null || (isWritable != null && isWritable.Write))
                {
                    object existingObjPropValue = prop.GetValue(existingObj, null);
                    object newObjPropValue = prop.GetValue(newObj, null);

                    if ((existingObjPropValue == null && newObjPropValue != null) 
                        || existingObjPropValue != null && newObjPropValue == null
                        || (existingObjPropValue != null && !existingObjPropValue.ToString().Equals(newObjPropValue.ToString()))
                        )
                    {
                        if(newObjPropValue == null)
                        {
                            setClauses.Add(prop.Name + " = NULL");
                        }
                        else if (prop.PropertyType == typeof(string))
                        {
                            setClauses.Add(prop.Name + " = " + "'" + newObjPropValue + "'");
                        }
                        else if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
                        {
                            if ((newObjPropValue as DateTime?).HasValue)
                                setClauses.Add(prop.Name + " = " + "'" + (newObjPropValue as DateTime?).Value.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                        }
                        else
                        {
                            setClauses.Add(prop.Name + " = " + newObjPropValue );
                        }
                    }
                    
                    if (isKey != null || isExplicitKey != null)
                    {
                        whereClauses.Add(prop.Name + " = " + "@" + prop.Name);
                    }
                }
            }
            if (setClauses.Any())
            {
                string sql = $"UPDATE {tableNameAttribute.Name} ";
                sql += "SET " + string.Join(", ", setClauses);
                sql += " where " + string.Join(" AND ", whereClauses);
                return sql;
            }
            else
                return null;
        }
    }
}
