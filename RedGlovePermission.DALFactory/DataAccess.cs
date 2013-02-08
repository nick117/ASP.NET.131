using System;
using System.Reflection;
using System.Configuration;
using RedGlovePermission.IDAL;
using RedGlovePermission.Lib;

namespace RedGlovePermission.DALFactory
{
    /// <summary>
    /// 抽象工厂模式
    /// </summary>
    public sealed class DataAccess
    {
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["DataDAL"];

        /// <summary>
        /// 创建对象或从缓存获取
        /// </summary>
        public static object CreateObject(string AssemblyPath, string ClassNamespace)
        {
            object objType = DataCache.GetCache(ClassNamespace);//从缓存读取
            if (objType == null)
            {
                try
                {
                    objType = Assembly.Load(AssemblyPath).CreateInstance(ClassNamespace);//反射创建
                    DataCache.SetCache(ClassNamespace, objType);// 写入缓存
                }
                catch
                { }
            }
            return objType;
        }
        
        /// <summary>
        /// 创建权限标识数据层接口
        /// </summary>
        public static RedGlovePermission.IDAL.IRGP_AuthorityDir CreateRGP_AuthorityDir()
        {
            string ClassNamespace = AssemblyPath + ".RGP_AuthorityDir";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.IRGP_AuthorityDir)objType;
        }

        /// <summary>
        /// 创建系统配置数据层接口
        /// </summary>
        public static RedGlovePermission.IDAL.IRGP_Configuration CreateRGP_Configuration()
        {

            string ClassNamespace = AssemblyPath + ".RGP_Configuration";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.IRGP_Configuration)objType;
        }

        /// <summary>
        /// 创建分组数据层接口
        /// </summary>
        public static RedGlovePermission.IDAL.IRGP_Groups CreateRGP_Groups()
        {
            string ClassNamespace = AssemblyPath + ".RGP_Groups";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.IRGP_Groups)objType;
        }

        /// <summary>
        /// 创建模块管理数据层接口
        /// </summary>
        public static RedGlovePermission.IDAL.IRGP_Modules CreateRGP_Modules()
        {
            string ClassNamespace = AssemblyPath + ".RGP_Modules";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.IRGP_Modules)objType;
        }

        /// <summary>
        /// 创建角色管理数据层接口
        /// </summary>
        public static RedGlovePermission.IDAL.IRGP_Roles CreateRGP_Roles()
        {
            string ClassNamespace = AssemblyPath + ".RGP_Roles";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.IRGP_Roles)objType;
        }

        /// <summary>
        /// 创建用户数据层接口
        /// </summary>
        public static RedGlovePermission.IDAL.IUsers CreateUsers()
        {
            string ClassNamespace = AssemblyPath + ".Users";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.IUsers)objType;
        }

        /// <summary>
        /// 建立客戶資料層介面
        /// </summary>
        public static RedGlovePermission.IDAL.ICustomers CreateCustomers()
        {
            string ClassNamespace = AssemblyPath + ".Customers";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.ICustomers)objType;
        }

        /// <summary>
        /// 建立產品資料層介面
        /// </summary>
        public static RedGlovePermission.IDAL.IProducts CreateProducts()
        {
            string ClassNamespace = AssemblyPath + ".Products";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.IProducts)objType;
        }

        /// <summary>
        /// 建立公司資料層介面
        /// </summary>
        public static RedGlovePermission.IDAL.IBasic_Companies CreateCompanies()
        {
            string ClassNamespace = AssemblyPath + ".Basic_Companies";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.IBasic_Companies)objType;
        }

        /// <summary>
        /// 建立案例資料層介面
        /// </summary>
        public static RedGlovePermission.IDAL.IBasic_Case CreateCase()
        {
            string ClassNamespace = AssemblyPath + ".Basic_Case";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.IBasic_Case)objType;
        }

        /// <summary>
        /// 建立代碼資料層介面
        /// </summary>
        public static RedGlovePermission.IDAL.IBasic_System CreateCode()
        {
            string ClassNamespace = AssemblyPath + ".Basic_System";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.IBasic_System)objType;
        }

        /// <summary>
        /// 建立訂單資料層介面
        /// </summary>
        public static RedGlovePermission.IDAL.ISales_Order CreateOrder()
        {
            string ClassNamespace = AssemblyPath + ".Sales_Order";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.ISales_Order)objType;
        }

        /// <summary>
        /// 建立銷貨退回單資料層介面
        /// </summary>
        public static RedGlovePermission.IDAL.ISales_Return CreateReturn()
        {
            string ClassNamespace = AssemblyPath + ".Sales_Return";
            object objType = CreateObject(AssemblyPath, ClassNamespace);
            return (RedGlovePermission.IDAL.ISales_Return)objType;
        }

    }
}
