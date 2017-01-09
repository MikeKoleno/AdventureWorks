using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization;

namespace AdventureWorks.Model
{
    [Serializable]
    [DataContract]
    public class Shift
    {
        private int id;
        private string name;
        private Time startTime;
        private Time endTime;

        [DataMember]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        [DataMember]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        [DataMember]
        public Time StartTime
        {
            get
            {
                return startTime;
            }

            set
            {
                startTime = value;
            }
        }

        [DataMember]
        public Time EndTime
        {
            get
            {
                return endTime;
            }

            set
            {
                endTime = value;
            }
        }
    }
}
