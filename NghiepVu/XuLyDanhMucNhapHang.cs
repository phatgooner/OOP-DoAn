using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyDanhMucNhapHang : IXuLyDanhMuc
	{
		private ILuuTruDanhMuc _luuTruDanhMucNhapHang;

		public XuLyDanhMucNhapHang(ILuuTruDanhMuc luuTruDanhMucNhapHang)
		{
			_luuTruDanhMucNhapHang = luuTruDanhMucNhapHang;
		}

		public void ThemDanhMuc(DanhMuc dm)
		{
			_luuTruDanhMucNhapHang.ThemDanhMuc(dm);
		}

		public List<DanhMuc> DocDanhSachTheoHoaDon(string maHD = "")
		{
			List<DanhMuc> kq = new List<DanhMuc>();
			List<DanhMuc> ds = _luuTruDanhMucNhapHang.DocDanhSach();

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
			return _luuTruDanhMucNhapHang.DocDanhMuc(maHD, tenHang);
		}

		public DanhMuc? SuaDanhMuc(string maHoaDon, string tenHangCu, string tenHangMoi, string donVi, int soLuong, int donGia)
		{
			DanhMuc? dm = _luuTruDanhMucNhapHang.DocDanhMuc(maHoaDon, tenHangCu);
			if (dm != null)
			{
				DanhMuc dmNew = new DanhMuc(maHoaDon, tenHangMoi, donVi, soLuong, donGia);
				_luuTruDanhMucNhapHang.ThemDanhMuc(dmNew);
			}
			return null;
		}

		public void XoaDanhMucTheoHoaDon(string maHD)
		{
			_luuTruDanhMucNhapHang.XoaDanhMucTheoHoaDon(maHD);
		}

		public void XoaDanhMucTheoTenMatHang(string maHD, string tenMatHang)
		{
			_luuTruDanhMucNhapHang.XoaDanhMucTheoTenMatHang(maHD, tenMatHang);
		}

		public List<string> DocDanhSachTenHangNhap()
		{
			List<DanhMuc> a = _luuTruDanhMucNhapHang.DocDanhSach();
			List<string> s = new List<string>();
			foreach (DanhMuc m in a)
			{
				s.Add(m.TenHang.ToUpper());
			}
			return s.Distinct().ToList();
		}
	}
}
