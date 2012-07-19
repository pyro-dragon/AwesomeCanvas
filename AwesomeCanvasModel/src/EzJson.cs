using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace AwesomeCanvas
{
    public class EzJson
    {
        List<Dictionary<string, object>> l = new List<Dictionary<string, object>>();
        public void BeginFunction(string pName)
        {
            l.Add(new Dictionary<string, object>());
            current.Add("function", pName.ToLower());
        }
        public void AddData(string pKey, object pData) {
            current.Add(pKey.ToLower(), pData);
        }
        public Dictionary<string, object> current { get { return l.Last(); } }
        public string Finish() {
            Dictionary<string, object>[] arr = l.ToArray();
            l.Clear();
            return JsonConvert.SerializeObject(arr);
        }
    }
}
