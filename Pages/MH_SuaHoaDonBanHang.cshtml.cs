using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_SuaHoaDonBanHangModel : PageModel
    {
		public string Chuoi { get; set; } = string.Empty;
		public HoaDon? hd = null;

		[BindProperty]
		public string maHD { get; set; } = string.Empty;
		[BindProperty]
		public string tenNguoiMua { get; set; } = string.Empty;
		[BindProperty]
		public string ngayTao { get; set; } = string.Empty;

		private IXuLyHoaDon _xuLyHoaDonBanHang;

		public MH_SuaHoaDonBanHangModel() : base()
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
				hd = _xuLyHoaDonBanHang.DocHoaDon(maHD);
				if (hd != null)
				{
					tenNguoiMua = hd.TenNguoi;
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
			hd = _xuLyHoaDonBanHang.DocHoaDon(maHD);

			if (string.IsNullOrEmpty(tenNguoiMua))
			{
				Chuoi += "Tên người/đơn vị mua hàng không hợp lệ! ";
			}
			else if (string.IsNullOrEmpty(ngayTao))
			{
				Chuoi += "Ngày tạo hóa đơn không hợp lệ! ";
			}
			else
			{
				try
				{
					_xuLyHoaDonBanHang.SuaHoaDon(maHD, tenNguoiMua, ngayTao);
					Response.Redirect($"/MH_ThemDanhMucBanHang?maHD={maHD}");
				}
				catch (Exception ex)
				{
					Chuoi = ex.Message;
				}
			}
		}
	}
}
