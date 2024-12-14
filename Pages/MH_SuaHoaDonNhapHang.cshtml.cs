using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_SuaHoaDonNhapHangModel : PageModel
    {
		public string Chuoi { get; set; } = string.Empty;
		public HoaDon? hd = null;

		[BindProperty]
		public string maHD { get; set; } = string.Empty;
		[BindProperty]
		public string tenNguoiBan { get; set; } = string.Empty;
		[BindProperty]
		public string ngayTao { get; set; } = string.Empty;

		private IXuLyHoaDon _xuLyHoaDonNhapHang;

		public MH_SuaHoaDonNhapHangModel() : base()
		{
			_xuLyHoaDonNhapHang = ObjectCreator.TaoDoiTuongHoaDonNhapHang();
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
				hd = _xuLyHoaDonNhapHang.DocHoaDon(maHD);
				if (hd != null)
				{
					tenNguoiBan = hd.TenNguoi;
				}
				else
				{
					Chuoi = "Không tìm thấy hóa đơn! ";
				}
			}
		}

		public void OnPost()
		{
			maHD = Request.Query["maHD"]!;
			hd = _xuLyHoaDonNhapHang.DocHoaDon(maHD);

			if (string.IsNullOrEmpty(tenNguoiBan))
			{
				Chuoi += "Tên người/đơn vị bán hàng không hợp lệ! ";
			}
			else if (string.IsNullOrEmpty(ngayTao))
			{
				Chuoi += "Ngày tạo hóa đơn không hợp lệ! ";
			}
			else
			{
				try
				{
					_xuLyHoaDonNhapHang.SuaHoaDon(maHD, tenNguoiBan, ngayTao);
					Response.Redirect($"/MH_ThemDanhMucNhapHang?maHD={maHD}");
				}
				catch (Exception ex)
				{
					Chuoi = ex.Message;
				}
			}
		}
	}
}
