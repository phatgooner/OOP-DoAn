using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_XemChiTietLoaiHangModel : PageModel
    {
		[BindProperty]
		public string Chuoi { get; set; } = string.Empty; //Property
		[BindProperty]
		public string tenLoai { get; set; } = string.Empty; //Property

		private IXuLyMatHang _xuLyMatHang;//Property
		public List<MatHang> ds;//Property

		public MH_XemChiTietLoaiHangModel() : base()
		{
			_xuLyMatHang = ObjectCreator.TaoDoiTuongMatHang();
			ds = new List<MatHang>();
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
				tenLoai = Request.Query["tenLH"]!;
				Chuoi = $"Danh sách mặt hàng thuộc loại hàng {tenLoai}";
				ds = _xuLyMatHang.DocDanhSachTheoLoai(tenLoai);
			}
		}
    }
}
