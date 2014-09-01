using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BlocketProject.Models.ViewModels
{
    [DataContract]
    public class JsonUserModel
    {
        [DataMember]
        public string id { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string first_name { get; set; }

        [DataContract]
        public class Hometown
        {
            [DataMember]
            public string id { get; set; }
            [DataMember]
            public string name { get; set; }
        }

        [DataContract]
        public class Location
        {
            [DataMember]
            public string id { get; set; }
            [DataMember]
            public string name { get; set; }
        }

        [DataMember]
        public Location location { get; set; }

        [DataMember]
        public Hometown hometown { get; set; }

        [DataMember]
        public string last_name { get; set; }
        [DataMember]
        public string name { get; set; }

        [DataContract]
        public class ImageUrl
        {
            [DataMember]
            public string imageUrl { get; set; }
        }

        [DataMember]
        public ImageUrl url { get; set; }

    }
}