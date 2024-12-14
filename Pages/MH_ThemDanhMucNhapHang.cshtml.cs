using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
	public class MH_ThemDanhMucNhapHangModel : PageModel
	{
		public HoaDon? hd = null;
		public List<DanhMuc> mh = new List<DanhMuc>();
		public int sum;

		public string Chuoi { get; set; } = string.Empty;

		[BindProperty]
		public string maHD { get; set; } = string.Empty;
		[BindProperty]
		public string tenHang { get; set; } = string.Empty;
		[BindProperty]
		public string donVi { get; set; } = string.Empty;
		[BindProperty]
		public int soLuong { get; set; } = 0;
		[BindProperty]
		public int donGia { get; set; } = 0;

		private IXuLyDanhMuc _xuLyDanhMucNhapHang;
		private IXuLyHoaDon _xuLyHoaDonNhapHang;

		public MH_ThemDanhMucNhapHangModel() : base()
		{
			_xuLyDanhMucNhapHang = ObjectCreator.TaoDoiTuongDanhMucNhapHang();
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
				string maHoaDon = Request.Query["maHD"]!;
				hd = _xuLyHoaDonNhapHang.DocHoaDon(maHoaDon);
				if (hd != null)
				{
					mh = _xuLyDanhMucNhapHang.DocDanhSachTheoHoaDon(hd.Ma);
					sum = _xuLyHoaDonNhapHang.TongGiaTriHoaDon(maHoaDon);
				}
			}
		}

		public void OnPost()
		{
			string maHoaDon = Request.Query["maHD"]!;
			hd = _xuLyHoaDonNhapHang.DocHoaDon(maHoaDon);
			if (hd != null)
			{
				mh = _xuLyDanhMucNhapHang.DocDanhSachTheoHoaDon(hd.Ma);
				sum = _xuLyHoaDonNhapHang.TongGiaTriHoaDon(maHoaDon);
				if (Request.Form["action"] == "add")
				{
					if (string.IsNullOrEmpty(tenHang) || string.IsNullOrEmpty(donVi) || soLuong <= 0 || donGia <= 0)
					{
						Chuoi = "Thông tin mặt hàng không hợp lệ";
					}
					else
					{
						try
						{
							DanhMuc dm = new DanhMuc(hd.Ma, tenHang, donVi, soLuong, donGia);
							_xuLyDanhMucNhapHang.ThemDanhMuc(dm);
							Response.Redirect($"/MH_ThemDanhMucNhapHang?maHD={hd.Ma}");

						}
						catch (Exception ex)
						{
							Chuoi = ex.Message;
						}
					}					
				}
				if (Request.Form["action"] == "save")
				{
					Response.Redirect($"/MH_XemChiTietHoaDonNhapHang?maHD={hd.Ma}");
				}
			}
		}
	}
}
