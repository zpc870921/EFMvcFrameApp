using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EFMvcFrame.Model.Entites
{
    [DataContract]
    public class Person
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [MaxLength(255)]
        [DefaultValue("")]
        public string Name { get; set; }
        [DataMember]
        [DefaultValue(0)]
        public int Age { get; set; }

        [DataMember]
        [MaxLength(255)]
        [DefaultValue("")]
        public string Address { get; set; }
        [DataMember]
        [MaxLength(13)]
        [DefaultValue("")]
        public string Mobile { get; set; }
        [DataMember]
        [DefaultValue(false)]
        public bool Sex { get; set; }

        [DataMember]
        public DateTime CreateTime { get; set; }


       
    }
}
