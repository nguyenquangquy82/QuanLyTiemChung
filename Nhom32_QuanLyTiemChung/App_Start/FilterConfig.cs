﻿using System.Web;
using System.Web.Mvc;

namespace Nhom32_QuanLyTiemChung
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
		{
			filters.Add(new HandleErrorAttribute());
		}
	}
}
