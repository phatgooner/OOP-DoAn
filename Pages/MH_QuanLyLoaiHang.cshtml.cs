using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_QuanLyLoaiHangModel : PageModel
    {
		[BindProperty]
		public string Chuoi { get; set; } = string.Empty; //Property
		[BindProperty]
		public string tuKhoa { get; set; } = string.Empty; //Property

		private IXuLyLoaiHang _xuLyLoaiHang;//Property
		public List<LoaiHang> ds;//Property

		public MH_QuanLyLoaiHangModel() : base()
		{
			_xuLyLoaiHang = ObjectCreator.TaoDoiTuongLoaiHang();
			ds = new List<LoaiHang>();
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
				Chuoi = "Danh sách loại hàng";
				ds = _xuLyLoaiHang.DocDanhSach("");
			}
		}

		public void OnPost()
		{
			ds = _xuLyLoaiHang.DocDanhSach(tuKhoa);
		}
	}
}
