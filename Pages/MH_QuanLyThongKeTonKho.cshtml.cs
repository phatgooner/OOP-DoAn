using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
	public class MH_QuanLyThongKeTonKhoModel : PageModel
	{
		public List<string> ds = new List<string>();
		private IXuLyDanhMuc _xuLyDanhMucNhapHang;
		private IXuLyThongKe _xuLyThongKe;		

		public MH_QuanLyThongKeTonKhoModel() : base()
		{
			_xuLyDanhMucNhapHang = ObjectCreator.TaoDoiTuongDanhMucNhapHang();
			_xuLyThongKe = ObjectCreator.TaoDoiTuongThongKe();
		}

		public int SoLuongSanPhamConLai(string tensp)
		{
			return _xuLyThongKe.SoLuongHangConLai(tensp);
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
				ds = _xuLyDanhMucNhapHang.DocDanhSachTenHangNhap();
			}
		}
	}
}

