using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_XoaDanhMucNhapHangModel : PageModel
    {
		private IXuLyDanhMuc _xuLyDanhMucNhapHang;

		public MH_XoaDanhMucNhapHangModel() : base() 
		{
			_xuLyDanhMucNhapHang = ObjectCreator.TaoDoiTuongDanhMucNhapHang();
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
				_xuLyDanhMucNhapHang.XoaDanhMucTheoTenMatHang(maHoaDon, tenHang);
				Response.Redirect($"/MH_ThemDanhMucNhapHang?maHD={maHoaDon}");
			}
		}
    }
}
