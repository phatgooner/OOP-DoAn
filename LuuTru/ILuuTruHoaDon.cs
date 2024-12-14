using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.LuuTru
{
	public interface ILuuTruHoaDon
	{
		void LuuDanhSach(List<HoaDon> ds);

		List<HoaDon> DocDanhSach();

		void ThemHoaDon(HoaDon hd);

		HoaDon? DocHoaDon(string ma);

		void SuaHoaDon(HoaDon hd);

		void XoaHoaDon(string ma);
	}
}
