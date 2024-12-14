using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public interface IXuLyNguoiDung
	{
		void ThemNguoiDung(NguoiDung user);

		bool KiemTraDangNhap(string id, string pass);
	}
}
