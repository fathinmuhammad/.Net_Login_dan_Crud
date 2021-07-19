using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Repositories.Impl
{
    public class BaseRepository : IDisposable
    {
        protected IConfiguration _config;
        protected string _connString;
        protected string _connTMString;
        protected string _connKey;

        public BaseRepository(IConfiguration config)
        {
            _config = config;
            _connString = config.GetValue<String>("ConnectionStrings:DefaultConnection");

        }

        protected SqlConnection getConn()
        {
            return new SqlConnection(_connString);
        }

        public DateTime? strToDate(string strDate)
        {
            if (strDate != null)
                return DateTime.ParseExact(strDate.Substring(0, 10), "yyyy-MM-dd", null);
            else
                return null;
        }

        public DateTime? strToDateTime(string strDate)
        {
            if (strDate != null)
                return DateTime.ParseExact(strDate.Substring(0, 19), "yyyy-MM-dd", null);
            else
                return null;
        }

        public string dateToStr(DateTime date)
        {
            if (date != null)
                return date.ToString("yyyy-MM-dd");
            else
                return "";
        }

        public string dateTimeToStr(DateTime date)
        {
            if (date != null)
                return date.ToString("yyyy-MM-dd hh:mm:ss");
            else
                return "";
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
