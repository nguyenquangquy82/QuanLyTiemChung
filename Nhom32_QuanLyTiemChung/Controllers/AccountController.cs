using Nhom32_QuanLyTiemChung.Models;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Nhom32_QuanLyTiemChung.Controllers
{
    public class AccountController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        void ConnectionString()
        {
            con.ConnectionString = "data source=QUANGQUY\\QUANGQUY;initial catalog=QUANLYTIEMCHUNG;integrated security=True;";
        }

        // POST: Account/Verify
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            ConnectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from TaiKhoan where userName = @username and passWord = @password";
            com.Parameters.AddWithValue("@username", acc.userName);
            com.Parameters.AddWithValue("@password", acc.passWord);
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                con.Close();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                con.Close();
                ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng.";
                return View("Login");
            }
        }
    }
}
