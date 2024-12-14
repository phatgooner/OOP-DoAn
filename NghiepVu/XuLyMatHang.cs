using DoAnMonHoc_23880108.Entity;
using DoAnMonHoc_23880108.LuuTru;

namespace DoAnMonHoc_23880108.NghiepVu
{
	public class XuLyMatHang : IXuLyMatHang
	{
		private ILuuTruMatHang _luuTruMatHang;

		public XuLyMatHang(ILuuTruMatHang luuTruMatHang)
		{
			_luuTruMatHang = luuTruMatHang;
		}

		public void ThemMatHang(MatHang sp)
		{
			_luuTruMatHang.ThemMatHang(sp);
		}

		public List<MatHang> DocDanhSach(string tuKhoa = "")
		{
			List<MatHang> kq = new List<MatHang>();
			List<MatHang> ds = _luuTruMatHang.DocDanhSach();

			//Lọc theo từ khóa
			foreach (MatHang s in ds) 
			{
				if (s.Ten.ToLower().Contains(tuKhoa.ToLower()))
				{
					kq.Add(s);
				}
			}			
			return kq;
		}

		public List<MatHang> DocDanhSachTheoLoai(string tenLoai = "")
		{
			List<MatHang> kq = new List<MatHang>();
			List<MatHang> ds = _luuTruMatHang.DocDanhSach();

			//Lọc theo từ khóa
			foreach (MatHang s in ds)
			{
				if (s.Loai.ToLower() == tenLoai.ToLower())
				{
					kq.Add(s);
				}
			}			
			return kq;
		}

		public MatHang? DocMatHang(string mssp)
		{
			return _luuTruMatHang.DocMatHang(mssp);
		}

		public void SuaMatHang(string maHang, string ten, string loai, string congTy, string nsx, string hsd, int gia)
		{
			MatHang? sp = _luuTruMatHang.DocMatHang(maHang);
			if (sp != null)
			{
				MatHang spNew = new MatHang(maHang, ten, loai, congTy, nsx, hsd, gia);				
				_luuTruMatHang.SuaMatHang(spNew);
			}
			else
			{
				throw new Exception("Không tìm thấy sản phẩm cần sửa");
			}	
		}

		public void XoaMatHang(string mssp)
		{
			_luuTruMatHang.XoaMatHang(mssp);
		}

		public void XoaMatHangTheoLoai(string tenLH)
		{
			List<MatHang> dsmh = _luuTruMatHang.DocDanhSach();
			foreach (MatHang s in dsmh)
			{
				if (s.Loai.ToLower() == tenLH.ToLower())
				{
					XoaMatHang(s.Ma);
				}	
			}	
		}

		public void SuaMatHangTheoLoai(string tenCu, string tenMoi)
		{
			List<MatHang> dsmh = _luuTruMatHang.DocDanhSach();
			foreach (MatHang s in dsmh)
			{
				if (s.Loai.ToLower() == tenCu.ToLower())
				{
					MatHang spNew = new MatHang(s.Ma, s.Ten, tenMoi, s.CongTySX, s.NSX.ToString(), s.HSD.ToString(), s.Gia);
					_luuTruMatHang.SuaMatHang(spNew);
				}
			}
		}
	}
}
