using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.LuuTru
{
	public interface ILuuTruMatHang
	{
		void LuuDanhSach(List<MatHang> ds);

		List<MatHang> DocDanhSach();

		void ThemMatHang(MatHang sp);

		MatHang? DocMatHang(string mssp);

		void SuaMatHang(MatHang sp);

		void XoaMatHang(string mssp);
	}
}
