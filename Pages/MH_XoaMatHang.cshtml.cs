using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_XoaMatHangModel : PageModel
    {
		public string Chuoi { get; set; } = string.Empty;
		public string tuKhoa { get; set; } = string.Empty;
		public string maMH { get; set; } = string.Empty;
		private IXuLyMatHang _xuLyMatHang;

		public MH_XoaMatHangModel() : base()
		{
			_xuLyMatHang = ObjectCreator.TaoDoiTuongMatHang();
		}

		public void OnGet()
        {
			string username = HttpContext.Session.GetString("username")!;

			if (string.IsNullOrEmpty(username))
			{
				Response.Redirect("/MH_TrangChu");
			}
			else
			{
				maMH = Request.Query["maMH"]!;
				MatHang? sp = _xuLyMatHang.DocMatHang(maMH);
				if (sp != null)
				{
					Chuoi = $"Bạn có chắc muốn xóa mặt hàng <{sp.Ma}>? ";
				}
				else
				{
					tuKhoa = "Không tìm thấy mặt hàng! ";
				}
			}
		}

		public void OnPost()
		{
			maMH = Request.Query["maMH"]!;
			_xuLyMatHang.XoaMatHang(maMH);
			Response.Redirect("/Index");
		}
    }
}
