using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyHoaDonBanHang : IXuLyHoaDon
	{
		private ILuuTruHoaDon _luuTruHoaDonBanHang;
		private IXuLyDanhMuc _xuLyDanhMucBanHang;
		private ILuuTruDanhMuc _luuTruDanhMucBanHang;

		public XuLyHoaDonBanHang(ILuuTruHoaDon luuTruHoaDonBanHang, IXuLyDanhMuc xuLyDanhMucBanHang, ILuuTruDanhMuc luuTruDanhMucBanHang)
		{
			_luuTruHoaDonBanHang = luuTruHoaDonBanHang;
			_xuLyDanhMucBanHang = xuLyDanhMucBanHang;
			_luuTruDanhMucBanHang = luuTruDanhMucBanHang;
		}

		public void ThemHoaDon(HoaDon hd)
		{
			_luuTruHoaDonBanHang.ThemHoaDon(hd);
		}

		public List<HoaDon> DocDanhSach(string tuKhoa = "")
		{
			List<HoaDon> kq = new List<HoaDon>();
			List<HoaDon> ds = _luuTruHoaDonBanHang.DocDanhSach();

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
			return _luuTruHoaDonBanHang.DocHoaDon(ma);
		}

		public void SuaHoaDon(string ma, string ten, string ngay)
		{
			HoaDon? hd = _luuTruHoaDonBanHang.DocHoaDon(ma);
			if (hd != null)
			{
				HoaDon hdNew = new HoaDon(ma, ten, ngay);
				_luuTruHoaDonBanHang.SuaHoaDon(hdNew);
			}
			else
			{
				throw new Exception("Không tìm thấy hóa đơn cần sửa");
			}
		}

		public void XoaHoaDon(string ma)
		{
			_xuLyDanhMucBanHang.XoaDanhMucTheoHoaDon(ma);
			_luuTruHoaDonBanHang.XoaHoaDon(ma);
		}

		public int TongGiaTriHoaDon(string maHD)
		{
			int sum = 0;
			List<DanhMuc> ds = _xuLyDanhMucBanHang.DocDanhSachTheoHoaDon(maHD);
			foreach (DanhMuc d in ds)
			{
				sum = sum + (d.DonGia * d.SoLuong);
			}
			return sum;
		}

		public void CapNhatHoaDon()
		{
			List<HoaDon> dshd = _luuTruHoaDonBanHang.DocDanhSach();
			List<DanhMuc> dsdm = _luuTruDanhMucBanHang.DocDanhSach();

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
					_luuTruHoaDonBanHang.XoaHoaDon(dshd[i].Ma);
				}
			}
		}
	}
}
