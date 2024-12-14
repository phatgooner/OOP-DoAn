using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
	public class MH_QuanLyMatHangModel : PageModel
	{
		[BindProperty]
		public string Chuoi { get; set; } = string.Empty; //Property
		[BindProperty]
		public string tuKhoa { get; set; } = string.Empty; //Property

		private IXuLyMatHang _xuLyMatHang;//Property
		public List<MatHang> ds;//Property

		public MH_QuanLyMatHangModel() : base()
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
				Chuoi = "Danh sách mặt hàng";
				ds = _xuLyMatHang.DocDanhSach("");
			}
		}

		public void OnPost()
		{
			ds = _xuLyMatHang.DocDanhSach(tuKhoa);
		}
	}
}
