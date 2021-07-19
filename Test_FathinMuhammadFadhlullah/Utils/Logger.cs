using Test_FathinMuhammadFadhlullah.Entities;
using Test_FathinMuhammadFadhlullah.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Test_FathinMuhammadFadhlullah.Utils
{
    public static class Logger
    {
    //    public static long addLog<T>(this IDbConnection connection, ILogRepository log, T entityToInsert, IDbTransaction transaction = null, int? commandTimeout = null) where T : class
    //    {
    //        int returnVal;
    //        var key = LoggerHelper.KeyPropertiesCache(typeof(T));
    //        string objtype = (string)entityToInsert.GetType().GetProperty("object_code").GetValue(entityToInsert);
    //        Dictionary<string, object> newdata = new Dictionary<string, object>();
    //        newdata.Add(objtype, entityToInsert);
    //        var currdata = JsonConvert.SerializeObject(newdata);
    //        var prevdata = "";

    //        int objid = (int)entityToInsert.GetType().GetProperty(key[0].Name).GetValue(entityToInsert);

    //        Repo _irepo = new Repo(log);

    //        returnVal = _irepo.addLog(objtype, objid, "INSERT", prevdata, currdata, connection, transaction);

    //        return returnVal;
    //    }

    //    public static long addLog<T>(this IDbConnection connection, ILogRepository log, T entityPrev, T entityCurr, IDbTransaction transaction = null, int? commandTimeout = null)
    //        where T : class
    //    {
    //        int returnVal;
    //        var key = LoggerHelper.KeyPropertiesCache(typeof(T));
    //        string objtype = (string)entityPrev.GetType().GetProperty("object_code").GetValue(entityPrev);

    //        //Previous data
    //        Dictionary<string, object> prevdataDic = new Dictionary<string, object>();
    //        //prevdataDic.Add(objtype, entityPrev.GetType().GetProperties().Except(computedAttr).ToList().Where(a => a.PropertyType != typeof(byte[])).ToDictionary(a => a.Name, a => a.GetValue(entityPrev)));
    //        var prevdata = JsonConvert.SerializeObject(entityPrev);

    //        //Current Data
    //        var currdata = "";
    //        var act_type = "DELETE";
    //        if (entityCurr != null)
    //        {
    //            Dictionary<string, object> currdataDic = new Dictionary<string, object>();
    //            //currdataDic.Add(objtype, entityCurr.GetType().GetProperties().Except(computedAttr).ToList().Where(a => a.PropertyType != typeof(byte[])).ToDictionary(a => a.Name, a => a.GetValue(entityCurr)));
    //            currdata = JsonConvert.SerializeObject(entityCurr);
    //            act_type = "UPDATE";
    //        }

    //        int objid = (int)entityPrev.GetType().GetProperty(key[0].Name).GetValue(entityPrev);

    //        Repo _irepo = new Repo(log);

    //        returnVal = _irepo.addLog(objtype, objid, act_type, prevdata, currdata, connection, transaction);

    //        return returnVal;
    //    }
    //}

    //public interface IRepo
    //{
    //    int addLog(string obj_type, int obj_id, string act_type, string prev, string curr, IDbConnection connection, IDbTransaction transaction);
    //}

    //public class Repo : IRepo
    //{
    //    protected ILogRepository _logRepo;

    //    public Repo(ILogRepository logRepo)
    //    {
    //        _logRepo = logRepo;
    //    }

    //    public int addLog(string obj_type, int obj_id, string act_type, string prev, string curr, IDbConnection connection, IDbTransaction transaction)
    //    {
    //        int data = 0;
    //        try
    //        {
    //            dynamic dt = _logRepo.addLogs(obj_type, obj_id, act_type, prev, curr, connection, transaction);
    //            data = dt.object_id;
    //        }
    //        catch (Exception)
    //        {

    //        }

    //        return data;
    //    }
    }

}
