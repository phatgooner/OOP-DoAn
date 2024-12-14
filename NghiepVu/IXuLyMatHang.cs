using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public interface IXuLyMatHang
	{
		void ThemMatHang(MatHang sp);

		List<MatHang> DocDanhSach(string tuKhoa = "");

		List<MatHang> DocDanhSachTheoLoai(string tenLoai = "");

		MatHang? DocMatHang(string mssp);

		void SuaMatHang(string maHang, string ten, string loai, string congTy, string nsx, string hsd, int gia);

		void XoaMatHang(string mssp);

		void XoaMatHangTheoLoai(string tenLH);

		void SuaMatHangTheoLoai(string tenCu, string tenMoi);
	}
}
