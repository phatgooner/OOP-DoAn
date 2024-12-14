using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.LuuTru
{
	public interface ILuuTruLoaiHang
	{
		void LuuDanhSach(List<LoaiHang> ds);

		List<LoaiHang> DocDanhSach();

		void ThemLoaiHang(LoaiHang h);

		LoaiHang? DocLoaiHang(string ma);

		void SuaLoaiHang(LoaiHang lh);

		void XoaLoaiHang(string ma);
	}
}
