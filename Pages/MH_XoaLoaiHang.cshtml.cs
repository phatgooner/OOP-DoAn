using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_XoaLoaiHangModel : PageModel
    {
		public string Chuoi { get; set; } = string.Empty;
		public string tuKhoa { get; set; } = string.Empty;
		public string maLH { get; set; } = string.Empty;
		private IXuLyLoaiHang _xuLyLoaiHang;

		public MH_XoaLoaiHangModel() : base()
		{
			_xuLyLoaiHang = ObjectCreator.TaoDoiTuongLoaiHang();
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
				maLH = Request.Query["maLH"]!;
				LoaiHang? lh = _xuLyLoaiHang.DocLoaiHang(maLH);
				if (lh != null)
				{
					Chuoi = $"Bạn có chắc muốn xóa loại hàng <{lh.Ten}>? Tất cả sản phẩm thuộc loại hàng này sẽ bị mất vĩnh viễn nếu xóa!";
				}
				else
				{
					tuKhoa = "Không tìm thấy loại hàng! ";
				}
			}
		}

		public void OnPost()
		{
			maLH = Request.Query["maLH"]!;
			LoaiHang? lh = _xuLyLoaiHang.DocLoaiHang(maLH);
			if (lh != null)
			_xuLyLoaiHang.XoaLoaiHang(maLH, lh.Ten);
			Response.Redirect("/Index");
		}
	}
}
