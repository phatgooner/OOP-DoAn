using DoAnMonHoc_23880108.Entity;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public interface IXuLyThongKe
	{
		List<MatHang> DocDanhSachHetHan();

		int SoLuongHangConLai(string tenHang);
	}
}
