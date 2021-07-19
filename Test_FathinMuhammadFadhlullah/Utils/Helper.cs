//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Controllers;
using System.Reflection;
using System.Threading.Tasks;
using System.Net;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;
using Microsoft.AspNetCore.Http;
using System;
using Test_FathinMuhammadFadhlullah.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data;
using System.Collections;
using FileHelpers;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Security.Cryptography;

namespace Test_FathinMuhammadFadhlullah.Utils
{
    public class Helper
    {
        public static string GetUser_IP(IHttpContextAccessor _accessor)
        {
            string VisitorsIPAddr = string.Empty;

            var headers = _accessor.HttpContext.Request.Headers;

            if (headers.ContainsKey("X-Forwarded-For"))
            {
                _accessor.HttpContext.Connection.RemoteIpAddress = IPAddress.Parse(headers["X-Forwarded-For"].ToString().Split(',', StringSplitOptions.RemoveEmptyEntries)[0]);
            }

            IPAddress remoteIpAddress = _accessor.HttpContext.Connection.RemoteIpAddress;
            VisitorsIPAddr = remoteIpAddress.ToString();

            return VisitorsIPAddr;
        }

        public static string GenerateRandomSalt(int size)
        {
            //var rng = new RNGCryptoServiceProvider();

            //var bytes = new Byte[size];
            //rng.GetBytes(bytes);
            //return Convert.ToBase64String(bytes).Take(32).ToString();

            Random random = new Random();

            const string pool = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";
            var chars = Enumerable.Range(0, size)
                .Select(x => pool[random.Next(0, pool.Length)]);
            return new string(chars.ToArray());
        }

        public static int calcAge(DateTime bday)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year;
            if (bday > today.AddYears(-age)) age--;

            return age;
        }

        public class Html
        {
            public static string createDropDown(String Name, List<SelectListItem> list)
            {
                var retVal = "";
                retVal += " <select id=\"" + Name + "\" name=\"" + Name + "\" class=\"form-control input-medium\">";
                foreach (var item in list)
                {
                    retVal += Environment.NewLine;
                    retVal += " <option value=\"" + item.Value + "\">" + item.Value + " - " + item.Text + "</option>";
                }
                retVal += Environment.NewLine;
                retVal += " </select>";
                return retVal;
            }

            private static List<labelActiveStatus> _LabelActiveStatus = new List<labelActiveStatus>()
            {
                new labelActiveStatus() { Status = true, Label = "<span class=\"label label-sm label-success\"> Active </span>"},
                new labelActiveStatus() { Status = false, Label = "<span class=\"label label-sm label-danger\"> Not Active </span>"}
            };

            private static List<labelStatus> _LabelPickStatus = new List<labelStatus>()
            {
                new labelStatus() { Status = "Released", Label = "<span class=\"label label-sm label-success\"> Released </span>"},
                new labelStatus() { Status = "Picked", Label = "<span class=\"label label-sm label-info\"> Picked </span>"},
                new labelStatus() { Status = "Partially Picked", Label = "<span class=\"label label-sm label-default\"> Partially Picked </span>"},
                new labelStatus() { Status = "Partially Delivered", Label = "<span class=\"label label-sm label-primary\"> Partially Delivered </span>"},
                new labelStatus() { Status = "Closed", Label = "<span class=\"label label-sm label-danger\"> Closed </span>"},
                new labelStatus() { Status = "Canceled", Label = "<span class=\"label label-sm label-danger\"> Canceled </span>"},
                new labelStatus() { Status = "", Label = ""}
            };

            private static List<labelStatus> _LabelStatus = new List<labelStatus>()
            {
                new labelStatus() { Status = "On Process", Label = "<span class=\"label label-sm label-warning\"> On Process </span>"},
                new labelStatus() { Status = "On Working", Label = "<span class=\"label label-sm label-warning\"> On Working </span>"},
                new labelStatus() { Status = "Pending", Label = "<span class=\"label label-sm label-info\"> Pending </span>"},
                new labelStatus() { Status = "Canceled", Label = "<span class=\"label label-sm label-danger\"> Canceled </span>"},
                new labelStatus() { Status = "Rejected", Label = "<span class=\"label label-sm label-danger\"> Rejected </span>"},
                new labelStatus() { Status = "Cover", Label = "<span class=\"label label-sm label-success\"> Cover </span>"},
                new labelStatus() { Status = "Paid", Label = "<span class=\"label label-sm label-info\"> Paid </span>"},
                new labelStatus() { Status = "Done", Label = "<span class=\"label label-sm label-success\"> Done </span>"},
                new labelStatus() { Status = "Approved Refund", Label = "<span class=\"label label-sm label-info\"> Approved Refund </span>"},
                new labelStatus() { Status = "Approved Claim", Label = "<span class=\"label label-sm label-info\"> Approved Claim </span>"},
                new labelStatus() { Status = "Waiting Payment", Label = "<span class=\"label label-sm label-warning\"> Waiting Payment </span>"}
            };

