using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.LuuTru
{
	public interface ILuuTruNguoiDung
	{
		void LuuDanhSachNguoiDung(List<NguoiDung> ds);

		List<NguoiDung> DocDanhSachNguoiDung();

		void ThemNguoiDung(NguoiDung user);
	}
}
