using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyThongKe : IXuLyThongKe
	{
		private ILuuTruMatHang _luuTruMatHang;
		private ILuuTruDanhMuc _luuTruDanhMucBanHang;
		private ILuuTruDanhMuc _luuTruDanhMucNhapHang;

		public XuLyThongKe(ILuuTruMatHang luuTruMatHang, ILuuTruDanhMuc luuTruDanhMucBanHang, ILuuTruDanhMuc luuTruDanhMucNhapHang)
		{
			_luuTruMatHang = luuTruMatHang;
			_luuTruDanhMucBanHang = luuTruDanhMucBanHang;
			_luuTruDanhMucNhapHang = luuTruDanhMucNhapHang;
		}

		public List<MatHang> DocDanhSachHetHan()
		{
			List<MatHang> kq = new List<MatHang>();
			List<MatHang> ds = _luuTruMatHang.DocDanhSach();

			foreach (MatHang m in ds)
			{
				if (m.HSD < DateOnly.FromDateTime(DateTime.Now))
				{
					kq.Add(m);
				}
			}
			return kq;
		}

		public int SoLuongHangConLai(string tenHang)
		{
			List<DanhMuc> a = _luuTruDanhMucNhapHang.DocDanhSach();
			List<DanhMuc> b = _luuTruDanhMucBanHang.DocDanhSach();
			int sum1 = 0;
			int sum2 = 0;
			foreach (DanhMuc m in a)
			{
				if (m.TenHang.ToUpper() == tenHang.ToUpper())
				{
					sum1 = sum1 + m.SoLuong;
				}
			}

			foreach (DanhMuc n in b)
			{
				if (n.TenHang.ToUpper() == tenHang.ToUpper())
				{
					sum2 = sum2 + n.SoLuong;
				}
			}

			return (sum1 - sum2);
		}

	}
}
