using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_ThemHoaDonNhapHangModel : PageModel
    {
		public string Chuoi { get; set; } = string.Empty;

		[BindProperty]
		public string maHD { get; set; } = string.Empty;
		[BindProperty]
		public string tenNguoiBan { get; set; } = string.Empty;
		[BindProperty]
		public string ngayTao { get; set; } = string.Empty;

		private IXuLyHoaDon _xuLyHoaDonNhapHang;

		public MH_ThemHoaDonNhapHangModel() : base()
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
				Chuoi = "Thêm hóa đơn mới";
			}
		}

		public void OnPost()
		{
			if (string.IsNullOrEmpty(maHD))
			{
				Chuoi = "Mã hóa đơn không hợp lệ! ";
			}
			else if (string.IsNullOrEmpty(tenNguoiBan))
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
					HoaDon hd = new HoaDon(maHD.ToUpper(), tenNguoiBan, ngayTao);
					_xuLyHoaDonNhapHang.ThemHoaDon(hd);
					Chuoi = "Thêm hóa đơn thành công!";
					Response.Redirect($"/MH_ThemDanhMucNhapHang?maHD={hd.Ma}");
				}
				catch (Exception ex)
				{
					Chuoi = ex.Message;
				}
			}
		}
	}
}
