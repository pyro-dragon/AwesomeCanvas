using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
namespace AwesomeCanvas.Application
{
    public class EzJson
    {
        List<Dictionary<string,string>> l = new List<Dictionary<string,string>>();
        public void BeginFunction(string pName)
        {
            l.Add(new Dictionary<string,string>());
            current.Add("function", pName.ToLower());
        }
        public void AddData(string pKey, string pData) {
            current.Add(pKey.ToLower(), pData.ToLower());
        }
        public Dictionary<string, string> current { get { return l.Last(); } }
        public string Finish() {
            Dictionary<string, string>[] arr = l.ToArray();
            l.Clear();
            return JsonConvert.SerializeObject(arr);
        }
    }
}
