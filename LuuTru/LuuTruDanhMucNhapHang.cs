using DoAnMonHoc_23880108.Entity;
using Newtonsoft.Json;

namespace DoAnMonHoc_23880108.LuuTru
{
	public class LuuTruDanhMucNhapHang : ILuuTruDanhMuc
	{
		private string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
		private string fileName = "../../../Stored/DanhMucNhapHang.txt";
		private string filePath = string.Empty; //Property

		public void LuuDanhSach(List<DanhMuc> ds)
		{
			filePath = Path.Combine(currentDirectory, fileName);
			string jsonString = JsonConvert.SerializeObject(ds);
			StreamWriter file = new StreamWriter(filePath);
			if (ds == null)
			{
				file.Write("[]");
			}
			else
			{
				file.Write(jsonString);
			}
			file.Close();
		}

		public List<DanhMuc> DocDanhSach()
		{
			filePath = Path.Combine(currentDirectory, fileName);
			StreamReader file = new StreamReader(filePath);
			string jsonString = file.ReadToEnd();
			var ds = JsonConvert.DeserializeObject<List<DanhMuc>>(jsonString);
			file.Close();
			return ds;
		}

		public void ThemDanhMuc(DanhMuc sp)
		{
			List<DanhMuc> ds = DocDanhSach();
			foreach (DanhMuc dm in ds)
			{
				if (dm.MaHoaDon.ToLower() == sp.MaHoaDon.ToLower() && dm.TenHang.ToLower() == sp.TenHang.ToLower())
				{
					throw new Exception("Mã mặt hàng đã tồn tại");
				}
			}
			ds.Add(sp);
			LuuDanhSach(ds);
		}

		public DanhMuc? DocDanhMuc(string maHD, string tenHang)
		{
			List<DanhMuc> ds = DocDanhSach();
			foreach (DanhMuc dm in ds)
			{
				if (dm.MaHoaDon.ToLower() == maHD.ToLower() && dm.TenHang.ToLower() == tenHang.ToLower())
				{
					return dm;
				}
			}
			return null;
		}

		public void XoaDanhMucTheoHoaDon(string maHD)
		{
			List<DanhMuc> ds = DocDanhSach();

			for (int i = ds.Count - 1; i >= 0; i--)
			{
				if (ds[i].MaHoaDon.ToLower() == maHD.ToLower())
				{
					ds.RemoveAt(i);
				}
			}
			LuuDanhSach(ds);
		}

		public void XoaDanhMucTheoTenMatHang(string maHD, string tenMatHang)
		{
			List<DanhMuc> ds = DocDanhSach();
			for (int i = ds.Count - 1; i >= 0; i--)
			{
				if (ds[i].MaHoaDon.ToLower() == maHD.ToLower() && ds[i].TenHang.ToLower() == tenMatHang.ToLower())
				{
					ds.RemoveAt(i);
				}
			}
			LuuDanhSach(ds);
		}
	}
}
