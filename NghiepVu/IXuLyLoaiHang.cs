using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public interface IXuLyLoaiHang
	{
		void ThemLoaiHang(LoaiHang sp);

		List<LoaiHang> DocDanhSach(string tuKhoa = "");

		LoaiHang? DocLoaiHang(string mssp);

		void SuaLoaiHang(string ma, string tencu, string tenmoi);

		void XoaLoaiHang(string ma, string ten);

		List<string> DocDanhSachLoaiHang();
	}
}
