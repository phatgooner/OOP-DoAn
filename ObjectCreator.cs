using DoAnMonHoc_23880108.LuuTru;
using DoAnMonHoc_23880108.NghiepVu;

namespace DoAnMonHoc_23880108
{
	public class ObjectCreator
	{
		public static IXuLyNguoiDung TaoDoiTuongNguoiDung()
		{
			ILuuTruNguoiDung luutru = new LuuTruNguoiDung();
			return new XuLyNguoiDung(luutru);
		}

		public static IXuLyMatHang TaoDoiTuongMatHang()
		{
			ILuuTruMatHang luutru = new LuuTruMatHang();
			return new XuLyMatHang(luutru);
		}

		public static IXuLyLoaiHang TaoDoiTuongLoaiHang()
		{
			ILuuTruLoaiHang luutru = new LuuTruLoaiHang();
			ILuuTruMatHang luu = new LuuTruMatHang();
			IXuLyMatHang xuLy = new XuLyMatHang(luu);
			return new XuLyLoaiHang(luutru, xuLy);
		}

		public static IXuLyHoaDon TaoDoiTuongHoaDonBanHang()
		{
			ILuuTruHoaDon luuTruHoaDonBanHang = new LuuTruHoaDonBanHang();
			ILuuTruDanhMuc luuTruDanhMucBanHang = new LuuTruDanhMucBanHang();
			IXuLyDanhMuc xuly = new XuLyDanhMucBanHang(luuTruDanhMucBanHang);
			return new XuLyHoaDonBanHang(luuTruHoaDonBanHang, xuly, luuTruDanhMucBanHang);
		}

		public static IXuLyHoaDon TaoDoiTuongHoaDonNhapHang()
		{
			ILuuTruHoaDon luuTruHoaDonNhapHang = new LuuTruHoaDonNhapHang();
			ILuuTruDanhMuc luuTruDanhMucNhapHang = new LuuTruDanhMucNhapHang();
			IXuLyDanhMuc xuly = new XuLyDanhMucNhapHang(luuTruDanhMucNhapHang);
			return new XuLyHoaDonNhapHang(luuTruHoaDonNhapHang, xuly, luuTruDanhMucNhapHang);
		}

		public static IXuLyDanhMuc TaoDoiTuongDanhMucBanHang()
		{
			ILuuTruDanhMuc luuTruDanhMucBanHang = new LuuTruDanhMucBanHang();
			return new XuLyDanhMucBanHang(luuTruDanhMucBanHang);
		}

		public static IXuLyDanhMuc TaoDoiTuongDanhMucNhapHang()
		{
			ILuuTruDanhMuc luuTruDanhMucNhapHang = new LuuTruDanhMucNhapHang();
			return new XuLyDanhMucNhapHang(luuTruDanhMucNhapHang);
		}

		public static IXuLyThongKe TaoDoiTuongThongKe()
		{
			ILuuTruMatHang luuTruMatHang = new LuuTruMatHang();
			ILuuTruDanhMuc luuTruDanhMucBanHang = new LuuTruDanhMucBanHang();
			ILuuTruDanhMuc luuTruDanhMucNhapHang = new LuuTruDanhMucNhapHang();
			return new XuLyThongKe(luuTruMatHang, luuTruDanhMucBanHang, luuTruDanhMucNhapHang);
		}
	}
}
