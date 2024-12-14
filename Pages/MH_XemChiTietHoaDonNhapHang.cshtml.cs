using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
	public class MH_XemChiTietHoaDonNhapHangModel : PageModel
	{
		public HoaDon? hd = null;
		public List<DanhMuc> mh;
		public int sum;
		public string maHoaDon = string.Empty;

		public string Chuoi { get; set; } = string.Empty;

		private IXuLyDanhMuc _xuLyDanhMucNhapHang;
		private IXuLyHoaDon _xuLyHoaDonNhapHang;

		public MH_XemChiTietHoaDonNhapHangModel() : base()
		{
			_xuLyDanhMucNhapHang = ObjectCreator.TaoDoiTuongDanhMucNhapHang();
			_xuLyHoaDonNhapHang = ObjectCreator.TaoDoiTuongHoaDonNhapHang();
			hd = _xuLyHoaDonNhapHang.DocHoaDon(maHoaDon);
			mh = new List<DanhMuc>();
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
				hd = _xuLyHoaDonNhapHang.DocHoaDon(maHoaDon);
				if (hd != null)
				{
					mh = _xuLyDanhMucNhapHang.DocDanhSachTheoHoaDon(hd.Ma);
					sum = _xuLyHoaDonNhapHang.TongGiaTriHoaDon(hd.Ma);
				}
			}
		}
	}
}
