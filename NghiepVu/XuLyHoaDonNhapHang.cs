using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyHoaDonNhapHang : IXuLyHoaDon
	{
		private ILuuTruHoaDon _luuTruHoaDonNhapHang;
		private IXuLyDanhMuc _xuLyDanhMucNhapHang;
		private ILuuTruDanhMuc _luuTruDanhMucNhapHang;


		public XuLyHoaDonNhapHang(ILuuTruHoaDon luuTruHoaDonNhapHang, IXuLyDanhMuc xuLyDanhMucNhapHang, ILuuTruDanhMuc luuTruDanhMucNhapHang)
		{
			_luuTruHoaDonNhapHang = luuTruHoaDonNhapHang;
			_xuLyDanhMucNhapHang = xuLyDanhMucNhapHang;
			_luuTruDanhMucNhapHang = luuTruDanhMucNhapHang;
		}

		public void ThemHoaDon(HoaDon hd)
		{
			_luuTruHoaDonNhapHang.ThemHoaDon(hd);
		}

		public List<HoaDon> DocDanhSach(string tuKhoa = "")
		{
			List<HoaDon> kq = new List<HoaDon>();
			List<HoaDon> ds = _luuTruHoaDonNhapHang.DocDanhSach();

			//Lọc theo từ khóa
			foreach (HoaDon s in ds)
			{
				if (s.Ma.ToLower().Contains(tuKhoa.ToLower()))
				{
					kq.Add(s);
				}
			}
			return kq;
		}

		public HoaDon? DocHoaDon(string ma)
		{
			return _luuTruHoaDonNhapHang.DocHoaDon(ma);
		}

		public void SuaHoaDon(string ma, string ten, string ngay)
		{
			HoaDon? hd = _luuTruHoaDonNhapHang.DocHoaDon(ma);
			if (hd != null)
			{
				HoaDon hdNew = new HoaDon(ma, ten, ngay);
				_luuTruHoaDonNhapHang.SuaHoaDon(hdNew);
			}
			else
			{
				throw new Exception("Không tìm thấy hóa đơn cần sửa");
			}
		}

		public void XoaHoaDon(string ma)
		{
			_xuLyDanhMucNhapHang.XoaDanhMucTheoHoaDon(ma);
			_luuTruHoaDonNhapHang.XoaHoaDon(ma);
		}

		public int TongGiaTriHoaDon(string maHD)
		{
			int sum = 0;
			List<DanhMuc> ds = _xuLyDanhMucNhapHang.DocDanhSachTheoHoaDon(maHD);
			foreach (DanhMuc d in ds)
			{
				sum = sum + (d.DonGia * d.SoLuong);
			}
			return sum;
		}

		public void CapNhatHoaDon()
		{
			List<HoaDon> dshd = _luuTruHoaDonNhapHang.DocDanhSach();
			List<DanhMuc> dsdm = _luuTruDanhMucNhapHang.DocDanhSach();

			for (int i = 0; i < dshd.Count; i++)
			{
				int count = 0;
				for (int j = 0; j < dsdm.Count; j++)
				{
					if (dshd[i].Ma.ToLower() == dsdm[j].MaHoaDon.ToLower())
					{
						count++;
						break;
					}
				}
				if (count == 0)
				{
					_luuTruHoaDonNhapHang.XoaHoaDon(dshd[i].Ma);
				}
			}
		}
	}
}
