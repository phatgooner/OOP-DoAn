using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_QuanLyHoaDonBanHangModel : PageModel
    {
		[BindProperty]
		public string tuKhoa { get; set; } = string.Empty; //Property

		private IXuLyHoaDon _xuLyHoaDonBanHang;//Property
		public List<HoaDon> ds;//Property

		public MH_QuanLyHoaDonBanHangModel() : base()
		{
			_xuLyHoaDonBanHang = ObjectCreator.TaoDoiTuongHoaDonBanHang();
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
				_xuLyHoaDonBanHang.CapNhatHoaDon();
				ds = _xuLyHoaDonBanHang.DocDanhSach("");
			}
		}

		public void OnPost()
		{
			_xuLyHoaDonBanHang.CapNhatHoaDon();
			ds = _xuLyHoaDonBanHang.DocDanhSach(tuKhoa);
		}
	}
}
