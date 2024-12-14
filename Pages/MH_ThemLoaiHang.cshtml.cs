using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_ThemLoaiHangModel : PageModel
    {
		public string Chuoi { get; set; } = string.Empty;

		[BindProperty]
		public string ma { get; set; } = string.Empty;
		[BindProperty]
		public string ten { get; set; } = string.Empty;

		private IXuLyLoaiHang _xuLyLoaiHang;

		public MH_ThemLoaiHangModel() : base()
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
				Chuoi = "Thêm sản phẩm mới";
			}
		}

		public void OnPost()
		{
			if (string.IsNullOrEmpty(ma))
			{
				Chuoi = "Mã loại hàng không hợp lệ! ";
			}
			else if (string.IsNullOrEmpty(ten))
			{
				Chuoi += "Tên loại hàng không hợp lệ! ";
			}			
			else
			{
				try
				{
					LoaiHang lh = new LoaiHang(ma.ToUpper(), ten);
					_xuLyLoaiHang.ThemLoaiHang(lh);
					Chuoi = "Thêm loại hàng thành công!";
					Response.Redirect("/MH_QuanLyLoaiHang");
				}
				catch (Exception ex)
				{
					Chuoi = ex.Message;
				}
			}
		}
	}
}
