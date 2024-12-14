using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyLoaiHang : IXuLyLoaiHang
	{
		private ILuuTruLoaiHang _luuTruLoaiHang;
		private IXuLyMatHang _xuLyMatHang;


		public XuLyLoaiHang(ILuuTruLoaiHang luuTruLoaiHang, IXuLyMatHang xuLyMatHang)
		{
			_luuTruLoaiHang = luuTruLoaiHang;
			_xuLyMatHang = xuLyMatHang;
		}

		public void ThemLoaiHang(LoaiHang sp)
		{
			_luuTruLoaiHang.ThemLoaiHang(sp);
		}

		public List<LoaiHang> DocDanhSach(string tuKhoa = "")
		{
			List<LoaiHang> kq = new List<LoaiHang>();
			List<LoaiHang> ds = _luuTruLoaiHang.DocDanhSach();

			//Lọc theo từ khóa
			foreach (LoaiHang s in ds)
			{
				if (s.Ten.ToLower().Contains(tuKhoa.ToLower()))
				{
					kq.Add(s);
				}
			}
			return kq;
		}		

		public LoaiHang? DocLoaiHang(string ma)
		{
			return _luuTruLoaiHang.DocLoaiHang(ma);
		}

		public void SuaLoaiHang(string ma, string tencu, string tenmoi)
		{
			_xuLyMatHang.SuaMatHangTheoLoai(tencu, tenmoi);
			LoaiHang? lh = _luuTruLoaiHang.DocLoaiHang(ma);
			if (lh != null)
			{
				LoaiHang lhNew = new LoaiHang(ma, tenmoi);
				_luuTruLoaiHang.SuaLoaiHang(lhNew);
			}
			else
			{
				throw new Exception("Không tìm thấy loại hàng cần sửa");
			}
		}

		public void XoaLoaiHang(string ma, string ten)
		{
			_xuLyMatHang.XoaMatHangTheoLoai(ten);
			_luuTruLoaiHang.XoaLoaiHang(ma);
		}

		public List<string> DocDanhSachLoaiHang()
		{
			List<LoaiHang> a = _luuTruLoaiHang.DocDanhSach();
			List<string> s = new List<string>();
			foreach (LoaiHang lh in a)
			{
				s.Add(lh.Ten.ToUpper());
			}
			return s.Distinct().ToList();
		}
	}
}