            private static List<labelStatus> _LabelApproval = new List<labelStatus>()
            {
                new labelStatus() { Status = "Waiting", Label = "<span class=\"label label-sm label-warning\"> Waiting </span>"},
                new labelStatus() { Status = "Pending", Label = "<span class=\"label label-sm label-warning\"> Pending </span>"},
                new labelStatus() { Status = "Approved", Label = "<span class=\"label label-sm label-success\"> Approved </span>"},
                new labelStatus() { Status = "Rejected", Label = "<span class=\"label label-sm label-danger\"> Rejected </span>"},
                new labelStatus() { Status = "Revision", Label = "<span class=\"label label-sm label-default\"> Revision </span>"},
                new labelStatus() { Status = "", Label = ""}
            };

            public static string getLabelStatus(string _status)
            {
                return _LabelStatus.Where(x => x.Status == _status).First().Label;
            }
            public static string getLabelPickStatus(string _status)
            {
                return _LabelPickStatus.Where(x => x.Status == _status).First().Label;
            }
            public static string getLabelApproval(string _status)
            {
                return _LabelApproval.Where(x => x.Status == _status).First().Label;
            }
            public static string getLabelActiveStatus(Boolean _status)
            {
                return _LabelActiveStatus.Where(x => x.Status == _status).First().Label;
            }

            private class labelStatus
            {
                public String Status { get; set; }
                public String Label { get; set; }
            }
            private class labelActiveStatus
            {
                public Boolean Status { get; set; }
                public String Label { get; set; }
            }

            public static string convertDateTimeDBtoIndo(DateTime dateTime)
            {
                var bulanIndo = new string[] { "", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "Oktober", "November", "Desember" };
 
                var date = dateTime.ToString().Split(' ')[0];
                var time = dateTime.ToString().Split(' ')[1];

                var tanggal = date.Split('/')[0];
                var bulan = date.Split('/')[1];
                var tahun = date.Split('/')[2];


                return tanggal + " " + bulanIndo[Math.Abs(int.Parse(bulan))] + " " + tahun;
            }
        }

        public static string FormatByteSize(double bytes)
        {
            string[] Suffix = { "B", "KB", "MB", "GB", "TB", "PB" };
            int index = 0;
            do
            {
                bytes /= 1024; index++;
            }
            while (bytes > 1024);

            return string.Format("{0:0.00} {1}", bytes, Suffix[index]);
        }

