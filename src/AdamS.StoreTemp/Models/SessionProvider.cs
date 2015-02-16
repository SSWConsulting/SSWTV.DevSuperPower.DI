using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdamS.StoreTemp.Models
{
    public interface IStateProvider
    {
        string Get(string key);
    }

    public class CookieManager : IStateProvider
    {

        public string Get(string key)
        {
            return "key:" + key;
        }
    }
   

}