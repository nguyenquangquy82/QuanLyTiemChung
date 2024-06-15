
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nhom32_QuanLyTiemChung.Models
{
    public class Account
    {
        public int idTK { get; set; }
        public string userName { get; set; }
        public string passWord { get; set; }
        public int idQuyen { get; set; }
    }
}