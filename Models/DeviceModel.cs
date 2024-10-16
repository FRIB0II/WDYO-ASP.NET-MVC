using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WhatDoYouOwn_ASPNET.Enums;

namespace WhatDoYouOwn_ASPNET.Models
{
    public class DeviceModel
    {
        [Key]
        public int IdComputador { get; set; }
        [ForeignKey(nameof(UserModel.IdUsuario))]
        public int IdfUsuario { get; set; }
        public StatusEnum Status { get; set; }
        public string HostName { get; set; }
        public string Ipv4 { get; set; }
        public string UltimoUsuario { get; set; }
    }
}
