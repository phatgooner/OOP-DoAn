using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
	public class MH_DangKyModel : PageModel
	{
		[BindProperty]
		public string id { get; set; } = string.Empty;
		[BindProperty]
		public string pass1 { get; set; } = string.Empty;
		[BindProperty]
		public string pass2 { get; set; } = string.Empty;

		public string Chuoi { get; set; } = string.Empty;

		private IXuLyNguoiDung _xuLyNguoiDung;

		public MH_DangKyModel() : base()
		{
			_xuLyNguoiDung = ObjectCreator.TaoDoiTuongNguoiDung();
		}

		public void OnGet()
		{
			Chuoi = "Tạo tài khoản đăng nhập của bạn";
		}
		public void OnPost()
		{
			if (pass1 == pass2 && !string.IsNullOrEmpty(pass2) && !string.IsNullOrEmpty(id))
			{
				try
				{
					NguoiDung user = new NguoiDung(id, pass2);
					_xuLyNguoiDung.ThemNguoiDung(user);
					Chuoi = "Tạo tài khoản người dùng thành công! ";
					Response.Redirect("/MH_DangNhap");
				}
				catch (Exception ex)
				{
					Chuoi += ex.Message;
				}
			}
			else
			{
				Chuoi = "Thông tin tài khoản không hợp lệ hoặc xác thực mật khẩu không trùng khớp";
			}
		}

	}
}
