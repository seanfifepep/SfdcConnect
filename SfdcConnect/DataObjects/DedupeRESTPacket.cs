using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SfdcConnect
{
    public class DedupeRESTPacket
    {
        public DedupeRESTPacket()
        {
            recordsToMerge = new List<string>();
            updateIfBlankFields = new List<string>();
            fieldsOfRecreateChildRecords = new Dictionary<string, List<string>>();
            fieldsOfReparentChildRecords = new Dictionary<string, List<string>>();
            updateValuesFromRules = new Dictionary<string, string>();
        }

        public string objectName;
        public string idOfRecordToKeep;
        public string idOfMasterRecord;
        public List<string> recordsToMerge;
        public List<string> updateIfBlankFields;
        public Dictionary<string, string> updateValuesFromRules;
        public Dictionary<string, List<string>> fieldsOfReparentChildRecords;
        public Dictionary<string, List<string>> fieldsOfRecreateChildRecords;
    }
}
