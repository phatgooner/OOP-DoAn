using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public interface IXuLyDanhMuc
	{
		void ThemDanhMuc(DanhMuc dm);

		List<DanhMuc> DocDanhSachTheoHoaDon(string maHD = "");

		DanhMuc? DocDanhMuc(string maHD, string tenHang);

		DanhMuc? SuaDanhMuc(string maHoaDon, string tenHangCu, string tenHangMoi, string donVi, int soLuong, int donGia);

		void XoaDanhMucTheoHoaDon(string maHD);

		void XoaDanhMucTheoTenMatHang(string maHD, string tenMatHang);

		List<string> DocDanhSachTenHangNhap();
	}
}
