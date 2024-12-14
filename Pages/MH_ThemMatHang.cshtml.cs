﻿using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
    public class MH_ThemMatHangModel : PageModel
    {
        public string Chuoi {  get; set; } = string.Empty;
		public List<string> ds = new List<string>();
		public string? SelectedValue { get; set; }

		[BindProperty]
        public string maMH { get; set; } = string.Empty;
		[BindProperty]
		public string ten { get; set; } = string.Empty;
		[BindProperty]
		public string loai { get; set; } = string.Empty;
		[BindProperty]
		public string congTy { get; set; } = string.Empty;
		[BindProperty]
		public string nsx { get; set; } = string.Empty;
		[BindProperty]
		public string hsd { get; set; } = string.Empty;
		[BindProperty]
		public int gia { get; set; } = 0;

		private IXuLyMatHang _xuLyMatHang;
		private IXuLyLoaiHang _xuLyLoaiHang;

		public MH_ThemMatHangModel() : base()
		{
			_xuLyMatHang = ObjectCreator.TaoDoiTuongMatHang();
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
				ds = _xuLyLoaiHang.DocDanhSachLoaiHang();
				Chuoi = "Thêm sản phẩm mới";
			}	
		}

		public void OnPost()
		{
			if (string.IsNullOrEmpty(maMH))
			{
				Chuoi = "Mã mặt hàng không hợp lệ! ";
			}
			else if (string.IsNullOrEmpty(ten))
			{
				Chuoi += "Tên mặt hàng không hợp lệ! ";
			}
			else if(string.IsNullOrEmpty(loai))
			{
				Chuoi += "Tên loại hàng không hợp lệ! ";
			}
			else if(string.IsNullOrEmpty(loai))
			{
				Chuoi += "Tên công ty sản xuất không hợp lệ! ";
			}
			else if(string.IsNullOrEmpty(nsx))
			{
				Chuoi += "Ngày sản xuất không hợp lệ! ";
			}
			else if(string.IsNullOrEmpty(hsd))
			{
				Chuoi += "Hạn sử dụng không hợp lệ! ";
			}
			else if(gia <= 0)
			{
				Chuoi += "Giá mặt hàng không hợp lệ! ";
			}
            else
            {
				try
				{
					ds = _xuLyLoaiHang.DocDanhSachLoaiHang();
					MatHang sp = new MatHang(maMH.ToUpper(), ten, loai, congTy, nsx, hsd, gia);
					_xuLyMatHang.ThemMatHang(sp);
					Chuoi = "Thêm sản phẩm thành công!";
					Response.Redirect("/MH_QuanLyMatHang");
				}
				catch (Exception ex)
				{
					Chuoi = ex.Message;
				}
			}            
		}
    }
}
