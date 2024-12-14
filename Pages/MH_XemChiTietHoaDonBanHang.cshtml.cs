using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_XemChiTietHoaDonBanHangModel : PageModel
    {
		public HoaDon? hd = null;
		public List<DanhMuc> mh;
		public int sum;
		public string maHoaDon = string.Empty;

		public string Chuoi { get; set; } = string.Empty;

		private IXuLyDanhMuc _xuLyDanhMucBanHang;
		private IXuLyHoaDon _xuLyHoaDonBanHang;

		public MH_XemChiTietHoaDonBanHangModel() : base()
		{
			_xuLyDanhMucBanHang = ObjectCreator.TaoDoiTuongDanhMucBanHang();
			_xuLyHoaDonBanHang = ObjectCreator.TaoDoiTuongHoaDonBanHang();
			hd = _xuLyHoaDonBanHang.DocHoaDon(maHoaDon);
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
				hd = _xuLyHoaDonBanHang.DocHoaDon(maHoaDon);
				if (hd != null)
				{
					mh = _xuLyDanhMucBanHang.DocDanhSachTheoHoaDon(hd.Ma);
					sum = _xuLyHoaDonBanHang.TongGiaTriHoaDon(hd.Ma);
				}
			}
		}
	}
}
