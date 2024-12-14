using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyDanhMucBanHang : IXuLyDanhMuc
	{
		private ILuuTruDanhMuc _luuTruDanhMucBanHang;

		public XuLyDanhMucBanHang(ILuuTruDanhMuc luuTruDanhMucBanHang)
		{
			_luuTruDanhMucBanHang = luuTruDanhMucBanHang;
		}

		public void ThemDanhMuc(DanhMuc dm)
		{
			_luuTruDanhMucBanHang.ThemDanhMuc(dm);
		}

		public List<DanhMuc> DocDanhSachTheoHoaDon(string maHD = "")
		{
			List<DanhMuc> kq = new List<DanhMuc>();
			List<DanhMuc> ds = _luuTruDanhMucBanHang.DocDanhSach();

			foreach (DanhMuc s in ds)
			{
				if (s.MaHoaDon.ToLower() == maHD.ToLower())
				{
					kq.Add(s);
				}
			}
			return kq;			
		}

		public DanhMuc? DocDanhMuc(string maHD, string tenHang)
		{
			return _luuTruDanhMucBanHang.DocDanhMuc(maHD, tenHang);
		}

		public DanhMuc? SuaDanhMuc(string maHoaDon, string tenHangCu, string tenHangMoi, string donVi, int soLuong, int donGia)
		{
			DanhMuc? dm = _luuTruDanhMucBanHang.DocDanhMuc(maHoaDon, tenHangCu);
			if (dm != null)
			{
				DanhMuc dmNew = new DanhMuc(maHoaDon, tenHangMoi, donVi, soLuong, donGia);
				_luuTruDanhMucBanHang.ThemDanhMuc(dmNew);
			}
			return null;
		}

		public void XoaDanhMucTheoHoaDon(string maHD)
		{
			_luuTruDanhMucBanHang.XoaDanhMucTheoHoaDon(maHD);
		}

		public void XoaDanhMucTheoTenMatHang(string maHD, string tenMatHang)
		{
			_luuTruDanhMucBanHang.XoaDanhMucTheoTenMatHang(maHD, tenMatHang);
		}

		public List<string> DocDanhSachTenHangNhap()
		{
			return new List<string>();
		}
	}
}
