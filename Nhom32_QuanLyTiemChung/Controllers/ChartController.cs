using Nhom32_QuanLyTiemChung.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

public class ChartController : Controller
{
    // private string connectionString = "data source=VPMANH;initial catalog=QUANLYTIEMCHUNG3;integrated security=True"; // Thay thế chuỗi kết nối của bạn vào đây
    private string connectionString = "data source=QUANGQUY\\QUANGQUY;initial catalog=QUANLYTIEMCHUNG;integrated security=True";

    public ActionResult Index()
    {
        var vaccineDataList = GetVaccineData();
        return View(vaccineDataList);
    }

    private List<VaccineViewModel> GetVaccineData()
    {
        var vaccineDataList = new List<VaccineViewModel>();

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand("TongTreTiemTatCaVaccine", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var vaccine = new VaccineViewModel
                        {
                            TenVaccine = reader["tenVaccine"].ToString(),
                            SoLuongTreTiem = Convert.ToInt32(reader["SoLuongTreTiem"])
                        };
                        vaccineDataList.Add(vaccine);
                    }
                }
            }
        }

        return vaccineDataList;
    }
}
