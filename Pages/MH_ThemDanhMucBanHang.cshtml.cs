using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_ThemDanhMucBanHangModel : PageModel
    {
		public HoaDon? hd = null;
		public List<DanhMuc> mh = new List<DanhMuc>();
		public int sum;
		public int soLuongMax;
		public List<string> a = new List<string>();
		public string? SelectedValue { get; set; }
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

		private IXuLyDanhMuc _xuLyDanhMucBanHang;
		private IXuLyDanhMuc _xuLyDanhMucNhapHang;
		private IXuLyHoaDon _xuLyHoaDonBanHang;
		private IXuLyThongKe _xuLyThongKe;

		public MH_ThemDanhMucBanHangModel() : base()
		{
			_xuLyDanhMucBanHang = ObjectCreator.TaoDoiTuongDanhMucBanHang();
			_xuLyHoaDonBanHang = ObjectCreator.TaoDoiTuongHoaDonBanHang();
			_xuLyDanhMucNhapHang = ObjectCreator.TaoDoiTuongDanhMucNhapHang();
			_xuLyThongKe = ObjectCreator.TaoDoiTuongThongKe();
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
				a = _xuLyDanhMucNhapHang.DocDanhSachTenHangNhap();
				if (hd != null)
				{
					mh = _xuLyDanhMucBanHang.DocDanhSachTheoHoaDon(hd.Ma);
					sum = _xuLyHoaDonBanHang.TongGiaTriHoaDon(maHoaDon);
				}
			}
		}

		public void OnPost()
		{
			string maHoaDon = Request.Query["maHD"]!;
			hd = _xuLyHoaDonBanHang.DocHoaDon(maHoaDon);
			a = _xuLyDanhMucNhapHang.DocDanhSachTenHangNhap();
			soLuongMax = _xuLyThongKe.SoLuongHangConLai(tenHang);
			if (hd != null)
			{
				mh = _xuLyDanhMucBanHang.DocDanhSachTheoHoaDon(hd.Ma);
				sum = _xuLyHoaDonBanHang.TongGiaTriHoaDon(maHoaDon);
				if (Request.Form["action"] == "add")
				{
					if (string.IsNullOrEmpty(tenHang) || string.IsNullOrEmpty(donVi) || soLuong <= 0 || donGia <= 0)
					{
						Chuoi = "Thông tin mặt hàng không hợp lệ";
					}
					else if(soLuong > soLuongMax)
					{
						Chuoi = "Số lượng vượt quá số lượng hiện tại của mặt hàng!";
					}	
					else
					{
						try
						{
							DanhMuc dm = new DanhMuc(hd.Ma, tenHang, donVi, soLuong, donGia);
							_xuLyDanhMucBanHang.ThemDanhMuc(dm);
							Response.Redirect($"/MH_ThemDanhMucBanHang?maHD={hd.Ma}");
						}
						catch (Exception ex)
						{
							Chuoi = ex.Message;
						}
					}
				}
				if (Request.Form["action"] == "save")
				{
					Response.Redirect($"/MH_XemChiTietHoaDonBanHang?maHD={hd.Ma}");
				}
			}
		}
	}
}
