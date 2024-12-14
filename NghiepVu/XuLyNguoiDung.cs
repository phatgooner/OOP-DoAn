using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyNguoiDung : IXuLyNguoiDung
	{
		//Property
		private ILuuTruNguoiDung _luuTruNguoiDung;

		//Constructor
		public XuLyNguoiDung(ILuuTruNguoiDung luuTruNguoiDung)
		{
			_luuTruNguoiDung = luuTruNguoiDung;
		}

		public void ThemNguoiDung(NguoiDung user)
		{
			_luuTruNguoiDung.ThemNguoiDung(user);
		}

		public bool KiemTraDangNhap(string id, string pass)
		{
			List<NguoiDung> ds = _luuTruNguoiDung.DocDanhSachNguoiDung();
			foreach (NguoiDung d in ds)
			{
				if (d.Username == id && d.Password == pass)
				{
					return true;
				}
			}

			return false;
		}
	}
}
