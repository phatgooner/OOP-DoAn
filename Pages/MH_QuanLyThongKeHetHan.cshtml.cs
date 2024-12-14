using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
	public class MH_QuanLyThongKeHetHanModel : PageModel
	{
		public List<MatHang> ds = new List<MatHang>();

		private IXuLyThongKe _xuLyThongKe;

		public MH_QuanLyThongKeHetHanModel() : base()
		{
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
				ds = _xuLyThongKe.DocDanhSachHetHan();
			}
		}
	}
}
