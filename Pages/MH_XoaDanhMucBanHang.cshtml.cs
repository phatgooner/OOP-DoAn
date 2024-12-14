using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_XoaDanhMucBanHangModel : PageModel
    {
		private IXuLyDanhMuc _xuLyDanhMucBanHang;

		public MH_XoaDanhMucBanHangModel() : base()
		{
			_xuLyDanhMucBanHang = ObjectCreator.TaoDoiTuongDanhMucBanHang();
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
				string maHoaDon = Request.Query["maHD"]!;
				string tenHang = Request.Query["tenHang"]!;
				_xuLyDanhMucBanHang.XoaDanhMucTheoTenMatHang(maHoaDon, tenHang);
				Response.Redirect($"/MH_ThemDanhMucBanHang?maHD={maHoaDon}");
			}
		}
	}
}
