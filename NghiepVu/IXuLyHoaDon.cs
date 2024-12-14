using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public interface IXuLyHoaDon
	{
		void ThemHoaDon(HoaDon hd);

		List<HoaDon> DocDanhSach(string tuKhoa = "");

		HoaDon? DocHoaDon(string ma);

		void SuaHoaDon(string ma, string ten, string ngay);

		void XoaHoaDon(string ma);

		int TongGiaTriHoaDon(string maHD);

		void CapNhatHoaDon();
	}
}
