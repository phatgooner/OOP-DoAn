using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.LuuTru
{
	public interface ILuuTruDanhMuc
	{
		void LuuDanhSach(List<DanhMuc> ds);

		List<DanhMuc> DocDanhSach();

		void ThemDanhMuc(DanhMuc sp);

		DanhMuc? DocDanhMuc(string maHD, string tenHang);

		void XoaDanhMucTheoHoaDon(string maHD);

		void XoaDanhMucTheoTenMatHang(string maHD, string tenMatHang);
	}
}
