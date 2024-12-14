using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_QuanLyHoaDonNhapHangModel : PageModel
    {
		[BindProperty]
		public string tuKhoa { get; set; } = string.Empty; //Property

		private IXuLyHoaDon _xuLyHoaDonNhapHang;//Property
		public List<HoaDon> ds;//Property

		public MH_QuanLyHoaDonNhapHangModel() : base()
		{
			_xuLyHoaDonNhapHang = ObjectCreator.TaoDoiTuongHoaDonNhapHang();
			ds = new List<HoaDon>();
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
				_xuLyHoaDonNhapHang.CapNhatHoaDon();
				ds = _xuLyHoaDonNhapHang.DocDanhSach("");
			}
		}

		public void OnPost()
		{
			_xuLyHoaDonNhapHang.CapNhatHoaDon();
			ds = _xuLyHoaDonNhapHang.DocDanhSach(tuKhoa);
		}
	}
}
