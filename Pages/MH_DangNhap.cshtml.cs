using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.NghiepVu;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DoAnMonHoc_23880108.Pages
{
	public class MH_DangNhapModel : PageModel
	{
		public string Chuoi { get; set; } = string.Empty;

		[BindProperty]
		public string id { get; set; }
		[BindProperty]
		public string password { get; set; }

		private IXuLyNguoiDung _xuLyNguoiDung;

		//Constructor
		public MH_DangNhapModel() : base()
		{
			_xuLyNguoiDung = ObjectCreator.TaoDoiTuongNguoiDung();
		}

		public void OnGet()
		{
			Chuoi = "Đăng nhập tài khoản của bạn";
		}

		public void OnPost()
		{
			try
			{
				if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(password))
				{
					if (_xuLyNguoiDung.KiemTraDangNhap(id, password) == true)
					{
						NguoiDung user = new NguoiDung(id, password);
						HttpContext.Session.SetString("username", user.Username);
						Chuoi = "Đăng nhập thành công!";
						Response.Redirect("/Index");
					}
					else
					{
						Chuoi = "Mật khẩu hoặc username không đúng";
					}
				}
				else
				{
					Chuoi = "Mật khẩu và username không được bỏ trống!";
				}	
				
			}
			catch (Exception ex)
			{
				Chuoi = ex.Message;
			}
		}
	}
}
