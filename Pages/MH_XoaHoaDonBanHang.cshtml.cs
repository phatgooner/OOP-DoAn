using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_XoaHoaDonBanHangModel : PageModel
    {
		public string Chuoi { get; set; } = string.Empty;
		public string tuKhoa { get; set; } = string.Empty;
		public string maHD { get; set; } = string.Empty;
		private IXuLyHoaDon _xuLyHoaDonBanHang;

		public MH_XoaHoaDonBanHangModel() : base()
		{
			_xuLyHoaDonBanHang = ObjectCreator.TaoDoiTuongHoaDonBanHang();
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
				maHD = Request.Query["maHD"]!;
				HoaDon? hd = _xuLyHoaDonBanHang.DocHoaDon(maHD);
				if (hd != null)
				{
					Chuoi = $"Bạn có chắc muốn xóa hóa đơn <{hd.Ma}>? ";
				}
				else
				{
					tuKhoa = "Không tìm thấy hóa đơn! ";
				}
			}
		}

		public void OnPost()
		{
			maHD = Request.Query["maHD"]!;
			_xuLyHoaDonBanHang.XoaHoaDon(maHD);
			Response.Redirect("/MH_QuanLyHoaDonBanHang");
		}
	}
}