        public class SqlUtil
        {
            public class WebDbQuery
            {
                public static DataTable getDataTable(String Query)
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    string constr = Startup.StaticConfig.GetSection("ConnectionStrings").GetSection("ConnKey").Value;
                    using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constr))
                    {
                        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(Query))
                        {
                            cmd.Connection = con;
                            using (System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd))
                            {
                                sda.Fill(dt);
                            }
                        }
                    }
                    return dt;
                }
                public static Object getScalar(String Query)
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    string constr = Startup.StaticConfig.GetSection("ConnectionStrings").GetSection("ConnKey").Value;
                    using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constr))
                    {
                        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(Query))
                        {
                            cmd.Connection = con;
                            using (System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter(cmd))
                            {
                                sda.Fill(dt);
                            }
                        }
                    }
                    return dt.Rows[0][0];
                }
                public static List<SelectListItem> getSelectList(String Query)
                {
                    List<SelectListItem> retVal = new List<SelectListItem>();

                    var dt = getDataTable(Query);
                    foreach (DataRow item in dt.Rows)
                    {
                        retVal.Add(new SelectListItem { Value = item[0].ToString(), Text = item[1].ToString() });
                    }

                    return retVal;
                }
            }
        }

        public static bool IsList(object o)
        {
            if (o == null) return false;
            return o is IList &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        }

        public static bool IsDictionary(object o)
        {
            if (o == null) return false;
            return o is IDictionary &&
                   o.GetType().IsGenericType &&
                   o.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(Dictionary<,>));
        }

        public static string GuidOracleToDotNet(string text)
        {
            byte[] bytes = ParseHex(text);
            Guid guid = new Guid(bytes);
            return guid.ToString("N").ToUpperInvariant();
        }

        public static string GuidDotNetToOracle(byte[] text)
        {
            Guid guid = new Guid(text);
            return BitConverter.ToString(text).Replace("-", "");
        }

        public static byte[] GuidDotNetToOracle(string text)
        {
            //Guid guid = new Guid(text);
            byte[] bytes = ParseHex(text);
            Guid guid = new Guid(bytes);

            return guid.ToByteArray();
            //return BitConverter.ToString(guid.ToByteArray()).Replace("-", "");
        }

        static byte[] ParseHex(string text)
        {
            // Not the most efficient code in the world, but
            // it works...
            byte[] ret = new byte[text.Length / 2];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = Convert.ToByte(text.Substring(i * 2, 2), 16);
            }
            return ret;
        }

        public class StringLength : System.Attribute
        {
            public static void getLength(PropertyInfo info, object app)
            {
                var inf = info.GetCustomAttribute(typeof(StringLengthAttribute));
                if (inf != null)
                {
                    var maxLength = info.GetCustomAttributes(typeof(StringLengthAttribute), true).Single() as StringLengthAttribute;
                    if (maxLength != null)
                    {
                        string val = Convert.ToString(info.GetValue(app));
                        if (val.Length > maxLength.MaximumLength) throw new Exception("Maximum length of " + info.Name + " should be " + maxLength.MaximumLength + " character");
                    }
                }
            }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class Required : System.Attribute
        {
            public static bool PerformCheck(PropertyInfo objectToCheck)
            {
                if (objectToCheck.GetCustomAttributes(typeof(RequiredAttribute), true).Any()) return true;
                return false;
            }
        }

        public List<string> IsAnyNullOrEmpty(object myObject)
        {
            List<string> res = new List<string>();

            foreach (PropertyInfo pi in myObject.GetType().GetProperties())
            {
                if (pi.GetCustomAttributes(typeof(FieldHiddenAttribute), true).Any()) continue;
                if (pi.PropertyType == typeof(string))
                {
                    try
                    {
                        StringLength.getLength(pi, myObject);
                    }
                    catch (Exception e)
                    {
                        res.Add(e.Message);
                    }
                }
                if (!Required.PerformCheck(pi)) continue;
                if (pi.PropertyType == typeof(string))
                {
                    string value = (string)pi.GetValue(myObject);
                    if (string.IsNullOrEmpty(value))
                    {
                        //throw new Exception(pi.Name + " cannot empty");
                        res.Add(pi.Name + " cannot empty");
                    }

                }
                if (pi.PropertyType == typeof(DateTime))
                {
                    DateTime value = (DateTime)pi.GetValue(myObject);
                    if (value == null)
                    {
                        //throw new Exception(pi.Name + " cannot empty");
                        res.Add(pi.Name + " cannot empty");
                    }
                }
                if (pi.PropertyType == typeof(Char))
                {
                    Char value = (Char)pi.GetValue(myObject);
                    if (value.Equals('\0'))
                    {
                        //throw new Exception(pi.Name + " cannot empty");
                        res.Add(pi.Name + " cannot empty");
                    }
                }
                if (pi.PropertyType == typeof(decimal?))
                {
                    decimal? value = (decimal?)pi.GetValue(myObject);
                    if (value == null)
                    {
                        //throw new Exception(pi.Name + " cannot be null or empty value");
                        res.Add(pi.Name + " cannot be null or empty value");
                    }
                    if (value.Value < 0)
                    {
                        //throw new Exception(pi.Name + " cannot be under zero value");
                        res.Add(pi.Name + " cannot be under zero value");
                    }

                }
                if (pi.PropertyType == typeof(int?))
                {
                    int? value = (int?)pi.GetValue(myObject);
                    if (value == null)
                    {
                        //throw new Exception(pi.Name + " cannot be null or empty value");
                        res.Add(pi.Name + " cannot be null or empty value");
                    }
                    if (value.Value < 0)
                    {
                        //throw new Exception(pi.Name + " cannot be under zero value");
                        res.Add(pi.Name + " cannot be under zero value");
                    }

                }
            }

            return res;
        }

        public class SelectListItemComparer : IEqualityComparer<SelectListItem>
        {
            public bool Equals(SelectListItem x, SelectListItem y)
            {
                return x.Text == y.Text && x.Value == y.Value;
            }

            public int GetHashCode(SelectListItem item)
            {
                int hashText = item.Text == null ? 0 : item.Text.GetHashCode();
                int hashValue = item.Value == null ? 0 : item.Value.GetHashCode();
                return hashText ^ hashValue;
            }
        }

    }
}
